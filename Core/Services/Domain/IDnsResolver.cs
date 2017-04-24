using System.Threading.Tasks;

namespace SquatFinder.Web.Core.Services.Domain
{
	public interface IDnsResolver
	{
		Task<bool> GetHostEntry(string hostname);
	}
}