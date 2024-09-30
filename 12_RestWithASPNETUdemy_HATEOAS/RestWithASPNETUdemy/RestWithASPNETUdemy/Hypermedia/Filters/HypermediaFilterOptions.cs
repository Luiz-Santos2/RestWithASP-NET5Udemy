using RestWithASPNETUdemy.Hypermedia.Abstract;

namespace RestWithASPNETUdemy.Hypermedia.Filters
{
    public class HypermediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}
