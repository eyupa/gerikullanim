using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace gerikullanim.Models
{
    public class Kullanici
    {
        public int Id { get; set; }
        [Display(Name="Adı")]
        public string Name { get; set; }
        [Display(Name="Soyadı")]
        public string LastName { get; set; }
        [Display(Name="Telefon Numarası")]
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public ICollection<Duyuru> Duyurular { get; set; }
    }
}