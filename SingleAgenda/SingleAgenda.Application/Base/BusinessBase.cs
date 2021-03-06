using SingleAgenda.Infra.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SingleAgenda.Application.Base
{
    public class BusinessBase
    {
        protected readonly SingleAgendaDbContext dbContext;

        public BusinessBase(SingleAgendaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
