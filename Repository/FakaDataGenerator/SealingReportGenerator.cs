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
            var usedAssessmentPaperIds = new HashSet<Guid>();

            return new Faker<SealingReport>()
                .UseSeed(1)
                .RuleFor(sealingReport => sealingReport.Id, f => f.Random.Guid())
                .RuleFor(
                    sealingReport => sealingReport.PaperId,
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
                .RuleFor(sealingReport => sealingReport.CreatedAt, f => f.Date.Past())
                .RuleFor(sealingReport => sealingReport.Status, f => f.Random.Bool())
                .Generate(50)
                .ToArray();
        }
    }
}
