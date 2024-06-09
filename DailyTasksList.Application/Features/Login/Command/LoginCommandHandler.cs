using DailyTasksList.Application.Contracts;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DailyTasksList.Application.Features.Login.Command
{
    #region Public Class
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        #region Private Fields
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        #endregion Private Fields

        #region public Constructors

        //injet DI
        public LoginCommandHandler(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        #endregion public Constructors

        #region Private Method
        private string GetToken(List<Claim> authClaims)
        { 
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            var handler = new JwtSecurityTokenHandler();
            
            return handler.WriteToken(token).ToString(); 
        }
        #endregion  Private Method

        #region public Method
        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByUserName(request.UserName);
            string token = "";
              if (user != null && user.PasswordHash == request.Password)
               {
                   var authClaims = new List<Claim>
                   {
                       new Claim(ClaimTypes.Name, user.UserName),
                       new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                   };

                   //assign roles
                   foreach (var userRole in user.UserRoles)
                   {
                       authClaims.Add(new Claim(ClaimTypes.Role, userRole.Role.Name));
                   }
                   //genrate token
                    token = GetToken(authClaims);
                   return  token;
               }
            return "Unothraization";
        }
        #endregion public Method   

    }
    #endregion Public Class
}
