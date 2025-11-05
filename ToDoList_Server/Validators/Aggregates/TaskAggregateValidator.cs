using ToDoList_Server.Interfaces;
using ToDoList_Server.Interfaces.Aggregates;
using ToDoList_Server.Models;
using ToDoList_Server.Models.Pagination;
using ToDoList_Server_Database.Entities;

namespace ToDoList_Server.Validators.Aggregates
{
    public class TaskAggregateValidator : ITaskAggregateValidator
    {
        private readonly IValidatorId _validatorId;
        private readonly ITaskValidator _taskValidator;
        private readonly IEntityValidator<TaskItem> _entityValidator;
        private readonly IPaginationValidator _paginationValidator;

        public TaskAggregateValidator(IValidatorId validatorId, ITaskValidator taskValidator, IEntityValidator<TaskItem> entityValidator, IPaginationValidator paginationValidator)
        {
            _validatorId = validatorId;
            _taskValidator = taskValidator;
            _entityValidator = entityValidator;
            _paginationValidator = paginationValidator;
        }

        public void ThrowIfEntityExist(TaskItem? entity)
        {
            _entityValidator.ThrowIfEntityExist(entity);
        }

        public void ThrowIfEntityIsNull(TaskItem? entity)
        {
            _entityValidator.ThrowIfEntityIsNull(entity);
        }

        public void ValidateId(int id)
        {
            _validatorId.ValidateId(id);
        }

        public void ValidatePagination(PaginationDto dto)
        {
            _paginationValidator.ValidatePagination(dto);
        }

        public void ValidateTask(AddTaskDto dto)
        {
            _taskValidator.ValidateTask(dto);
        }

        public void ValidateTaskStatus(UpdateTaskStatusDto dto)
        {
            _taskValidator.ValidateTaskStatus(dto);
        }
    }
}
