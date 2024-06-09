

namespace DailyTasksList.Application.Features.Taskes.Queries.GetTasksList
{
        #region Public Classes
    public class GetTaskListViewModel
    {
        #region Public Properties
        public long Id { get; set; }
        public required string Name { get; set; }
        public string ?Priority { get; set; }
        public string ?Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public string? Description { get; set; }
        #endregion Properties
    }
    #endregion Public Classes
}
