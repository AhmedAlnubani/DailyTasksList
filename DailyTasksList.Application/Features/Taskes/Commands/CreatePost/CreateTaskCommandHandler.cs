using AutoMapper;
using DailyTasksList.Application.Contracts;
using DailyTasksList.Domain.Entities;
using MediatR;

namespace DailyTasksList.Application.Features.Taskes.Commands.CreatePost
{
    #region Public Class
    public class CreateTaskCommandHandler :IRequestHandler<CreateTaskCommand, CreateTaskResponse>
    {
        #region Private Fields

        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        #endregion Private Fields

        #region public Constructors

        //injet DI
        public CreateTaskCommandHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }
        #endregion public Constructors

        #region public Method
        public async Task<CreateTaskResponse> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {

            DailyTaskes task = _mapper.Map<DailyTaskes>(request);

            CreateCommandValidator validator = new CreateCommandValidator();
            var result = await validator.ValidateAsync(request);
            if (result.Errors.Any())
            {
                throw new Exception("Task Add Is Not Valid");
            }
            await _taskRepository.AddAsync(task);
            var rusTask = _mapper.Map<CreateTaskResponse>(task);
            return rusTask;
        }
        #endregion public Method

    }
    #endregion Public Class
}
