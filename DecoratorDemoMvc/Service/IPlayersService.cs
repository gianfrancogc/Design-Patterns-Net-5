using DecoratorDemoMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DecoratorDemoMvc.Service
{
    public interface IPlayersService
    {
        IEnumerable<Player> GetPlayersList();
    }
}
