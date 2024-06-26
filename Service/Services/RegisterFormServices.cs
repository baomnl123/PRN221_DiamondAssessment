using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Dao;
using DataAccessLayer.Dao.Abstractions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Repository.Abstractions;
using Service.Abstractions;

namespace Service.Services
{
    public class RegisterFormServices : IRegisterFormService
    {
        private readonly IRegisterFormRepository _registerFormRepository;

        public RegisterFormServices(IRegisterFormRepository registerFormRepository)
        {
            _registerFormRepository = registerFormRepository;
        }

        public List<RegisterForm> FindAll() 
            => _registerFormRepository
                .FindAll()
                .ToList();

        public IQueryable<RegisterForm> FindByCondition(
            Expression<Func<RegisterForm, bool>> expression,
            bool trackChanges
        )
        {
            return _registerFormRepository.FindByCondition(expression, trackChanges);
        }

        public Task<bool> Create(RegisterForm entity)
        {
            return _registerFormRepository.Create(entity);
        }

        public Task<bool> Update(RegisterForm entity)
        {
            return _registerFormRepository.Update(entity);
        }

        public Task<bool> Delete(RegisterForm entity)
        {
            entity.IsDelete = true;
            return _registerFormRepository.Update(entity);
        }

        public Task<bool> ApplyForm(RegisterForm entity, string staffId, bool isApproved)
        {
            if (!isApproved)
            {
                return Delete(entity);
            }

            entity.StaffId = Guid.Parse(staffId);
            entity.IsDelete = true;

            return Update(entity);
        }
        public async Task<RegisterForm> FindByEmailOrPhone(string emailOrPhone)
        {
            // Define a predicate to match either email or phone number
            Expression<Func<RegisterForm, bool>> predicate = 
                form => form.Email == emailOrPhone || form.PhoneNumber == emailOrPhone;

            // Call repository method to find by condition
            return await _registerFormRepository.FindByCondition(predicate, trackChanges: false).FirstOrDefaultAsync();
        }
    }
}
