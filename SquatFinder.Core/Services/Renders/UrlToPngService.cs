using System.Security.Cryptography;
using System.Text;
using RestSharp.Extensions.MonoHttp;

namespace SquatFinder.Core.Services.Renders
{
	public class UrlToPngService : IImageRenderService
	{
		private const string BASE_URL = "http://api.url2png.com/v6/";
		private const string API_KEY = "P7FC1E9A0D0E091";
		private const string PRIVATE_KEY = "S_2D799EC4593F0";
		private const int DELAY = 3;

		public string GenerateImageUrl(string domainUrl)
		{
			return UrlToPng(domainUrl);
		}

		private static string UrlToPng(string urlToSite)
		{
			var url = HttpUtility.UrlEncode(urlToSite);

			var parameters = $"delay={DELAY}&fullpage=0&url={url}";

			var securityHashUrl2Png = Md5HashPhpCompliant($"{PRIVATE_KEY}{parameters}").ToLower();

			var url2PngLink = $"{BASE_URL}{API_KEY}/{securityHashUrl2Png}/png/?{parameters}";

			return url2PngLink;
		}

		private static string Md5HashPhpCompliant(string pass)
		{
			var dataMd5 = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(pass));
			var sb = new StringBuilder();

			for (var i = 0; i <= dataMd5.Length - 1; i++)
				sb.AppendFormat("{0:x2}", dataMd5[i]);
			return sb.ToString();
		}
	}
}