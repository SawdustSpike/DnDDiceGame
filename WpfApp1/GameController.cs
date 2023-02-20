using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;


namespace WpfApp1
{
    public class GameController
    {
        public static bool startReady = false;
        public static int startingPlayer = -1;
        public static int pot = 0;
        public static int bet = 0;
        public static int rotate = 0;
        public static bool canCheck = true;
        public static bool flop = false;
        public static List<int> commDice = new List<int>();
        public static void AssignStartingPlayer()
        {
            var ran = new Random();
            if (startingPlayer == -1) // Checks to see if starting player has been selected, if not
            {
                startingPlayer = ran.Next(0, Player.players.Count); //Randomly assigns starting player
            }
            else
            {
                startingPlayer++; //If this is not the first time through it rotates deal one player clockwise
                if(startingPlayer >= Player.players.Count)
                {
                    startingPlayer = 0; // Keeps rotation in bounds of Array
                }
            }
        }
        public static void BestFive(Player player)
        {
            var allSeven = new List<int>()
            { player.Dice[0], player.Dice[1], commDice[0], commDice[1], commDice[2], commDice[3], commDice[4]};
            allSeven.Sort();
            
            //finds the best five dice out of the seven available, saves them in the players BestFive atribute and also give player scores(starting with numbers for ranking sake)
            //Considering chopping this one up into more methods since it's SO big
            if (allSeven.Contains(2) && allSeven.Contains(3) && allSeven.Contains(4) && allSeven.Contains(5) && allSeven.Contains(6)) { player.BestFive = new int[] { 2, 3, 4, 5, 6 }; player.Score = "3Straight"; return; }
            else if (allSeven.Contains(1) && allSeven.Contains(2) && allSeven.Contains(3) && allSeven.Contains(4) && allSeven.Contains(5)) { player.BestFive = new int[] { 1, 2, 3, 4, 5 }; player.Score = "3Straight"; return; }

            var res = new Dictionary<int, int>();
            for (int i = 0; i < 7; i++)
            {
                if (res.ContainsKey(allSeven[i]))
                {
                    res[allSeven[i]]++;
                }
                else
                {
                    res.Add(allSeven[i], 1);
                }
            }
            if (res.ContainsValue(5))
            {
                var x = res.FirstOrDefault(y => y.Value == 5).Key;
                player.BestFive = new int[] { x, x, x, x, x };
                player.Score = "1Five Of A Kind";
                return;
            }
            else if (res.ContainsValue(4))
            {
                var x = res.FirstOrDefault(a => a.Value == 4).Key;
                var y = new int[5] { 0, x, x, x, x, };
                for (int i = 6; i >= 0; i--)
                {
                    if (!y.Contains(allSeven[i]))
                    {
                        y[0] = allSeven[i];
                        player.BestFive = y;
                        player.Score = "2 Four Of A Kind";
                        return;

                    }
                }
            }
            else if (res.ContainsValue(3) && res.ContainsValue(2))
            {
                var x = res.FirstOrDefault(a => a.Value == 3).Key;
                var y = new int[5] { 0, 0, x, x, x };
                var z = new List<int>();
                foreach (var kvp in res)
                {
                    if (kvp.Value == 2)
                    {
                        z.Add(kvp.Key);
                    }
                }
                z.Sort();

                y[0] = z[z.Count() - 1];
                y[1] = z[z.Count() - 1];
                player.BestFive = y;
                player.Score = "4Full House";
                return;
            }

            else if (res.ContainsValue(3))
            {
                var z = new List<int>();
                foreach (var kvp in res)
                {
                    if (kvp.Value == 3)
                    {
                        z.Add(kvp.Key);
                    }
                }
                z.Sort();
                var y = new int[5];
                y[4] = z[z.Count() - 1];
                y[3] = z[z.Count() - 1];
                y[2] = z[z.Count() - 1];
                int x = 1;
                for (int i = 6; i >= 0; i--)
                {
                    if (!y.Contains(allSeven[i]))
                    {
                        y[x] = allSeven[i];
                        x--;
                        if (x < 0)
                        {
                            player.BestFive = y;
                            player.Score = "5Three Of A Kind";
                            return;
                        }

                    }
                }
            }
            else if (res.ContainsValue(2))
            {
                var z = new List<int>();
                foreach (var kvp in res)
                {
                    if (kvp.Value == 2)
                    {
                        z.Add(kvp.Key);
                    }
                }
                var y = new int[5];
                y[4] = z[z.Count() - 1];
                y[3] = z[z.Count() - 1];
                if (z.Count > 1)
                {
                    y[2] = z[z.Count - 2];
                    player.BestFive = y;
                    player.Score = "6Two Pair";
                    return;
                }
                else
                {
                    var co = 2;
                    for (int i = 6; i >= 0; i--)
                    {
                        if (!y.Contains(allSeven[i]))
                        {
                            y[co] = allSeven[i];
                            co--;
                            if (co < 0)
                            {
                                player.BestFive = y;
                                player.Score = "6Two Pair";
                                return;
                            }
                        }
                    }
                }
            }
            player.BestFive = new int[5];
            player.Score = "6Two Pair";
            return;

        }
        public static int BetGetter(Player player)
        {
            // Method for parsing bets from users, also for displaying current bet and how much players need to spend to stay in
            bool gotint = false;
            int gold = 0;
            while (!gotint)
            {
                string bidder = $"{player.Name}, action is on you.";
                if (bet > 0) { bidder += Environment.NewLine + $"The Current bet is {bet} and you currently in for {player.CurrentBid}"; }
                bidder += Environment.NewLine + "What do you wish to do?";
                if (bet > 0) { bidder += Environment.NewLine + $"Press Call to push {bet - player.CurrentBid} into the pot"; }
                gotint = int.TryParse(new BetBox(bidder).ShowDialog(player), out gold);
                if (gold - player.CurrentBid > player.Gold)
                {
                    MessageBox.Show("You can only bet what you have, Try Again");
                    gotint = false;
                }
            }
            return gold;
        }
        public static string FindWinner()
        {
            //finds winner and returns final statement for main text box
            string ans = "";
            List<Player> inPlay = Player.players.Where(x => x.Folded == false).ToList();
            foreach (var player in inPlay)
            {                
                BestFive(player);                               
            }

            List<Player> winners = inPlay.OrderBy(o => o.Score).ThenByDescending(o => o.BestFive[4]).ThenByDescending(o => o.BestFive[3]).ThenByDescending(o => o.BestFive[2]).ThenByDescending(o => o.BestFive[1]).ThenByDescending(o => o.BestFive[0]).ToList();
            if (winners[0].BestFive.SequenceEqual(winners[1].BestFive))
            {
                ans += $"By The Gods, a tie!";
                ans += Environment.NewLine;

                var tied = new List<Player>() { winners[0], winners[1] };
                for (int i = 2; i < winners.Count; i++)
                {
                    if (winners[0].BestFive.SequenceEqual(winners[i].BestFive))
                    {
                        tied.Add(winners[i]);
                    }
                }
                int split = pot / tied.Count;
                foreach (var player in tied)
                {
                    ans += $"{player.Name} ,";
                    player.Gold += split;
                }
                ans.Substring(ans.Length - 2);
                ans += $"have tied with a{winners[0].Score.Remove(0, 1)}, {winners[0].BestFive[4]} high. We'll split the pot amoungst you.";

            }
            else
            {
                ans += $"The Winner is {winners[0].Name} with a {winners[0].Score.Remove(0, 1)}, {winners[0].BestFive[4]} high. Now take your winnings and leave in peace.";
                winners[0].Gold += pot;
            }
            ans += Environment.NewLine;
            ans += "Winning hand was a " + winners[0].BestFive[0] + winners[0].BestFive[1] + winners[0].BestFive[2] + winners[0].BestFive[3] + winners[0].BestFive[4];
            ans += Environment.NewLine;
            ans += $" Community Dice : {commDice[0]} {commDice[1]} {commDice[2]} {commDice[3]} {commDice[04]}";
            ans+= Environment.NewLine;
            foreach(var player in inPlay)
            {
                ans += player.Name + " had " + player.Dice[0] + " " + player.Dice[1];
                ans+= Environment.NewLine;
            }

            return ans;
        }
        public static void FlopRoll()
        {
            //these methods add dice to the middle text box as well as to each players dice array
            Random rnd = new Random();
            int j = rnd.Next(1, 7);
            int k = rnd.Next(1, 7);
            int l = rnd.Next(1, 7);
            commDice.Add(j);
            commDice.Add(k);
            commDice.Add(l);
            //for (int i = 0; i < Player.players.Count; i++)
            //{
            //    Player.players[i].Dice[2] = j;
            //    Player.players[i].Dice[3] = k;
            //    Player.players[i].Dice[4] = l;
            //}

        }
        public static int GoldGetter()
        {
            //helps with parsing the gold amount entered by user
            bool gotint = false;
            int gold = 0;
            while (!gotint)
            {
                gotint = int.TryParse(new InputBox("Enter The Number of Gold Coins You Brought To The Table").ShowDialog(), out gold);
                if (!gotint) { MessageBox.Show("Please Only Enter the Number of Gold Coins you brought."); }
                else if (gold < 0)
                {
                    MessageBox.Show("I Asked You For Gold, Not Debt!");
                    gotint = false;
                }
            }
            return gold;
        }
        public static void IndividualRoll()
        {

            int j = Player.players.Count;
            Random rnd = new Random();
            for (int k = 0; k < j; k++)
            {
                var d = new int[2];
                for (int i = 0; i < 2; i++)
                {
                    d[i] = rnd.Next(1, 7);
                }
                Player.players[k].Dice = d;
            }
        }
        public static void ResetBets()
        {
            //resets the bets between rounds
            rotate = 0;
            bet = 0;
            foreach (Player player in Player.players)
            {
                player.CurrentBid = 0;
            }
        }
        public static void RiverRoll()
        {
            Random rnd = new Random();
            int j = rnd.Next(1, 7);
            commDice.Add(j);

            //for (int i = 0; i < Player.players.Count; i++)
            //{
            //    Player.players[i].Dice[6] = j;
            //}

        }
        public static void StartBetting() 
        {
            //Method that runs every round of betting
            
            int co = startingPlayer; //starts the action on stating player. maybe I should make the varible name more discriptive.
            int bid = 0;
            while (rotate < PlayerController.inPlay)
            {
                while (Player.players[co].Folded) { co++; if (co == Player.players.Count) { co = 0; } } //Checks to see if current player folded, if so it skips thier turn.            
                bid = BetGetter(Player.players[co]);
                PlayerController.CheckinPlay();
                if (PlayerController.inPlay == 1 ) return;
                if (!Player.players[co].Folded)
                {
                    bet = bid;
                    if (bid > 0)
                    {
                        int current = bid - Player.players[co].CurrentBid;
                        pot += current;
                        Player.players[co].CurrentBid = bid;
                        Player.players[co].Gold -= current;                        
                    }
                }
                else { rotate--; } //I dont know why this works. it just does. without it one person folding always keeps one other person at the table from being able to bet.
                co++;
                if (co == Player.players.Count) { co = 0; }              

            }
            ResetBets();
        }                          
        public static void TurnRoll()
        {
            Random rnd = new Random();
            int j = rnd.Next(1, 7);
            commDice.Add(j);

            //for (int i = 0; i < Player.players.Count; i++)
            //{
            //    Player.players[i].Dice[5] = j;
            //}
            
        }        
    }
}
