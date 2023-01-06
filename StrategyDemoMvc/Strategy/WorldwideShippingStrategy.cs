using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyDemoMvc.Strategy
{
    public class WorldwideShippingStrategy : IShippingStrategy
    {
        public decimal CalculateFinalTotal(decimal orderTotal)
        {
            return orderTotal + 50;
        }
    }
}
