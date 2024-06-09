using DailyTasksList.Application.Features.Taskes.Commands.CreatePost;
using DailyTasksList.Application.Features.Taskes.Commands.DeletePost;
using DailyTasksList.Application.Features.Taskes.Commands.UpdatePost;
using DailyTasksList.Application.Features.Taskes.Queries.GetTaskDetail;
using DailyTasksList.Application.Features.Taskes.Queries.GetTasksList;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DailyTasksList.Api.Controllers
{
    #region public  Class
  
    [Route("api/[controller]")]
    [ApiController]
    [Authorize (AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TaskController : ControllerBase
    {
        #region public  Properties

        private readonly IMediator _mediator;

        #endregion public  Properties

        #region Public Constructors
        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion Public Constructors

        #region Public EndPoint

        [HttpGet("GetAllTaskes")]
        public async Task<ActionResult<List<GetTaskListViewModel>>> GetAllTaskes()
        {
            var lstTask = await _mediator.Send(new GetTaskListQuery());
            return Ok(lstTask);
        }

        [HttpGet("{id}", Name = "GetTaskById")]
        public async Task<ActionResult<GetTaskDetailViewModel>> GetTaskById(long id)
        {
            var getDetQuery = new GetTaskDetailQuery() { TaskId = id };
            return Ok(await _mediator.Send(getDetQuery));
        }

        [HttpPost("AddTask")]
        public async Task<ActionResult<CreateTaskResponse>> Create( CreateTaskCommand createtaskCommand)
        {
            var task = await _mediator.Send(createtaskCommand);
            return Ok(task);
        }

        [HttpPut("UpdateTask")]
        public async Task<ActionResult<UpdateTaskResponse>> Update( UpdateTaskCommand updatetaskCommand)
        {
            var task =await _mediator.Send(updatetaskCommand);
            return Ok(task);
        }

        [HttpDelete("{id}", Name = "DeleteTask")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleteTaskCommand = new DeleteTaskCommand() { TaskId = id };
            await _mediator.Send(deleteTaskCommand);
            return Ok(new {deleteTaskCommand.TaskId});
        }

        #endregion Public EndPoint
    }
    #endregion public  Class
}
