using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SingleAgenda.Entities.Base
{
    public abstract class EntityBase
    {

        [Key]
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
