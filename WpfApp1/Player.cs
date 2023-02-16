using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Player
    {
        public static List<Player> players = new List<Player>();
        public Player()
        {            
            Player.players.Add(this);
        }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Score { get; set; }
        public int[] Dice { get; set; }
        public int Gold { get; set; }
        public int CurrentBid { get; set; }
    }
}
