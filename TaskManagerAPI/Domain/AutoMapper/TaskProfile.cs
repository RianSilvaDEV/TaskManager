using TaskManagerAPI.Entities;
using AutoMapper;
using TaskManagerAPI.Domain.Views;
using TaskManagerAPI.Domain.InputModels;

namespace TaskManagerAPI.Domain.AutoMapper
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<TaskInputModel, TaskEntity>();
            CreateMap<TaskEntity, TaskView>();
        }
    }
}
