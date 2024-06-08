using Entities.Models;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.FakeDataGenerator;

namespace DataAccessLayer.Context;

public class RepositoryContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<AssessmentPaper>? AssessmentPapers { get; set; }
    public DbSet<CommitmentForm>? CommitmentForms { get; set; }
    public DbSet<DiamondDetail>? DiamondDetails { get; set; }
    public DbSet<RegisterForm>? RegisterForms { get; set; }
    public DbSet<SealingReport>? SealingReports { get; set; }
    public DbSet<Ticket>? Tickets { get; set; }
    public DbSet<Staff>? Staffs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Staff[] staffs = StaffGenerator.InitializeDataForStaff();
        RegisterForm[] registerForms = RegisterFormGenerator.InitializeDataForRegisterForm(staffs);
        Ticket[] tickets = TicketGenerator.InitializeDataForTicket(registerForms);
        AssessmentPaper[] assessmentPapers =
            AssessmentPaperGenerator.InitializeDataForAssessmentPaper(tickets, staffs);
        DiamondDetail[] diamondDetails = DiamondDetailGenerator.InitializeDataForDiamondDetail(
            staffs,
            tickets
        );
        CommitmentForm[] commitmentForms = CommitmentFormGenerator.InitializeDataForCommitmentForm(
            assessmentPapers
        );
        SealingReport[] sealingReports = SealingReportGenerator.InitializeDataForSealingReport(
            assessmentPapers
        );

        modelBuilder.Entity<Staff>().HasData(staffs);
        modelBuilder.Entity<RegisterForm>().HasData(registerForms);
        modelBuilder.Entity<Ticket>().HasData(tickets);
        modelBuilder.Entity<AssessmentPaper>().HasData(assessmentPapers);
        modelBuilder.Entity<DiamondDetail>().HasData(diamondDetails);
        modelBuilder.Entity<CommitmentForm>().HasData(commitmentForms);
        modelBuilder.Entity<SealingReport>().HasData(sealingReports);
    }
}
