using RestSharp.Deserializers;

namespace DnsTwisterMonitor.Core.Models
{
	public class FuzzyDomain
	{
		[DeserializeAs(Name = "domain")]
		public string Domain { get; set; }

		[DeserializeAs(Name = "domain_as_hexadecimal")]
		public string DomainAsHexadecimal { get; set; }

		[DeserializeAs(Name = "fuzzer")]
		public string AlgorithmType { get; set; }

		public bool IsDomainValid { get; set; }

		public string FullDomainUrl => $"http://{Domain}";
	    public string RenderedImageUrl { get; set; }

	}
}