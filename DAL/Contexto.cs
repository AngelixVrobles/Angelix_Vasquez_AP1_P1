using Microsoft.EntityFrameworkCore;
using Angelix_Vasquez_AP1_P1.Models;

namespace Angelix_Vasquez_AP1_P1.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Aportes> Aportes { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }
    }
}

  

