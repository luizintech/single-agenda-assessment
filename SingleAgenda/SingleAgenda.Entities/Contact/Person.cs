using SingleAgenda.Entities.Base;
using SingleAgenda.Entities.Location;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SingleAgenda.Entities.Contact
{
    public class Person
        : EntityBase
    {

        [Required]
        [Column(TypeName = "varchar(80)")]
        public string Name { get; set; }

        [Required]
        public PersonType PersonType { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; }

        /// <summary>
        /// The value of CPF / CNPJ
        /// </summary>
        [Column(TypeName = "varchar(14)")]
        public string Document { get; set; }

        public List<Address> Addresses { get; set; }

        #region Legal Person Specific Fields

        [Column(TypeName = "varchar(50)")]
        public string TradeName { get; set; }

        #endregion

        #region Natural Person Specific Fields

        public DateTime Birthday { get; set; }

        public Gender Gender { get; set; }

        #endregion

    }
}
