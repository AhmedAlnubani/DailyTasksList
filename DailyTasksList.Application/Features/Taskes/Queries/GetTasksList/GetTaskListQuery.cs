using MediatR;

namespace DailyTasksList.Application.Features.Taskes.Queries.GetTasksList
{
    #region Public Classes
    public class GetTaskListQuery:IRequest<List<GetTaskListViewModel>>
    {
    }
    #endregion Public Classes
}
