using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SingleAgenda.Entities.Contact
{
    public class LegalPerson
        : Person
    {

        [Required]
        public string Cnpj { get; set; }

        [Required]
        public string TradeName { get; set; }

    }
}
