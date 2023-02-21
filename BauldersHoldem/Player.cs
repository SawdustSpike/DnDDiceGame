using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BauldersHoldem
{
    public class Player
    {
        public static List<Player> players = new List<Player>();
    
        public Player() 
        {
            players.Add(this);
        }
        public int[] BestFive { get; set; }
        public int CurrentBid { get; set; }
        public int[] Dice { get; set; }
        public bool Folded { get; set; } = false;
        public int Gold { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }        
        public string Score { get; set; }        
    }
}
