using RestWithASPNETUdemy.Hypermedia;
using RestWithASPNETUdemy.Hypermedia.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETUdemy.Data.VO
{
    public class BookVO : ISupportHypermidia
    {
        public long Id { get; set; }
        public string? author { get; set; }
        public DateTime? date { get; set; }
        public Decimal? price { get; set; }
        public string? title { get; set; }
        public List<HypermediaLink> Links { get; set; } = new List<HypermediaLink>();
    }
}
