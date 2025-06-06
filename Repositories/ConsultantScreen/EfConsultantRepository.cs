using ISP2.Data;
using ISP2.Models.ConsultantScreen;
using ISP2.Models.LoginScreen;
using Microsoft.EntityFrameworkCore;

namespace ISP2.Repositories.ConsultantScreen
{
    public class EfConsultantRepository : IConsultantRepository
    {
        private readonly AppDbContext _context;

        public EfConsultantRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserSearchRequest>> SearchUsersAsync(string? query)
        {

            var clients = await _context.Clients
         .Where(k => k.Login == query || k.Imie == query || k.Nazwisko == query || k.Imie + ' ' + k.Nazwisko == query)
         .Select(k => new UserSearchRequest
         {
             Login = k.Login,
             Imie = k.Imie,
             Nazwisko = k.Nazwisko,
             Wiek = k.Wiek,
             Email = k.Email,
             Telefon = k.Telefon,
             NazwaUslugi = k.Usluga != null ? k.Usluga.NazwaUslugi : null,
             Rola = k.Rola != null ? k.Rola.Rola : null,
             Pesel = k.Pesel,
             Typ = "Klient"

         })
         .ToListAsync();

            var employees = await _context.Employees

                .Where(p => p.Login == query || p.Imie == query || p.Nazwisko == query || p.Imie + ' ' + p.Nazwisko == query)
                .Select(p => new UserSearchRequest
                {
                    Login = p.Login,
                    Imie = p.Imie,
                    Nazwisko = p.Nazwisko,
                    Wiek = p.Wiek,
                    Email = p.Email,
                    Telefon = p.Telefon,
                    NazwaUslugi = null,
                    Rola = p.Rola != null ? p.Rola.Rola : null,
                    Pesel = p.Pesel,
                    Typ = "Pracownik"
                })
                .ToListAsync();

            return clients.Concat(employees).ToList();






        }
    }
}