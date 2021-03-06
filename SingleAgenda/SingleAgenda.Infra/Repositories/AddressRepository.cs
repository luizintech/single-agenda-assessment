using SingleAgenda.Entities.Location;
using SingleAgenda.Infra.Base;
using SingleAgenda.Infra.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SingleAgenda.Infra.Repositories
{
    public class AddressRepository
        : RepositoryBase<Address>
    {
        public AddressRepository(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        public AddressRepository(SingleAgendaDbContext context)
            : base(context)
        {
        }
    }
}
