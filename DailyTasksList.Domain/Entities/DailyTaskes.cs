
namespace DailyTasksList.Domain.Entities
{
    #region public Class
    public class DailyTaskes
    {
        #region Public Properties
        
        public  long Id { get; set; }
        public  string Name { get; set; }
        public string ?Priority { get; set; }
        public string ?Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? CreateOn { get; set; }
        public DateTime? CompleteOn { get; set; }
        public string ?Description { get; set; }

        #endregion Properties
    }
    #endregion public Class
}
