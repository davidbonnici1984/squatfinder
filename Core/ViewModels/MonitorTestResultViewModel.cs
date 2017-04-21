using System.Collections.Generic;

namespace DnsTwisterMonitor.Core.ViewModels
{
    public class MonitorTestResultViewModel
    {
        public string DomainMonitored { get; set; }

        public int TotalCombinations => MonitorTestViewList.Count;

        public IList<DomainFuzzerType> DomainFuzzerTypesList { get; set; }

        public IList<MonitorTestViewModel> MonitorTestViewList { get; set; }
    }

}