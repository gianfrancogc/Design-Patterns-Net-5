using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuilderDemoMvc.Models
{
    public interface IPlanBuilder
    {
        void BuildDiskSpaceFeature();
        void BuildDatabaseFeature();
        void BuildBandwidthFeature();
        void BuildSslFeature();

        Plan GetPlan();
    }
}
