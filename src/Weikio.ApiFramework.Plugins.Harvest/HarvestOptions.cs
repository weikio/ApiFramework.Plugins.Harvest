using System;
using System.Collections.Generic;

namespace Weikio.ApiFramework.Plugins.Harvest
{
    public class HarvestOptions
    {
        public string HarvestCompany { get; set; } = "";
        public string HarvestUser { get; set; } = "";
        public string HarvestUserPassword { get; set; } = "";
        public decimal WorkDayHours { get; set; }
        public DateTime BalancePeriodStartDate { get; set; }
        public List<DateTime> Holidays { get; set; }
        public List<long> NonBalanceTasks { get; set; }
        public List<long> BalanceModeratingTasks { get; set; }
    }
}
