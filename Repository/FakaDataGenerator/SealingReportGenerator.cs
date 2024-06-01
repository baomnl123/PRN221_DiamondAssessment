namespace Repository.FakeDataGenerator
{
    using Bogus;
    using Entities.Models;

    public static class SealingReportGenerator
    {
        public static SealingReport[] InitializeDataForSealingReport(
            AssessmentPaper[] assessmentPapers
        )
        {
            return new Faker<SealingReport>()
                .UseSeed(1)
                .RuleFor(sealingReport => sealingReport.Id, f => f.Random.Guid())
                .RuleFor(
                    sealingReport => sealingReport.PaperId,
                    f => f.PickRandom(assessmentPapers).Id
                )
                .RuleFor(sealingReport => sealingReport.CreatedAt, f => f.Date.Past())
                .RuleFor(sealingReport => sealingReport.Status, f => f.Random.Bool())
                .Generate(50)
                .ToArray();
        }
    }
}
