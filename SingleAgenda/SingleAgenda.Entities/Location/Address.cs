using SingleAgenda.Entities.Base;
using SingleAgenda.Entities.Contact;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SingleAgenda.Entities.Location
{
    public class Address
        : EntityBase
    {

        [Required]
        [Column(TypeName = "varchar(8)")]
        public string ZipCode { get; set; }

        [Required]
        [Column(TypeName = "char(3)")]
        public string Country { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string State { get; set; }

        [Required]
        [Column(TypeName = "varchar(80)")]
        public string City { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Description { get; set; }

        public Person Person { get; set; }

        [Required]
        public int PersonId { get; set; }
    }
}
