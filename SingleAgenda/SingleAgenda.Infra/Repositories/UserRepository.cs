using SingleAgenda.EFPersistence.Base;
using SingleAgenda.EFPersistence.Configuration;
using SingleAgenda.Entities.UsersAndRoles;

namespace SingleAgenda.EFPersistence.Repositories
{
    public class UserRepository
        : RepositoryBase<User>
    {

        public UserRepository(SingleAgendaDbContext context)
            : base(context)
        {
        }
    }
}
