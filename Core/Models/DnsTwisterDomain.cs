using RestSharp.Deserializers;

namespace SquatFinder.Web.Core.Models
{
	public class DnsTwisterDomain
	{
		[DeserializeAs(Name = "domain")]
		public string Domain { get; set; }

		[DeserializeAs(Name = "domain_as_hexadecimal")]
		public string DomainAsHexadecimal { get; set; }

		[DeserializeAs(Name = "fuzzer")]
		public string AlgorithmType { get; set; }
	}
}