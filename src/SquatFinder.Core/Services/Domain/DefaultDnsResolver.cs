using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace SquatFinder.Core.Services.Domain
{
	public class DefaultDnsResolver : IDnsResolver
	{
		public async Task<bool> GetHostEntry(string hostname)
		{
			try
			{
				Debug.WriteLine($"Dns Resolving for {hostname}");

				if (string.IsNullOrWhiteSpace(hostname) || hostname.Length > 255) return false;

				var host = await Dns.GetHostEntryAsync(hostname);

				Debug.WriteLine($"Dns Resolving completd for {hostname}");

				return host.Aliases.Length > 0 || host.AddressList.Length > 0;
			}
			catch
			{
				return false;
			}
		}
	}
}