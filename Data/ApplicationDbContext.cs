using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PrintingOrder.Data
{


    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public DbSet<Models.Machine> Machines { get; set; }
        public DbSet<Models.Employee> Employees { get; set; }
        public DbSet<Models.PrintOrder> PrintOrders { get; set; }
        public DbSet<Models.MachineProduction> MachineProductions { get; set; }
        public DbSet<Models.EmployeeProduction> EmployeeProductions { get; set; }
        public DbSet<Models.DailyReport> DailyReports { get; set; }
        public DbSet<Models.DailyReportItem> DailyReportItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // مثال: تخزين الحقول JSON كـ nvarchar(max) بسيط في SQL Server 2012
            //modelBuilder.Entity<Models.MachineProduction>()
            //.Property(p => p.ExecutorsJson)
            //.HasColumnType("nvarchar(max)");


            modelBuilder.Entity<Models.EmployeeProduction>()
            .Property(p => p.ShiftsJson)
            .HasColumnType("nvarchar(max)");


            modelBuilder.Entity<Models.EmployeeProduction>()
            .Property(p => p.BookletNumbersJson)
            .HasColumnType("nvarchar(max)");


            
        }
    }
}

