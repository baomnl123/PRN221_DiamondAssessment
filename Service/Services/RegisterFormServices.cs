using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Dao;
using DataAccessLayer.Dao.Abstractions;
using Entities.Models;
using Entities.Models.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Repository.Abstractions;
using Service.Abstractions;

namespace Service.Services
{
    public class RegisterFormServices : IRegisterFormService
    {
        private readonly IRegisterFormRepository _registerFormRepository;
        private readonly IEmailService _emailService;

        public RegisterFormServices(IRegisterFormRepository registerFormRepository, IEmailService emailService)
        {
            _registerFormRepository = registerFormRepository;
            _emailService = emailService;
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
        
        public async Task<List<RegisterForm>> FindRegisterFormByPhone(string phone)
        {
            // Define a predicate to match either email or phone number
            Expression<Func<RegisterForm, bool>> predicate = 
                form => form.PhoneNumber == phone && !form.IsDelete;

            // Call repository method to find by condition
            return await _registerFormRepository.FindByCondition(predicate, trackChanges: false).ToListAsync();
        }
        

        public async Task<bool> ApproveForm(RegisterForm entity, string staffId)
        {
            entity.StaffId = Guid.Parse(staffId);
            entity.RegisterFormStatus = RegisterFormStatus.Approved;
            entity.IsDelete = false;

            bool updated = await Update(entity);

            if (updated)
            {
                await _emailService.SendEmailAsync(entity.Email, "Form Approval Notification", "Your form has been approved.");
            }

            return updated;
        }
        public async Task<RegisterForm> GetRegisterFormByIdAsync(Guid registerFormId)
        {
            return await _registerFormRepository
                .FindByCondition(r => r.Id == registerFormId, trackChanges: false)
                .FirstOrDefaultAsync();
        }
    }
}
