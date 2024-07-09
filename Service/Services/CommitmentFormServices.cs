using Entities.Models;
using Repository.Abstractions;
using Repository.Repositories;
using Service.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CommitmentFormServices : ICommitmentFormService
    {
        private readonly ICommitmentFormRepository _commitmentFormRepository;

        public CommitmentFormServices(ICommitmentFormRepository commitmentFormRepository)
        {
            _commitmentFormRepository = commitmentFormRepository;
        }

        public Task<bool> Create(CommitmentForm entity)
        => _commitmentFormRepository.Create(entity);

        public Task<bool> Delete(CommitmentForm entity)
        => _commitmentFormRepository.Delete(entity);

        public List<CommitmentForm> FindAll()
        => _commitmentFormRepository.FindAll().ToList();

        public IQueryable<CommitmentForm> FindByCondition(Expression<Func<CommitmentForm, bool>> expression, bool trackChanges)
        => _commitmentFormRepository.FindByCondition(expression, trackChanges);

        public Task<bool> Update(CommitmentForm entity)
        => _commitmentFormRepository.Update(entity);
    }
}
