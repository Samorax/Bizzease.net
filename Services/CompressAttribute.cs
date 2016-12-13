using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc.Filters;
using System;
using System.Linq;

namespace WebApplication_Webease_.Services
{
    public sealed class CompressAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var preferredEncoding = GetPreferredEncoding(context.HttpContext.Request);

            var compressedResponse = context.HttpContext.Response;
            compressedResponse.Headers.Add("Content-Encoding", preferredEncoding.ToString());
        }

        private CompressionScheme GetPreferredEncoding(HttpRequest request)
        {
            var acceptableEncoding = request.Headers["Accept-Encoding"].ToString().ToLower();
            acceptableEncoding = SortEncodings(acceptableEncoding);
            if (acceptableEncoding.Contains("gzip"))
                return CompressionScheme.Gzip;
            if (acceptableEncoding.Contains("deflate"))
                return CompressionScheme.Deflate;
            return CompressionScheme.Identity;
            
        }

        private static string SortEncodings(string acceptableEncodings)
        {
            var preferredEncoding = "";
            if (acceptableEncodings.Contains(","))
            {
                var splittedString = acceptableEncodings.Split(new Char[] { ',' });
                if (splittedString.Contains("gzip"))
                    preferredEncoding = "gzip";
            }

            return preferredEncoding;
        }
        enum CompressionScheme
        {
            Gzip = 1,
            Deflate = 2,
            Identity = 3

        }
    }
}
