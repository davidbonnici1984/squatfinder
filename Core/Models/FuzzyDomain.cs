using RestSharp.Deserializers;

namespace SquatFinder.Web.Core.Models
{
	public class FuzzyDomain
	{
		private const string BASE_URL = "http://";

		[DeserializeAs(Name = "domain")]
		public string Domain { get; set; }

		[DeserializeAs(Name = "domain_as_hexadecimal")]
		public string DomainAsHexadecimal { get; set; }

		[DeserializeAs(Name = "fuzzer")]
		public string AlgorithmType { get; set; }

		public bool IsDomainValid { get; set; }

		public string FullDomainUrl => $"{BASE_URL}{Domain}";
		public string RenderedImageUrl { get; set; }
	}
}