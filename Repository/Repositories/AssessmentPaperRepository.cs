using Repository.Abstractions;
using DataAccessLayer.Dao.Abstractions;
using Entities.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories;

public class AssessmentPaperRepository : IAssessmentPaperRepository
{
    private readonly IAssessmentPaperDao _assessmentPaperDao;

    public AssessmentPaperRepository(IAssessmentPaperDao assessmentPaperDao)
    {
        _assessmentPaperDao = assessmentPaperDao;
    }

    public IQueryable<AssessmentPaper> FindAll() => _assessmentPaperDao
        .FindAll()
        .Where(e => e.IsDelete == false)
        .Include(e => e.Staff)
        .Include(e => e.Ticket);

    public IQueryable<AssessmentPaper> FindByCondition(Expression<Func<AssessmentPaper, bool>> expression,
        bool trackChanges)
        => _assessmentPaperDao.FindByCondition(expression, trackChanges);

    public async Task<bool> Create(AssessmentPaper entity) => await _assessmentPaperDao.Create(entity);

    public async Task<bool> Update(AssessmentPaper entity) => await _assessmentPaperDao.Update(entity);

    public async Task<bool> Delete(AssessmentPaper entity) => await _assessmentPaperDao.Delete(entity);
    
}