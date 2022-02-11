using SingleAgenda.EFPersistence.Base;
using SingleAgenda.EFPersistence.Configuration;
using SingleAgenda.Entities.Contact;
using System;
using System.Collections.Generic;
using System.Text;

namespace SingleAgenda.EFPersistence.Repositories
{
    public class PersonRepository
        : RepositoryBase<Person>
    {
        //public PersonRepository(IServiceProvider serviceProvider) 
        //    : base(serviceProvider)
        //{
        //}

        public PersonRepository(SingleAgendaDbContext context)
            : base(context)
        {
        }
    }
}
