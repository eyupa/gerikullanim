using Microsoft.EntityFrameworkCore;
    using gerikullanim.Models;
    
namespace gerikullanim.Data
{

    
    public class gerikullanimContext : DbContext
    {
        public gerikullanimContext(DbContextOptions<gerikullanimContext> options)
        : base(options)
        {

        }
        public DbSet<Duyuru> Duyurular { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Resim> Resimler { get; set; }

    }
}
