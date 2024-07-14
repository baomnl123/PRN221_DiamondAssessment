using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstractions
{
    public interface ISealingReportService
    {
        List<SealingReport> FindAll();
        IQueryable<SealingReport> FindByCondition(Expression<Func<SealingReport, bool>> expression, bool trackChanges);
        Task<bool> Create(SealingReport entity);
        Task<bool> Update(SealingReport entity);
        Task<bool> Delete(SealingReport entity);
        Task<Guid?> GetSealingReportIdByPaperIdAsync(Guid paperId);
    }
}
