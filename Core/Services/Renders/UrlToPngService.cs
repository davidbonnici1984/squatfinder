using System.Security.Cryptography;
using System.Text;
using RestSharp.Extensions.MonoHttp;

namespace DnsTwisterMonitor.Core.Services.Renders
{
    public class UrlToPngService : IImageRenderService
    {
        private const string Url2PngApiKey = "P7FC1E9A0D0E091";
        private const string Url2PngPrivateKey = "S_2D799EC4593F0";
        private const int Delay = 3;

        public string GenerateImageUrl(string domainUrl)
        {
            return UrlToPng(domainUrl);
        }

        private static string UrlToPng(string urlToSite)
        {
            var url = HttpUtility.UrlEncode(urlToSite);

            var parameters = $"delay={Delay}&fullpage=0&url={url}";

            var securityHashUrl2Png = Md5HashPhpCompliant($"{Url2PngPrivateKey}{parameters}").ToLower();

            var url2PngLink = $"http://api.url2png.com/v6/{Url2PngApiKey}/{securityHashUrl2Png}/png/?{parameters}";

            return url2PngLink;
        }

        private static string Md5HashPhpCompliant(string pass)
        {
            var dataMd5 = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(pass));
            var sb = new StringBuilder();

            for (var i = 0; i <= dataMd5.Length - 1; i++)
            {
                sb.AppendFormat("{0:x2}", dataMd5[i]);
            }
            return sb.ToString();
        }

    }
}