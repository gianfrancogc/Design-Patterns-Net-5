using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyDemoMvc.Strategy
{
    public interface IShippingContext
    {
        void SetStrategy(IShippingStrategy strategy);

        decimal ExecuteStrategy(decimal orderTotal);
    }
}
