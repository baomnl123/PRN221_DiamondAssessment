using Repository.Abstractions;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public string TestService()
        {
            return _assessmentPaperRepository.TestRepo();
        }
    }
}
