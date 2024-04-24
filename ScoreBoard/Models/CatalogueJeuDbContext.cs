using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ScoreBoard.Models;

namespace ScoreBoard.Models
{
    public class CatalogueJeuDbContext: IdentityDbContext
    {
        public CatalogueJeuDbContext(DbContextOptions<CatalogueJeuDbContext>options) : base(options) 
        { 
            
        }

        public DbSet<Jeu> Jeus { get; set; }

        public DbSet<Joueur> Joueurs { get; set; }
    }
}
