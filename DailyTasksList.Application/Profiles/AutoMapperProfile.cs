using AutoMapper;
using DailyTasksList.Application.Features.Taskes.Commands.CreatePost;
using DailyTasksList.Application.Features.Taskes.Commands.DeletePost;
using DailyTasksList.Application.Features.Taskes.Commands.UpdatePost;
using DailyTasksList.Application.Features.Taskes.Queries.GetTaskDetail;
using DailyTasksList.Application.Features.Taskes.Queries.GetTasksList;
using DailyTasksList.Domain.Entities;

namespace DailyTasksList.Application.Profiles
{
    #region Public Class
    public class AutoMapperProfile:Profile
    {
        #region Public Method
        //Map To Object
        public AutoMapperProfile()
        {
            CreateMap<DailyTaskes, GetTaskListViewModel>().ReverseMap(); 
            CreateMap<DailyTaskes, GetTaskDetailViewModel>().ReverseMap();
            CreateMap<DailyTaskes, CreateTaskCommand>().ReverseMap();
            CreateMap<DailyTaskes, UpdateTaskCommand>().ReverseMap();
            CreateMap<DailyTaskes, DeleteTaskCommand>().ReverseMap();
            CreateMap<UpdateTaskCommand, UpdateTaskResponse>().ReverseMap();
            CreateMap<DailyTaskes, CreateTaskResponse>().ReverseMap();
            
        }
        #endregion Public Method

    }
    #endregion Public Class
}
