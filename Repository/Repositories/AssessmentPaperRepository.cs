using DataAccessLayer.Abstractions;
using DataAccessLayer.Dao.Abstractions;
using Entities.Models;

namespace DataAccessLayer.Repositories;

public class AssessmentPaperRepository : IRepositoryBase<AssessmentPaper>
{
    private readonly IAssessmentPaperDao _assessmentPaperDao;

    protected AssessmentPaperRepository(IAssessmentPaperDao assessmentPaperDao)
    {
        _assessmentPaperDao = assessmentPaperDao;
    }

    public IQueryable<AssessmentPaper> FindAll() => _assessmentPaperDao.FindAll();
}