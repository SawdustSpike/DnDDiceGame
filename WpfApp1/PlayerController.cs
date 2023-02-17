using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class PlayerController
    {
        public static bool p1 = false;
        public static bool p2 = false;
        public static bool p3 = false;
        public static bool p4 = false;
        public static int inPlay = 0;
        public static void CheckinPlay()
        {
            int seeinPlay = 0;
            foreach (Player player in Player.players)
            {
                if (player.Folded == false)
                {
                    seeinPlay++;
                }
            }
            inPlay = seeinPlay;
        }
        public static Player CreatePlayer(string name, int gold) 
        { 
            return new Player() { Name = name, Gold = gold};
        }
        public static void Folded(Player player)
        {
            switch (player.Number)
            {
                case 1: p1 = false; break;
                case 2: p2 = false; break;
                case 3: p3 = false; break;
                case 4: p4 = false; break;
            }
            player.Folded = true;


        }
        public static Player RetrievePlayer(int playerId)
        {
            return Player.players.Where(s => s.Number== playerId).FirstOrDefault();
        }        
    }
}
