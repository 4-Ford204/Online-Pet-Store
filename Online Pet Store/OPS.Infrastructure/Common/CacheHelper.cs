using Microsoft.AspNetCore.Http;
using System.Text;

namespace OPS.Infrastructure.Common
{
    public static class CacheHelper
    {
        public static string GenerateKey(HttpRequest request)
        {
            var builder = new StringBuilder();
            builder.Append(request.Path.ToString());

            foreach (var (key, value) in request.Query.OrderBy(x => x.Key))
            {
                builder.Append($"|{key}-{value}");
            }

            return builder.ToString();
        }
    }
}
