using RestSharp.Deserializers;

namespace DnsTwisterMonitor.Core.Models
{
    public class TwisterFuzzyDomain
    {
        [DeserializeAs(Name = "domain")]
        public string Domain { get; set; }

        [DeserializeAs(Name = "domain_as_hexadecimal")]
        public string DomainAsHexadecimal { get; set; }

        [DeserializeAs(Name = "fuzzer")]
        public string FuzzerType { get; set; }
    }
}