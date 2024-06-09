using Bogus;
using Entities.Models;

namespace Repository.FakeDataGenerator;

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
            .RuleFor(assessmentPaper => assessmentPaper.Measurement, f => f.Lorem.Paragraph())
            .RuleFor(assessmentPaper => assessmentPaper.CaratWeight, f => f.Lorem.Paragraph())
            .RuleFor(assessmentPaper => assessmentPaper.Clarity, f => f.Lorem.Paragraph())
            .RuleFor(assessmentPaper => assessmentPaper.Cut, f => f.Lorem.Paragraph())
            .RuleFor(assessmentPaper => assessmentPaper.Proportions, f => f.Lorem.Paragraph())
            .RuleFor(assessmentPaper => assessmentPaper.Color, f => f.Lorem.Paragraph())
            .RuleFor(assessmentPaper => assessmentPaper.Polish, f => f.Lorem.Paragraph())
            .RuleFor(assessmentPaper => assessmentPaper.Symmetry, f => f.Lorem.Paragraph())
            .RuleFor(assessmentPaper => assessmentPaper.Fluorescence, f => f.Lorem.Paragraph())
            .RuleFor(assessmentPaper => assessmentPaper.Status, f => f.Random.Bool())
            .Generate(50)
            .ToArray();
    }
}
