using AutoMapper;
using ToDoList_Server.Interfaces.Aggregates;
using ToDoList_Server.Models;
using ToDoList_Server.Models.Pagination;
using ToDoList_Server_Database.Entities;

namespace ToDoList_Server.Services
{
    public class TaskService : ITaskAggregateService
    {
        private readonly IMapper _mapper;
        private readonly ITaskAggregateRepository _repository;
        private readonly ITaskAggregateValidator _validator;

        public TaskService(IMapper mapper, ITaskAggregateRepository repository, ITaskAggregateValidator validator)
        {
            _mapper = mapper;
            _repository = repository;
            _validator = validator;
        }
        public async Task AddAsync(AddTaskDto dto)
        {
            _validator.ValidateTask(dto);

            TaskItem? taskItem = await _repository.GetTitleAsync(dto.Title);

            _validator.ThrowIfEntityExist(taskItem);

            TaskItem newTaskItem = _mapper.Map<TaskItem>(dto);

            await _repository.AddAsync(newTaskItem);
        }

        public async Task<PaginationResult<GetTaskDto>> GetAsync(PaginationDto paginationDto)
        {
            _validator.ValidatePagination(paginationDto);

            var totalCounts = await _repository.CountRecordsAsync();

            var tasks = await _repository.GetAsync(paginationDto);

            var tasksDto = _mapper.Map<List<GetTaskDto>>(tasks);

            var dto = new PaginationResult<GetTaskDto>
            {
                TotalCount = totalCounts,
                Results = tasksDto
            };

            return dto;
        }

        public async Task RemoveAsync(int id)
        {
            _validator.ValidateId(id);

            var task = await _repository.GetAsync(id);

            _validator.ThrowIfEntityIsNull(task!);

            await _repository.RemoveAsync(task!);
        }

        public async Task UpdateTaskStatusAsync(int id, UpdateTaskStatusDto dto)
        {
            _validator.ValidateId(id);

            _validator.ValidateTaskStatus(dto);

            var task = await _repository.GetAsync(id);

            _validator.ThrowIfEntityIsNull(task);

            _mapper.Map(dto, task);

            await _repository.SaveChangesAsync();
        }
    }
}
