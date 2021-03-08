using System;
using System.Collections.Generic;
using System.Text;

namespace SingleAgenda.Dtos.UsersAndRoles
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
