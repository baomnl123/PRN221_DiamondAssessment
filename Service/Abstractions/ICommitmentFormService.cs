using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstractions
{
    public interface ICommitmentFormService
    {
        List<CommitmentForm> FindAll();
        IQueryable<CommitmentForm> FindByCondition(Expression<Func<CommitmentForm, bool>> expression, bool trackChanges);
        Task<bool> Create(CommitmentForm entity);
        Task<bool> Update(CommitmentForm entity);
        Task<bool> Delete(CommitmentForm entity);
    }
}
