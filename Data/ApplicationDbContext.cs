using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PrintingOrder.Models;

namespace PrintingOrder.Data
{


    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public DbSet<Models.Store> Stores { get; set; }
        public DbSet<Models.Category> Categories { get; set; }
        public DbSet<Models.Item> Items { get; set; }
        public DbSet<Models.Unit> Units { get; set; }
        public DbSet<Models.Customer> Customers { get; set; }
        public DbSet<Models.Delegate> Delegates { get; set; }
        public DbSet<Models.Employee> Employees { get; set; }
        public DbSet<Models.Machine> Machines { get; set; }
        public DbSet<Models.PrintSize> PrintSizes { get; set; }
        public DbSet<Models.PrintOrder> PrintOrders { get; set; }
        public DbSet<Models.PrintSignature> PrintSignatures { get; set; }
        public DbSet<Models.PrintOrderRequiredItem> PrintOrderRequiredItems { get; set; }
        public DbSet<Models.MachineProduction> MachineProductions { get; set; }
        public DbSet<Models.ProductionConsumedItem> ProductionConsumedItems { get; set; }
        public DbSet<Models.EmployeeProduction> EmployeeProductions { get; set; }
        public DbSet<Models.ProductionSignatureDetail> EmployeeProductionDetails { get; set; }
        public ICollection<DeliveryToStore>? Deliveries { get; set; }
        public ICollection<PrintOrderDelivery>? PrintOrderDeliveries { get; set; }
        public DbSet<Models.PaymentClaim>? PaymentClaims { get; set; }
        public DbSet<Models.PrintOrderCalimPayment>? PrintOrderCalimPayments { get; set; }

        public DbSet<Models.DailyReport> DailyReports { get; set; }
        public DbSet<Models.DailyReportItem> DailyReportItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Models.EmployeeProduction>()
            .Property(p => p.Shifts)
            .HasColumnType("nvarchar(max)");

            

            






        }
    }
}

