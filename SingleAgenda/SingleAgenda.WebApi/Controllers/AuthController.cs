using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SingleAgenda.Application.UsersAndRoles;
using SingleAgenda.Dtos.Messages;
using SingleAgenda.Dtos.UsersAndRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleAgenda.WebApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        [HttpPost]
        public async Task<ActionResult<AuthMessageDto>> CreateAsync(
            [FromBody] UserDto user,
            [FromServices] AuthBusiness authBusiness)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            return await authBusiness.AuthUser(user);
        }

    }
}
