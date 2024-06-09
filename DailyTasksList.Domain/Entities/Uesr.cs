

namespace DailyTasksList.Domain.Entities
{
    #region public Class
    public class User
    {
      #region Public Properties

        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public ICollection<UserRoles> UserRoles { get; set; }
        #endregion Properties
    }
    #endregion public Class
}
