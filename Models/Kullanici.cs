using System.Collections.Generic;

namespace gerikullanim.Models
{
    public class Kullanici
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public List<Duyuru> Duyurulari { get; set; }
    }
}