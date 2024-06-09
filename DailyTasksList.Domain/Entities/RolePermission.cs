
namespace DailyTasksList.Domain.Entities
{
    #region Public Class
    public class RolePermission
    {
        #region Public Properties
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public int PermissionId { get; set; }
        public Permission Permission { get; set; }
        #endregion Public Properties
    }
    #endregion Public Class
}
