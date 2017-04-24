using System.Security.Cryptography;
using System.Text;
using RestSharp.Extensions.MonoHttp;

namespace DnsTwisterMonitor.Core.Services.Renders
{
    public class UrlToPngService : IImageRenderService
    {
        private const string UrlToPngBaseUrl = "http://api.url2png.com/v6/";
        private const string UrlToPngApiKey = "P7FC1E9A0D0E091";
        private const string UrlToPngPrivateKey = "S_2D799EC4593F0";
        private const int Delay = 3;

        public string GenerateImageUrl(string domainUrl)
        {
            return UrlToPng(domainUrl);
        }

        private static string UrlToPng(string urlToSite)
        {
            var url = HttpUtility.UrlEncode(urlToSite);

            var parameters = $"delay={Delay}&fullpage=0&url={url}";

            var securityHashUrl2Png = Md5HashPhpCompliant($"{UrlToPngPrivateKey}{parameters}").ToLower();

            var url2PngLink = $"{UrlToPngBaseUrl}{UrlToPngApiKey}/{securityHashUrl2Png}/png/?{parameters}";

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