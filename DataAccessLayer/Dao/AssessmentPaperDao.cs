using Entities.Models;
using DataAccessLayer.Context;
using DataAccessLayer.Dao.Abstractions;

namespace DataAccessLayer.Dao;

public class AssessmentPaperDao : DaoBase<AssessmentPaper>, IAssessmentPaperDao
{
    protected AssessmentPaperDao(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}