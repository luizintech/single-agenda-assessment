using SingleAgenda.Entities.Base;
using SingleAgenda.Entities.Contact;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SingleAgenda.Entities.Location
{
    public class Address
        : EntityBase
    {

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Description { get; set; }

        public Person Person { get; set; }

        [Required]
        public int PersonId { get; set; }
    }
}
