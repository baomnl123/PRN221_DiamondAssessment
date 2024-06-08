using Bogus;
using Entities.Models;

namespace DataAccessLayer.FakeDataGenerator;

public static class StaffGenerator
{
    public static Staff[] InitializeDataForStaff()
    {
        return new Faker<Staff>()
            .UseSeed(1)
            .RuleFor(staff => staff.Id, f => f.Random.Guid())
            .RuleFor(staff => staff.Role, f => f.PickRandom<Role>())
            .RuleFor(staff => staff.Name, f => f.Name.FullName())
            .RuleFor(staff => staff.PhoneNumber, f => f.Phone.PhoneNumber())
            .RuleFor(staff => staff.Email, f => f.Internet.Email())
            .Generate(50)
            .ToArray();
    }
}
