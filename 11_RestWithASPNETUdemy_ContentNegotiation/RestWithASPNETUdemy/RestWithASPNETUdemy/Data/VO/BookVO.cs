using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETUdemy.Data.VO
{
    public class BookVO
    {
        public long Id { get; set; }
        public string? author { get; set; }
        public DateTime? date { get; set; }
        public Decimal? price { get; set; }
        public string? title { get; set; }
    }
}
