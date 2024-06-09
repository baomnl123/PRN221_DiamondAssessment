using Bogus;
using Entities.Models;

namespace Repository.FakeDataGenerator
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
                .RuleFor(commitmentForm => commitmentForm.CreatedAt, f => f.Date.Past())
                .RuleFor(commitmentForm => commitmentForm.Status, f => f.Random.Bool())
                .Generate(50)
                .ToArray();
        }
    }
}
