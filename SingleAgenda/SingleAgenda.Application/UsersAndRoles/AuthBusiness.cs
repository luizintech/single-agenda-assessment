using Microsoft.EntityFrameworkCore;
using SingleAgenda.Application.Base;
using SingleAgenda.Dtos.Messages;
using SingleAgenda.Dtos.UsersAndRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using SingleAgenda.EFPersistence.Configuration;

namespace SingleAgenda.Application.UsersAndRoles
{
    public class AuthBusiness
        : BusinessBase
    {

        #region Constructor

        public AuthBusiness(SingleAgendaDbContext context)
            : base(context)
        {
        }

        #endregion

        #region Public Methods

        public async Task<AuthMessageDto> AuthUser(UserDto user)
        {
            var result = new AuthMessageDto();
            try
            {
                var userSearch = await this.dbContext.Users
                    .Where(us => us.Email == user.Email && us.Password == user.Password)
                    .SingleOrDefaultAsync();

                if (userSearch != null)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes("c2luZ2xlQWdlbmRhU2VjcmV0");
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    result.Token = tokenHandler.WriteToken(token);
                    result.UserInfo = new UserDto()
                    {
                        Name = userSearch.Name,
                        Email = userSearch.Email,
                        Id = user.Id
                    };
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

        #endregion

    }
}
