using System.Threading.Tasks;

namespace SquatFinder.Core.Services.Domain
{
	public interface IDnsResolver
	{
		Task<bool> GetHostEntry(string hostname);
	}
}