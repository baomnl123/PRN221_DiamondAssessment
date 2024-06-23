using Bogus;
using Entities.Models;

namespace DataAccessLayer.FakeDataGenerator;

public static class RegisterFormGenerator
{
    public static RegisterForm[] InitializeDataForRegisterForm(Staff[] staffs)
    {
        return new Faker<RegisterForm>()
            .UseSeed(1)
            .RuleFor(registerForm => registerForm.Id, f => f.Random.Guid())
            .RuleFor(registerForm => registerForm.Name, f => f.Name.FullName())
            .RuleFor(registerForm => registerForm.Description, f => f.Lorem.Paragraph())
            .RuleFor(registerForm => registerForm.PhoneNumber, f => f.Phone.PhoneNumber())
            .RuleFor(registerForm => registerForm.Email, f => f.Internet.Email())
            .RuleFor(registerForm => registerForm.StaffId, f => f.PickRandom(staffs).Id)
            .RuleFor(registerForm => registerForm.IsDelete, f => f.Random.Bool())
            .Generate(50)
            .ToArray();
    }
}
