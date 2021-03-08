using SingleAgenda.Dtos.Location;
using SingleAgenda.Entities.Contact;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SingleAgenda.Dtos.Contact
{
    public class PersonDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public PersonType PersonType { get; set; }
        public string Document { get; set; }

        public List<AddressDto> Addresses { get; set; } = new List<AddressDto>();

        public string TradeName { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }

        public static readonly Expression<Func<PersonDto, Person>> ToEntity =
            p => new Person()
            {
                Id = p.Id,
                TradeName = p.TradeName,
                Birthday = p.Birthday,
                Document = p.Document,
                Gender = p.Gender,
                Name = p.Name,
                PersonType = p.PersonType
            };

    }
}
