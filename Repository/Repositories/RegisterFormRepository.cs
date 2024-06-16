using DataAccessLayer.Dao.Abstractions;
using Entities.Models;
using Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class RegisterFormRepository : IRegisterFormRepository
    {
        private readonly IRegisterFormDao _registerFormDao;

        public RegisterFormRepository(IRegisterFormDao registerFormDao)
        {
            _registerFormDao = registerFormDao;
        }

        public IQueryable<RegisterForm> FindAll() => _registerFormDao.FindAll();

        public IQueryable<RegisterForm> FindByCondition(Expression<Func<RegisterForm, bool>> expression,
            bool trackChanges)
        => _registerFormDao.FindByCondition(expression, trackChanges);

        public async Task<bool> Create(RegisterForm entity) => await _registerFormDao.Create(entity);

        public async Task<bool> Update(RegisterForm entity) => await _registerFormDao.Update(entity);

        public async Task<bool> Delete(RegisterForm entity) => await _registerFormDao.Delete(entity);
    }
}
