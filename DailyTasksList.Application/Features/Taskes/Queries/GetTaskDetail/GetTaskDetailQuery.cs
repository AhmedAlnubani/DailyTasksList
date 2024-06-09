using MediatR;

namespace DailyTasksList.Application.Features.Taskes.Queries.GetTaskDetail
{
    #region Public Class
    public class GetTaskDetailQuery:IRequest<GetTaskDetailViewModel>
    {
        #region Public Properties
        public long TaskId { get; set; }
        #endregion Public Properties
    }
    #endregion Public Class
}
