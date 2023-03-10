using DecoratorDemoMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DecoratorDemoMvc.Service
{
    public class PlayerService : IPlayersService
    {
        public IEnumerable<Player> GetPlayersList()
        {
            return new List<Player>()
        {
            new Player(){ Id = 1, Name = "Juan Mata" },
            new Player(){ Id = 2, Name = "Paul Pogba" },
            new Player(){ Id = 3, Name = "Phil Jones" },
            new Player(){ Id = 4, Name = "David de Gea" },
            new Player(){ Id = 5, Name = "Marcus Rashford" }
        };
        }
    }
}
