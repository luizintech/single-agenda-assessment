using Microsoft.EntityFrameworkCore;
using SingleAgenda.Application.Base;
using SingleAgenda.Dtos.Contact;
using SingleAgenda.Dtos.Dashboard;
using SingleAgenda.Infra.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleAgenda.Application.Dashboard
{
    public class DashboardBusiness
        : BusinessBase
    {

        #region Constructor

        public DashboardBusiness(SingleAgendaDbContext context)
            : base(context)
        {
        }

        #endregion

        #region Methods

        public async Task<DashboardStatisticsDto> ShowAsync()
        {
            var dashboardResult = new DashboardStatisticsDto();

            dashboardResult.TotalContacts = await this.dbContext.Persons
                .CountAsync();

            dashboardResult.NaturalPersons = await this.dbContext.Persons
                .Where(p => p.PersonType == Entities.Contact.PersonType.Natural)
                .CountAsync();

            dashboardResult.LegalPersons = await this.dbContext.Persons
                .Where(p => p.PersonType == Entities.Contact.PersonType.Legal)
                .CountAsync();

            return dashboardResult;
        }

        #endregion

    }
}
