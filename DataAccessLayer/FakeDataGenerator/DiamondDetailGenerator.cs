using Bogus;
using Entities.Models;
using Entities.Models.Enum;

namespace DataAccessLayer.FakeDataGenerator;

public static class DiamondDetailGenerator
{
    public static DiamondDetail[] InitializeDataForDiamondDetail(Staff[] staffs, Ticket[] tickets)
    {
        return new Faker<DiamondDetail>()
            .UseSeed(1)
            .RuleFor(diamondDetail => diamondDetail.Id, f => f.Random.Guid())
            .RuleFor(diamondDetail => diamondDetail.StaffId, f => f.PickRandom(staffs).Id)
            .RuleFor(diamondDetail => diamondDetail.TicketId, f => f.PickRandom(tickets).Id)
            .RuleFor(diamondDetail => diamondDetail.Origin, f => f.Lorem.Paragraph())
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
