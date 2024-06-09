using AutoMapper;
using DailyTasksList.Application.Contracts;
using MediatR;

namespace DailyTasksList.Application.Features.Taskes.Queries.GetTaskDetail
{
    #region Public Classes
    public class GetTaskDetailQueryHandler:IRequestHandler<GetTaskDetailQuery,GetTaskDetailViewModel>
    {

        #region Private Fields

        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        #endregion Private Fields

        #region public Constructors

        //injet DI
        public GetTaskDetailQueryHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        #endregion public Constructors

        #region public Method
        public async  Task<GetTaskDetailViewModel> Handle(GetTaskDetailQuery request, CancellationToken cancellationToken)
        {
            var allFilteTask = await _taskRepository.GetTaskesByIdAsync(request.TaskId, false);
            return _mapper.Map<GetTaskDetailViewModel>(allFilteTask);
        }
        #endregion public Method

    }
    #endregion Public Classes
}
