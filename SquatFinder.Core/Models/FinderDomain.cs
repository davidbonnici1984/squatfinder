namespace SquatFinder.Core.Models
{
	public class FinderDomain
	{
		private const string BASE_URL = "http://";
		
		public string Domain { get; set; }

		public AlgorithmType AlgorithmType { get; set; }

		public bool IsValidDomain { get; set; }

		public string FullDomainUrl => $"{BASE_URL}{Domain}";

		public string ScreenshotImageUrl { get; set; }
	}
}