using DataAccessLayer.Context;
using DataAccessLayer.Dao.Abstractions;
using Entities.Models;

namespace DataAccessLayer.Dao
{
    public class RegisterFormDao : DaoBase<RegisterForm>, IRegisterFormDao
    {
        public RegisterFormDao(RepositoryContext repositoryContext)
            : base(repositoryContext) { }
    }
}
