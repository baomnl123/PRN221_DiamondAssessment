using DataAccessLayer.Context;
using DataAccessLayer.Dao.Abstractions;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Dao
{
    public class RegisterFormDao : DaoBase<RegisterForm>, IRegisterFormDao
    {
        public RegisterFormDao(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
