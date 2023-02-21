using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.TextFormatting;

namespace BauldersHoldem
{
    public class PlayerController
    {
        //these help keep track of who is at the table, and helps make sure only those who joined are shown sitting at the table.
        public static bool p1 = false;
        public static bool p2 = false;
        public static bool p3 = false;
        public static bool p4 = false;
        public static int inPlay = 0;
        public static void CheckinPlay()
        {
            //my solution to dealing with players that folded. It's a bit redundant with the "p1-p4" ways of telling how many players are still able to play, might clean up later
            inPlay = Player.players.Where(x => x.Folded = false).Count();    
            //foreach (Player player in Player.players)
            //{
            //    if (player.Folded == false)
            //    {
            //        seeinPlay++;
            //    }
            //}
            //inPlay = seeinPlay;
        }
        public static Player CreatePlayer(string name, int gold) 
        { 
            return new Player() { Name = name, Gold = gold};
        }
        public static void Folded(Player player)
        {
            //helps to keep track of who folded. Again, it could just some cleaning up, but it works for now?
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
            //simple reusable code to find individual players from the players array.
            return Player.players.FirstOrDefault(s => s.Number == playerId);
        }        
    }
}
