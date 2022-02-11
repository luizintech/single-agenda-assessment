using Microsoft.EntityFrameworkCore;
using SingleAgenda.Application.Base;
using SingleAgenda.Dtos.Dashboard;
using SingleAgenda.EFPersistence.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace SingleAgenda.Application.Dashboard
{
    public class DashboardBusiness
        : BusinessBase
    {

        public DashboardBusiness(SingleAgendaDbContext context)
            : base(context)
        {
        }

        public async Task<DashboardStatisticsDto> ShowAsync()
        {
            return await this._context.Persons.GroupBy(p => 1)
                .Select(person => new DashboardStatisticsDto()
                {
                    TotalContacts = person.Count(),
                    NaturalPersons = person.Where(p => p.PersonType == Entities.Contact.PersonType.Natural).Count(),
                    LegalPersons = person.Where(p => p.PersonType == Entities.Contact.PersonType.Legal).Count()
                }).SingleOrDefaultAsync();
        }

    }
}
