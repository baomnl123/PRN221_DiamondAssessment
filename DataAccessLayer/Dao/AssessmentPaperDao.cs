using Entities.Models;
using DataAccessLayer.Context;
using DataAccessLayer.Dao.Abstractions;

namespace DataAccessLayer.Dao;

public class AssessmentPaperDao : DaoBase<AssessmentPaper>, IAssessmentPaperDao
{
    public AssessmentPaperDao(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

}