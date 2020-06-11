using inventaireWPF.Model;
using Microsoft.EntityFrameworkCore;

namespace inventaireWPF.Tools
{
    public class InventaireDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\Inventaire;Integrated Security=True");
        }

        public DbSet<Article> Article { get; set; }
        public DbSet<Categorie> Categorie { get; set; }
    }
}

