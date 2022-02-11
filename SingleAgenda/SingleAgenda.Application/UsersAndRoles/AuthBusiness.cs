using Microsoft.EntityFrameworkCore;
using SingleAgenda.Dtos.Messages;
using SingleAgenda.Dtos.UsersAndRoles;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using SingleAgenda.Application.Base;
using SingleAgenda.EFPersistence.Repositories;

namespace SingleAgenda.Application.UsersAndRoles
{
    public class AuthBusiness
        : IBusiness
    {

        private readonly UserRepository _userRepository;

        public AuthBusiness(UserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        #region Public Methods

        public async Task<AuthMessageDto> AuthUser(UserDto user)
        {
            var result = new AuthMessageDto();
            try
            {
                var userSearch = await this._userRepository.All
                    .Where(us => us.Email == user.Email && us.Password == user.Password)
                    .Select(us => new UserDto()
                    {
                        Email = us.Email,
                        Name = us.Name,
                    })
                    .SingleOrDefaultAsync();

                if (userSearch != null)
                {
                    result.Token = GenerateToken(userSearch);
                    result.UserInfo = userSearch;
                    result.Success = true;
                }
                else
                    result.Messages.Add("There's something wrong with the informed email and password. Please, try again.");
            }
            catch (Exception ex)
            {
                result.Messages.Add(ex.ToString());
            }

            return result;
        }

        public static string GenerateToken(UserDto userInfo)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("single-agenda-security");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, userInfo.Email),
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        #endregion

    }
}
