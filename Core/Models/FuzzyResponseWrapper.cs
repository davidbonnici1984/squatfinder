using System.Collections.Generic;
using RestSharp.Deserializers;

namespace DnsTwisterMonitor.Core.Models
{
	public class FuzzyResponseWrapper
	{
		[DeserializeAs(Name = "domain")]
		public string Domain { get; set; }

		[DeserializeAs(Name = "domain_as_hexadecimal")]
		public string DomainAsHexadecimal { get; set; }

		[DeserializeAs(Name = "fuzzy_domains")]
		public List<FuzzyDomain> FuzzyDomainList { get; set; }
	}
}