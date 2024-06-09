
using Microsoft.AspNetCore.Mvc;
using DailyTasksList.Application.Contracts;
using MediatR;
using DailyTasksList.Application.Features.Login.Command;
namespace DailyTasksList.Api.Controllers
{
    #region public  Class

    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {

        #region private Properties

        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;

        #endregion private Properties

        #region Public Constructors
        public AccountsController(IConfiguration configuration, IUserRepository userRepository, IMediator mediator)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _mediator = mediator;
        }
        #endregion Public Constructors

        #region Public EndPoint
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginCommand loginCommand)
        {
            var token = await _mediator.Send(loginCommand);
           
            return Ok(new {token});

        }
        #endregion Public EndPoint

    }
    #endregion public  Class
}
