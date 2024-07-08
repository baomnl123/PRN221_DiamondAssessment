using Bogus;
using Entities.Models;
using Entities.Models.Enum;

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
            .RuleFor(staff => staff.Password, f => f.Internet.Password())
            .RuleFor(staff => staff.IsDelete, f => f.Equals(false))
            .Generate(50)
            .ToArray();
    }
}
