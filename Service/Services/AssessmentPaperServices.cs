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

        public List<AssessmentPaper> FindAll() => _assessmentPaperRepository.FindAll().ToList();
        
        
    }
}
