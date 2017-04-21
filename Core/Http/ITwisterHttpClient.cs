using DnsTwisterMonitor.Core.Models;

namespace DnsTwisterMonitor.Core.Http
{
    public interface ITwisterHttpClient
    {
        TwisterResponseWrapper GetFuzzyDomains(string domainName);
    }
}

