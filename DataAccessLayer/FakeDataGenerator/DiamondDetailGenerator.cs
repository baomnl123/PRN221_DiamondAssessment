using Bogus;
using Entities.Models;

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
            .RuleFor(diamondDetail => diamondDetail.Measurement, f => f.Lorem.Paragraph())
            .RuleFor(diamondDetail => diamondDetail.CaratWeight, f => f.Lorem.Paragraph())
            .RuleFor(diamondDetail => diamondDetail.Clarity, f => f.Lorem.Paragraph())
            .RuleFor(diamondDetail => diamondDetail.Cut, f => f.Lorem.Paragraph())
            .RuleFor(diamondDetail => diamondDetail.Proportions, f => f.Lorem.Paragraph())
            .RuleFor(diamondDetail => diamondDetail.Color, f => f.Lorem.Paragraph())
            .RuleFor(diamondDetail => diamondDetail.Polish, f => f.Lorem.Paragraph())
            .RuleFor(diamondDetail => diamondDetail.Symmetry, f => f.Lorem.Paragraph())
            .RuleFor(diamondDetail => diamondDetail.Fluorescence, f => f.Lorem.Paragraph())
            .Generate(50)
            .ToArray();
    }
}
