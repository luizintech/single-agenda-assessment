using SingleAgenda.EFPersistence.Configuration;

namespace SingleAgenda.Application.Base
{
    public abstract class BusinessBase
    {
        protected readonly SingleAgendaDbContext _context;

        public BusinessBase(SingleAgendaDbContext dbContext)
        {
            this._context = dbContext;
        }
    }
}
