using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RestWithASPNETUdemy.Hypermedia.Filters
{
    public class HypermediaFilter : ResultFilterAttribute
    {
        private readonly HypermediaFilterOptions _hyperMediaFilterOptions;

        public HypermediaFilter(HypermediaFilterOptions hyperMediaFilterOptions)
        {
            _hyperMediaFilterOptions = hyperMediaFilterOptions;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            TryEnrichResult(context);
            base.OnResultExecuting(context);
        }

        private void TryEnrichResult(ResultExecutingContext context)
        {
            if (context.Result is OkObjectResult objectResult)
            {
                var enricher = _hyperMediaFilterOptions
                    .ContentResponseEnricherList.
                    FirstOrDefault(x => x.canEnricher(context));
                if (enricher != null)
                {
                    Task.FromResult(enricher.Enrich(context));
                }
            }
        }
    }
}

