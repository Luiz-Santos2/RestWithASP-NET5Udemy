using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RestWithASPNETUdemy.Data.VO
{
    public class BookVO
    {
        [JsonPropertyName("code")]
        public long Id { get; set; }
        [JsonPropertyName("author")]
        public string? author { get; set; }
        [JsonIgnore]
        public DateTime? date { get; set; }
        [JsonPropertyName("price")]
        public Decimal? price { get; set; }
        [JsonPropertyName("title")]
        public string? title { get; set; }
    }
}
