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
            return new Faker<CommitmentForm>()
                .UseSeed(1)
                .RuleFor(commitmentForm => commitmentForm.Id, f => f.Random.Guid())
                .RuleFor(
                    commitmentForm => commitmentForm.PaperId,
                    f => f.PickRandom(assessmentPapers).Id
                )
                .RuleFor(commitmentForm => commitmentForm.CreatedAt, f => f.Date.Past())
                .RuleFor(commitmentForm => commitmentForm.Status, f => f.Random.Bool())
                .Generate(50)
                .ToArray();
        }
    }
}
