using Domain.Models;
using Repository.Default;
using Repository.Default.Interfaces;

namespace Repositories.Repositories
{
    public class TestRepository : BaseUsersRepository<Test>, IDefaultUsersRepository<Test>
    {
        public TestRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
