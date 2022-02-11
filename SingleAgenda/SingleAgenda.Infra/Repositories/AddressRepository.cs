using SingleAgenda.EFPersistence.Base;
using SingleAgenda.EFPersistence.Configuration;
using SingleAgenda.Entities.Location;
using System;
using System.Collections.Generic;
using System.Text;

namespace SingleAgenda.EFPersistence.Repositories
{
    public class AddressRepository
        : RepositoryBase<Address>
    {

        public AddressRepository(SingleAgendaDbContext context)
            : base(context)
        {
        }
    }
}
