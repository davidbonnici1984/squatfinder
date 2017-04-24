using System.Collections.Generic;
using SquatFinder.Core.Models;

namespace SquatFinder.Core.Services
{
	public interface ITwisterService
	{
		IList<FinderDomain> GetFuzzyDomains(string domain);
	}
}