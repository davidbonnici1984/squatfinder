using System.Collections.Generic;
using SquatFinder.Web.Core.Models;

namespace SquatFinder.Web.Core.Services
{
	public interface ITwisterService
	{
		IList<FinderDomain> GetFuzzyDomains(string domain);
	}
}