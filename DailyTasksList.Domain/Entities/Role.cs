

namespace DailyTasksList.Domain.Entities
{
    #region Public Class
    public  class Role
    {
        #region Public Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserRoles> UserRoles { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; }
        #endregion Public Properties
    }
    #endregion Public Class
}
