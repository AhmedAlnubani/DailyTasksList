using MediatR;

namespace DailyTasksList.Application.Features.Taskes.Commands.DeletePost
{
    #region Public Class
    public class DeleteTaskCommand: IRequest
    {
        #region Public Properties 
        public long TaskId { get; set; }
        #endregion Public properties  
    }
    #endregion Public Class
}
