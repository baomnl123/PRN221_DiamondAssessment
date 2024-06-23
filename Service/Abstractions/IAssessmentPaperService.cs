using System.Linq.Expressions;
using Entities.Models;

namespace Service.Abstractions;

public interface IAssessmentPaperService
{
    List<AssessmentPaper> FindAll();
    IQueryable<AssessmentPaper> FindByCondition(Expression<Func<AssessmentPaper, bool>> expression, bool trackChanges);
    Task<bool> Create(AssessmentPaper entity);
    Task<bool> Update(AssessmentPaper entity);
    Task<bool> Delete(AssessmentPaper entity);

}