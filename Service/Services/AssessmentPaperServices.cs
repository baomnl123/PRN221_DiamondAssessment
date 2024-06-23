using System.Linq.Expressions;
using Repository.Abstractions;
using Entities.Models;
using Service.Abstractions;

namespace Service.Services
{
    public class AssessmentPaperServices : IAssessmentPaperService
    {
        private readonly IAssessmentPaperRepository _assessmentPaperRepository;
        public AssessmentPaperServices(IAssessmentPaperRepository assessmentPaperRepository)
        {
            _assessmentPaperRepository = assessmentPaperRepository;
        }

        public List<AssessmentPaper> FindAll()
        {
            var list = _assessmentPaperRepository
                .FindAll()
                .Where(p => p.Status == true)
                .ToList();
            return list;
        }

        public IQueryable<AssessmentPaper> FindByCondition(Expression<Func<AssessmentPaper, bool>> expression, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Create(AssessmentPaper entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(AssessmentPaper entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(AssessmentPaper entity)
        {
            throw new NotImplementedException();
        }
    }
}
