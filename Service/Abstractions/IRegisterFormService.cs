using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstractions
{
    public interface IRegisterFormService
    {
        List<RegisterForm> FindAll();
        IQueryable<RegisterForm> FindByCondition(Expression<Func<RegisterForm, bool>> expression, bool trackChanges);
        Task<bool> Create(RegisterForm entity);
        Task<bool> Update(RegisterForm entity);
        Task<bool> Delete(RegisterForm entity);
        Task<bool> ApplyForm(RegisterForm entity, string staffId, bool isApproved);
        Task<RegisterForm> FindByEmailOrPhone(string emailOrPhone);
    }
}
