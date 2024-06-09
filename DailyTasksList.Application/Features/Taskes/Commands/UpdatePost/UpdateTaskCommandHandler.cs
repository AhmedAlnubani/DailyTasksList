using AutoMapper;
using DailyTasksList.Application.Contracts;
using DailyTasksList.Domain.Entities;
using MediatR;
namespace DailyTasksList.Application.Features.Taskes.Commands.UpdatePost
{
    #region Public Classes
    public class UpdateTaskCommandHandler:IRequestHandler<UpdateTaskCommand, UpdateTaskResponse>
    {
        #region Private Fields

        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        #endregion Private Fields

        #region public Constructors

        //injet DI
        public UpdateTaskCommandHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        #endregion public Constructors

        #region Public Method
        public async Task<UpdateTaskResponse> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            DailyTaskes task = _mapper.Map<DailyTaskes>(request);
            var updateTask = _mapper.Map<UpdateTaskResponse>(request);
            await _taskRepository.UpdateAsync(task);
            return updateTask;
        }

        #endregion Public Method

    }
    #endregion Public Classes
}
