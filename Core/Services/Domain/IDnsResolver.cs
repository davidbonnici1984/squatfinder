using System.Threading.Tasks;

namespace DnsTwisterMonitor.Core.Services.Domain
{
    public interface IDnsResolver
    {
	    Task<bool> GetHostEntry(string hostname);
    }
}
