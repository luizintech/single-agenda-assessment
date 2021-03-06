using System;
using System.Collections.Generic;
using System.Text;

namespace SingleAgenda.Dtos.Location
{
    public class AddressDto
    {
        public int Id { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public int PersonId { get; set; }

    }
}
