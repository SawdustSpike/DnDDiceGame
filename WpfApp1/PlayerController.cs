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
        public static Player CreatePlayer(string name, int gold) 
        { 
            return new Player() { Name = name, Gold = gold};
        }

        public static Player RetrievePlayer(int playerId)
        {
            return Player.players.Where(s => s.Number== playerId).FirstOrDefault();
        }

    }
}
