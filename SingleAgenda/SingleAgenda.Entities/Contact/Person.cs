using SingleAgenda.Entities.Base;
using SingleAgenda.Entities.Location;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SingleAgenda.Entities.Contact
{
    public class Person
        : EntityBase
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public PersonType PersonType { get; set; }

        public List<Address> Addresses { get; set; }

    }
}
