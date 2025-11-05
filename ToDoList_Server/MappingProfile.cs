using AutoMapper;
using ToDoList_Server.Models;
using ToDoList_Server_Database.Entities;

namespace ToDoList_Server
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskItem, GetTaskDto>();
            CreateMap<AddTaskDto, TaskItem>();
            CreateMap<UpdateTaskStatusDto, TaskItem>();
        }
    }
}
