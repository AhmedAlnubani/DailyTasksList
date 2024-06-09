using AutoMapper;
using DailyTasksList.Application.Contracts;
using MediatR;

namespace DailyTasksList.Application.Features.Taskes.Queries.GetTasksList
{
    #region Public Classes
    public class GetTaskListQueryHandler : IRequestHandler<GetTaskListQuery, List<GetTaskListViewModel>>
    {
        #region Private Fields

        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        #endregion Private Fields

        #region public Constructors
        //inject DI
        public GetTaskListQueryHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }
        #endregion public Constructors

        #region public Method
        public async Task<List<GetTaskListViewModel>> Handle(GetTaskListQuery request, CancellationToken cancellationToken)
        {
            var allTask = await _taskRepository.ListAllAsync();
            return _mapper.Map<List<GetTaskListViewModel>>(allTask);
        }
        #endregion public Method
    }
#endregion Public Classes
}
