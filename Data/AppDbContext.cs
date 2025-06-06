using ISP2.Models.InvoiceScreen;
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
        public DbSet<Usluga> Uslugi { get; set; }
        public DbSet<Faktura> Faktury { get; set; }
        public DbSet<Wplata> Wplaty { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }
        public DbSet<TicketStatus> TicketStatuses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable("Klient");
            modelBuilder.Entity<Employee>().ToTable("Pracownik");
            modelBuilder.Entity<Ticket>().ToTable("Zgloszenie");
            modelBuilder.Entity<Faktura>().ToTable("Faktura");
            modelBuilder.Entity<Wplata>().ToTable("Wplata");

            //Client -> Rola
            modelBuilder.Entity<Client>()
                .HasOne(t => t.Rola)
                .WithMany(tt => tt.Klienci)
                .HasForeignKey(t => t.IdRola)
                .IsRequired(false);

            //Client -> Usluga
            modelBuilder.Entity<Client>()
                .HasOne(c => c.Usluga)
                .WithMany()
                .HasForeignKey(c => c.idUsluga)
                .IsRequired(false);

            //Client -> Faktura
            modelBuilder.Entity<Faktura>()
                 .HasOne(f => f.Klient)
                 .WithMany()
                 .HasForeignKey(f => f.IdKlient)
                  .OnDelete(DeleteBehavior.Cascade);

            //Faktura -> Wplata
            modelBuilder.Entity<Faktura>()
                .HasOne(f => f.Wplata)
                .WithMany()
                .HasForeignKey(f => f.IdWplata)
                .OnDelete(DeleteBehavior.Restrict);

            //Employee -> Faktura
     modelBuilder.Entity<Faktura>()
    .HasOne(f => f.Pracownik)
    .WithMany()
    .HasForeignKey(f => f.IdPracownik)
    .OnDelete(DeleteBehavior.Restrict);

            //Client -> Wplata
            modelBuilder.Entity<Wplata>()
                .HasOne(w => w.Klient)
                .WithMany() 
                .HasForeignKey(w => w.IdKlient)
                .OnDelete(DeleteBehavior.Cascade);



            //Employee -> Rola
            modelBuilder.Entity<Employee>()
                .HasOne(t => t.Rola)
                .WithMany(tt => tt.Pracownicy)
                .HasForeignKey(t => t.IdRola)
                .IsRequired(false);





            //Ticket -> TypZgloszenia
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.TypZgloszenia)
                .WithMany(tt => tt.Zgloszenia)
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