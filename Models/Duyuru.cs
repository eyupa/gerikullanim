using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace gerikullanim.Models
{
    public class Duyuru
    {
        public int Id { get; set; }
        public string DuyuruAdi { get; set; }
        public string DuyuruAciklama { get; set; }

        [NotMapped] 
        public IFormFile[] Dosyalar { get; set; }
        public List<Resim> Resimler { get; set; }

        public Kullanici kullaniciId { get; set; }

    }
}