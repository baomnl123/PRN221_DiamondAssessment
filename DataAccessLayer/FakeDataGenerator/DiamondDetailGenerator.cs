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
            .RuleFor(diamondDetail => diamondDetail.CaratWeight, f => f.Random.Float(0, 5))
            .RuleFor(diamondDetail => diamondDetail.Clarity, f => f.PickRandom<Quality>())
            .RuleFor(diamondDetail => diamondDetail.Cut, f => f.PickRandom<Quality>())
            .RuleFor(diamondDetail => diamondDetail.Proportions, f => f.PickRandom<Quality>())
            .RuleFor(diamondDetail => diamondDetail.Color, f => f.PickRandom<GlowStrength>())
            .RuleFor(diamondDetail => diamondDetail.Polish, f => f.PickRandom<Quality>())
            .RuleFor(diamondDetail => diamondDetail.Symmetry, f => f.PickRandom<Quality>())
            .RuleFor(diamondDetail => diamondDetail.Fluorescence, f => f.PickRandom<GlowStrength>())
            .RuleFor(diamondDetail => diamondDetail.CreatedAt, f => f.Date.Past())
            .RuleFor(diamondDetail => diamondDetail.ModifiedAt, f => f.Date.Recent())
            .RuleFor(diamondDetail => diamondDetail.IsDelete, f => f.Equals(false))
            .Generate(50)
            .ToArray();
    }
}
