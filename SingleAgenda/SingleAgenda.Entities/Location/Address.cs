using SingleAgenda.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SingleAgenda.Entities.Location
{
    public class Address
        : EntityBase
    {

        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Description { get; set; }

    }
}
