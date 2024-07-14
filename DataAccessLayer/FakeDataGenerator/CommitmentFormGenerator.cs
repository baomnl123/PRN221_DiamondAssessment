using Bogus;
using Entities.Models;
using Entities.Models.Enum;

namespace DataAccessLayer.FakeDataGenerator
{
    public static class CommitmentFormGenerator
    {
        public static CommitmentForm[] InitializeDataForCommitmentForm(
            AssessmentPaper[] assessmentPapers
        )
        {
            var usedAssessmentPaperIds = new HashSet<Guid>();

            return new Faker<CommitmentForm>()
                .UseSeed(1)
                .RuleFor(commitmentForm => commitmentForm.Id, f => f.Random.Guid())
                .RuleFor(
                    commitmentForm => commitmentForm.PaperId,
                    f =>
                    {
                        var ticketId = f.PickRandom(assessmentPapers).Id;
                        while (usedAssessmentPaperIds.Contains(ticketId))
                        {
                            ticketId = f.PickRandom(assessmentPapers).Id;
                        }
                        usedAssessmentPaperIds.Add(ticketId);
                        return ticketId;
                    }
                )
                .RuleFor(
                    commitmentForm => commitmentForm.CommitmentFormStatus,
                    f => f.PickRandom<CommitmentFormStatus>()
                )
                .RuleFor(commitmentForm => commitmentForm.CreatedAt, f => f.Date.Past())
                .RuleFor(commitmentForm => commitmentForm.ModifiedAt, f => f.Date.Recent())
                .RuleFor(commitmentForm => commitmentForm.IsDelete, f => f.Equals(false))
                .Generate(50)
                .ToArray();
        }
    }
}
