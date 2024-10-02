using RestWithASPNETUdemy.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETUdemy.Model
{
    [Table("Books")]
    public class Book : BaseEntity
    {
        [Column("author")]
        public string? author { get; set; }
        [Column("launch_date")]
        public DateTime? date { get; set; }
        [Column("price")]
        public Decimal? price { get; set; }
        [Column("title")]
        public string? title { get; set; }

    }
}
