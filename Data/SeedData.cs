using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using gerikullanim.Models;
using System.Collections.Generic;

namespace gerikullanim.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            // using (resource)
            // {
                
            // } //resource gb(çöp toplayıcı) beklenmeden yok edeilir
            using (var context = new gerikullanimContext(serviceProvider.GetRequiredService<DbContextOptions<gerikullanimContext>>()))
            {
                context.Database.Migrate(); //veritabanını oluştur
                // Ürünler tablosunda herhangi bir kayıt varsa...
                if (context.Duyurular.Any())
                {
                    return;   // hiç bir şey yapmadan methoddan çık
                }

                context.Duyurular.AddRange(
                    new Duyuru
                    {
                     
                        DuyuruAdi ="Örnek Duyuru",
                        DuyuruAciklama = "Seed data ile eklenmiş Duyuru",
                   
                    }
                );

                    if (context.Kullanicilar.Any())
                {
                    return;   
                }

                context.Kullanicilar.AddRange(
                    new Kullanici
                    {
                       
                        Name ="Örnek Kullanici",
                        
                   
                    }
                );
                context.SaveChanges();
            }
        }
    }
}