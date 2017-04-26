using System.Collections.Generic;
using SquatFinder.Core.Models;

namespace SquatFinder.Core.Services
{
	public interface ITwisterService
	{
		AnalysisResult GetFuzzyDomains(string domain);
	}
}