using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace gerikullanim.Models
{
    public class Duyuru
    {
        public int Id { get; set; }
        [Display(Name="Başlık")]
        public string DuyuruAdi { get; set; }
        [Display(Name="Açıklamalar")]
        public string DuyuruAciklama { get; set; }

        public ICollection<Resim> Resimler { get; set; }
        public int KullaniciId { get; set; }

        public Kullanici Kullanici { get; set; }

    }
}