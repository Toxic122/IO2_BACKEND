using ISP2.Models.LoginScreen;
using ISP2.Models.ServiceScreen;
using ISP2.ModelsDict;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;


namespace ISP2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }
        public DbSet<TicketStatus> TicketStatuses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable("Klient");
            modelBuilder.Entity<Employee>().ToTable("Pracownik");
            modelBuilder.Entity<Ticket>().ToTable("Zgloszenie");



            //Ticket -> TypZgloszenia
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.TypZgloszenia)
                .WithMany(tt =>tt.Zgloszenia)
                .HasForeignKey(t => t.IdTypZgloszenia);

            //Ticket -> Status
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Status)
                .WithMany(s => s.Zgloszenia)
                .HasForeignKey(t => t.IdStatus);

            //Ticket -> Klient
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.ClientLogin)
                .WithMany()
                .HasForeignKey(t => t.IdKlient);

            //Ticket -> Pracownik
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.EmployeeLogin)
                .WithMany()
                .HasForeignKey(t => t.IdPracownik);




        }
    }
}
