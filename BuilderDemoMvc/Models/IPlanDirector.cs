using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuilderDemoMvc.Models
{
    public interface IPlanDirector
    {
        void SetPlanBuilder(IPlanBuilder builder);

        void BuildBasicPlan();

        void BuildEnterprisePlan();
    }
}
