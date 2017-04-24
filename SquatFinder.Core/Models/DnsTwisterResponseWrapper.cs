using System.Collections.Generic;
using RestSharp.Deserializers;

namespace SquatFinder.Core.Models
{
	public class DnsTwisterResponseWrapper
	{
		[DeserializeAs(Name = "domain")]
		public string Domain { get; set; }

		[DeserializeAs(Name = "domain_as_hexadecimal")]
		public string DomainAsHexadecimal { get; set; }

		[DeserializeAs(Name = "fuzzy_domains")]
		public List<DnsTwisterDomain> FuzzyDomainList { get; set; }
	}
}