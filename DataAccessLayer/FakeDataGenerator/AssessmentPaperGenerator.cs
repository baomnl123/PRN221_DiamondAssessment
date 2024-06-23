using Bogus;
using Entities.Models;
using Entities.Models.Enum;

namespace DataAccessLayer.FakeDataGenerator;

public static class AssessmentPaperGenerator
{
    public static AssessmentPaper[] InitializeDataForAssessmentPaper(
        Ticket[] tickets,
        Staff[] staffs
    )
    {
        var usedTicketIds = new HashSet<Guid>();

        return new Faker<AssessmentPaper>()
            .UseSeed(1)
            .RuleFor(assessmentPaper => assessmentPaper.Id, f => f.Random.Guid())
            .RuleFor(
                assessmentPaper => assessmentPaper.TicketId,
                f =>
                {
                    var ticketId = f.PickRandom(tickets).Id;
                    while (usedTicketIds.Contains(ticketId))
                    {
                        ticketId = f.PickRandom(tickets).Id;
                    }
                    usedTicketIds.Add(ticketId);
                    return ticketId;
                }
            )
            .RuleFor(assessmentPaper => assessmentPaper.StaffId, f => f.PickRandom(staffs).Id)
            .RuleFor(assessmentPaper => assessmentPaper.PaperCode, f => f.Lorem.Paragraph())
            .RuleFor(assessmentPaper => assessmentPaper.CreatedAt, f => f.Date.Past())
            .RuleFor(assessmentPaper => assessmentPaper.Origin, f => f.Lorem.Paragraph())
            .RuleFor(assessmentPaper => assessmentPaper.CaratWeight, f => f.Random.Float(0, 5))
            .RuleFor(assessmentPaper => assessmentPaper.Clarity, f => f.PickRandom<Quality>())
            .RuleFor(assessmentPaper => assessmentPaper.Cut, f => f.PickRandom<Quality>())
            .RuleFor(assessmentPaper => assessmentPaper.Proportions, f => f.PickRandom<Quality>())
            .RuleFor(assessmentPaper => assessmentPaper.Color, f => f.PickRandom<GlowStrength>())
            .RuleFor(assessmentPaper => assessmentPaper.Polish, f => f.PickRandom<Quality>())
            .RuleFor(assessmentPaper => assessmentPaper.Symmetry, f => f.PickRandom<Quality>())
            .RuleFor(
                assessmentPaper => assessmentPaper.Fluorescence,
                f => f.PickRandom<GlowStrength>()
            )
            .RuleFor(assessmentPaper => assessmentPaper.IsDelete, f => f.Random.Bool())
            .Generate(50)
            .ToArray();
    }
}
