namespace DataAccessLayer.FakeDataGenerator
{
    using Bogus;
    using Entities.Models;
    using Entities.Models.Enum;

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
                .RuleFor(
                    sealingReport => sealingReport.SealingReportStatus,
                    f => f.PickRandom<SealingReportStatus>()
                )
                .RuleFor(sealingReport => sealingReport.CreatedAt, f => f.Date.Past())
                .RuleFor(sealingReport => sealingReport.ModifiedAt, f => f.Date.Recent())
                .RuleFor(sealingReport => sealingReport.IsDelete, f => f.Equals(false))
                .Generate(50)
                .ToArray();
        }
    }
}
