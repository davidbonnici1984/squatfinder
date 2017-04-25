using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SquatFinder.Core.Models
{
	public class AnalysisResult
	{
		public IList<FinderDomain> DomainList { get; set; }

		public Dictionary<string, int> AlgorithmGroupedResult
		{
			get
			{
				var data = DomainList.GroupBy(c => c.AlgorithmName).ToDictionary(x => x.Key, x => x.Count());

				return data;
			}
		}

		public int TotalDomains => DomainList?.Count ?? 0;
	}

}
