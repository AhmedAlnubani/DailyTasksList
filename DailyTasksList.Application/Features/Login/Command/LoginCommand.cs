using MediatR;
namespace DailyTasksList.Application.Features.Login.Command
{
    #region Public Class
    public class LoginCommand : IRequest<string> {
        #region Public Properties

        public string UserName { get; set; }
        public string Password { get; set; }

        #endregion Public Properties

    }
    #endregion Public Class
}
