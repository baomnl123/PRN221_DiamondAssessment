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
                .ToList();
            return list;
        }

        public IQueryable<AssessmentPaper> FindByCondition(Expression<Func<AssessmentPaper, bool>> expression, bool trackChanges)
        {
            return _assessmentPaperRepository.FindByCondition(expression, trackChanges);
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
            entity.IsDelete = true;
            return _assessmentPaperRepository.Update(entity);
        }
    }
}
