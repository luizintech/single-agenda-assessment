using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SingleAgenda.Entities.Person
{

    public class NaturalPerson
        : Person
    {

        [Required]
        public string Cpf { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        public Gender Gender { get; set; }

    }
}
