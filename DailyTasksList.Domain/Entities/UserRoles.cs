

namespace DailyTasksList.Domain.Entities
{
    #region Public  Class
    public  class UserRoles
    {
        #region Public Properties
        public int UserId { get; set; }
        public User User { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
        #endregion Public Properties
    }
    #endregion Public  Class
}
