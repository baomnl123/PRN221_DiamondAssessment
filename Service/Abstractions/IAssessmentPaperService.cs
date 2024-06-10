using Entities.Models;

namespace Service.Abstractions;

public interface IAssessmentPaperService
{
    List<AssessmentPaper> FindAll();

}