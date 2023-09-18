namespace BoynerCase.Models
{
    public class Product : BaseEntity
    {
        public string UrunIsmi { get; set; }
        public string Aciklama { get; set; }
        public int? KategoriId { get; set; }
    }
}
