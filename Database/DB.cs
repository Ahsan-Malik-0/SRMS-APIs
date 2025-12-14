using Microsoft.EntityFrameworkCore;
using SRMS_APIs.Models;
using static SRMS_APIs.Models.Biit_Administration;

namespace SRMS_APIs.Database
{
    public class DB : DbContext
    {
        public DB(DbContextOptions<DB> options) : base(options) { }

        // DbSet properties
        public DbSet<BiitAdministration> Biit_Administration { get; set; }
        public DbSet<FinanceCommittee> Finance_Committee { get; set; }
        public DbSet<Societies> Societies { get; set; }
        public DbSet<Members> Members { get; set; }
        public DbSet<YearlyBudget> Yearly_Budget { get; set; }
        public DbSet<PreplanedEvents> Preplaned_Events { get; set; }
        public DbSet<PreplanedEventsRequirements> Preplaned_Events_Requirements { get; set; }
        public DbSet<FinanceCommitteeBudgetScrutiny> Finance_Committee_Budget_Scrutiny { get; set; }
        public DbSet<BudgetStatus> Budget_Status { get; set; }
        public DbSet<SocietyEvents> Society_Events { get; set; }
        public DbSet<SocieyEventsRequirements> Sociey_Events_Requirements { get; set; }
        public DbSet<EventRequisitions> Event_Requisitions { get; set; }
        public DbSet<RequisitionScrutiny> Requisition_Scrutiny { get; set; }
        public DbSet<RequisitionApprovalStatus> Requisition_Approval_Status { get; set; }
        public DbSet<EventAudits> Event_Audits { get; set; }
        public DbSet<PaymentDetails> Payment_Details { get; set; }
        public DbSet<Bills> Bills { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map C# entity names to database table names
            modelBuilder.Entity<BiitAdministration>().ToTable("Biit_Administration");
            modelBuilder.Entity<FinanceCommittee>().ToTable("Finance_Committee");
            modelBuilder.Entity<Societies>().ToTable("Societies");
            modelBuilder.Entity<Members>().ToTable("Members");
            modelBuilder.Entity<YearlyBudget>().ToTable("Yearly_Budget");
            modelBuilder.Entity<PreplanedEvents>().ToTable("Preplaned_Events");
            modelBuilder.Entity<PreplanedEventsRequirements>().ToTable("Preplaned_Events_Requirements");
            modelBuilder.Entity<FinanceCommitteeBudgetScrutiny>().ToTable("Finance_Committee_Budget_Scrutiny");
            modelBuilder.Entity<BudgetStatus>().ToTable("Budget_Status");
            modelBuilder.Entity<SocietyEvents>().ToTable("Society_Events");
            modelBuilder.Entity<SocieyEventsRequirements>().ToTable("Sociey_Events_Requirements");
            modelBuilder.Entity<EventRequisitions>().ToTable("Event_Requisitions");
            modelBuilder.Entity<RequisitionScrutiny>().ToTable("Requisition_Scrutiny");
            modelBuilder.Entity<RequisitionApprovalStatus>().ToTable("Requisition_Approval_Status");
            modelBuilder.Entity<EventAudits>().ToTable("Event_Audits");
            modelBuilder.Entity<PaymentDetails>().ToTable("Payment_Details");
            modelBuilder.Entity<Bills>().ToTable("Bills");
        }
    }
}
