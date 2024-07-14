using System.Linq.Expressions;
using DataAccessLayer.Dao.Abstractions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Abstractions;

namespace Repository.Repositories
{
    public class RegisterFormRepository : IRegisterFormRepository
    {
        private readonly IRegisterFormDao _registerFormDao;

        public RegisterFormRepository(IRegisterFormDao registerFormDao)
        {
            _registerFormDao = registerFormDao;
        }

        public IQueryable<RegisterForm> FindAll() =>
            _registerFormDao
                .FindAll()
                .Where(f => f.IsDelete == false)
                .Include(f => f.Staff)
                .Include(f => f.Tickets)
                .OrderByDescending(f => f.ModifiedAt > f.CreatedAt ? f.ModifiedAt : f.CreatedAt);

        public IQueryable<RegisterForm> FindByCondition(
            Expression<Func<RegisterForm, bool>> expression,
            bool trackChanges
        ) =>
            _registerFormDao
                .FindByCondition(expression, trackChanges)
                .OrderByDescending(f => f.ModifiedAt > f.CreatedAt ? f.ModifiedAt : f.CreatedAt);

        public async Task<bool> Create(RegisterForm entity) =>
            await _registerFormDao.Create(entity);

        public async Task<bool> Update(RegisterForm entity) =>
            await _registerFormDao.Update(entity);

        public async Task<bool> Delete(RegisterForm entity) =>
            await _registerFormDao.Delete(entity);
    }
}
