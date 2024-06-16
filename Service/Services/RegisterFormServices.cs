using DataAccessLayer.Dao;
using DataAccessLayer.Dao.Abstractions;
using Entities.Models;
using Repository.Abstractions;
using Service.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class RegisterFormServices : IRegisterFormService
    {
        private readonly IRegisterFormRepository _registerFormRepository;

        public RegisterFormServices(IRegisterFormRepository registerFormRepository)
        {
            _registerFormRepository = registerFormRepository;
        }

        public List<RegisterForm> FindAll() => _registerFormRepository.FindAll().ToList();
    }
}
