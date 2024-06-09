using AutoMapper;
using DailyTasksList.Application.Contracts;
using DailyTasksList.Domain.Entities;
using MediatR;

namespace DailyTasksList.Application.Features.Taskes.Commands.DeletePost
{
    #region public class
    public class DeleteTaskCommandHandler:IRequestHandler<DeleteTaskCommand>
    {
        #region Private Fields

        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        #endregion Private Fields

        #region public Constructors

        //injet DI
        public DeleteTaskCommandHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }
        #endregion public Constructors

        #region public Method
        public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {

            DailyTaskes task= await _taskRepository.GetByIdAsync(request.TaskId); 
            await _taskRepository.DeleteAsync(task);
            return Unit.Value;
         }
#endregion public Method

    }
    #endregion public class
}
