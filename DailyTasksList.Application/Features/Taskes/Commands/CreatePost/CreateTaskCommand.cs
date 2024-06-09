using MediatR;

namespace DailyTasksList.Application.Features.Taskes.Commands.CreatePost
{
    #region Public Class
    public class CreateTaskCommand :IRequest<CreateTaskResponse>
    {
        #region Public Properties
        public required string Name { get; set; }
        public string? Priority { get; set; }
        public string? Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public string? Description { get; set; }

        #endregion Properties
    }
    #endregion Public Class
}
