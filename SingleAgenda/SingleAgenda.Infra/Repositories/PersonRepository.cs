using SingleAgenda.Entities.Contact;
using SingleAgenda.Infra.Base;
using SingleAgenda.Infra.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SingleAgenda.Infra.Repositories
{
    public class PersonRepository
        : RepositoryBase<Person>
    {
        public PersonRepository(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {
        }

        public PersonRepository(SingleAgendaDbContext context) 
            : base(context)
        {
        }
    }
}
