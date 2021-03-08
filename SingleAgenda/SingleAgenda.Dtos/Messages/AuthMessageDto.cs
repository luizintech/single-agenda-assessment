using SingleAgenda.Dtos.UsersAndRoles;
using System;
using System.Collections.Generic;
using System.Text;

namespace SingleAgenda.Dtos.Messages
{
    public class AuthMessageDto
        : ResultDto
    {

        public string Token { get; set; }
        public UserDto UserInfo { get; set; }

    }
}
