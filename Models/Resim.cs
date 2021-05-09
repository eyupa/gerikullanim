namespace gerikullanim.Models
{
    public class Resim
    {
        public int Id { get; set; }
        public string DosyaAdi { get; set; }
        public int DuyuruId { get; set; }   
        public Duyuru  Duyurusu { get; set; }
    }
}