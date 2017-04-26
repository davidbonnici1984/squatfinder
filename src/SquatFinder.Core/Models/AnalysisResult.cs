using System.Collections.Generic;
using System.Linq;

namespace SquatFinder.Core.Models
{
	public class AnalysisResult
	{
		public IList<FinderDomain> SearchResult { get; set; }

		public IList<AlgorithmResultsStatistics> ResultStatistics { get; set; }

		public int TotalDomains => SearchResult?.Count ?? 0;
	}

	public class AlgorithmResultsStatistics
	{
		public string Name { get; set; }
		
		public int Count { get; set; }

		public int Percentage { get; set; }
	}

}