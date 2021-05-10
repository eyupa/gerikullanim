using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace gerikullanim.Models
{
    public class Resim
    {
        public int Id { get; set; }
        public string DosyaAdi { get; set; }
        public int DuyuruId { get; set; }  
        
        [NotMapped] 
        public IFormFile[] Dosyalar { get; set; } 
        public Duyuru Duyurusu { get; set; }
    }
}