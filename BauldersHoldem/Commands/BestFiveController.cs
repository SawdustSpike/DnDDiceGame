using BauldersHoldem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaulderHoldem.Commands
{
    public class BestFiveController
    {
        public static bool IsStraight(Player player, Dictionary<int, int> diceDic)
        {
            if (diceDic.ContainsKey(2) && diceDic.ContainsKey(3) && diceDic.ContainsKey(4) && diceDic.ContainsKey(5) && diceDic.ContainsKey(6)) { player.BestFive = new int[] { 2, 3, 4, 5, 6 }; player.Score = "3Straight"; return true; }
            else if (diceDic.ContainsKey(1) && diceDic.ContainsKey(2) && diceDic.ContainsKey(3) && diceDic.ContainsKey(4) && diceDic.ContainsKey(5)) { player.BestFive = new int[] { 1, 2, 3, 4, 5 }; player.Score = "3Straight"; return true; }
            return false;

        }
        public static bool IsFiveOfAKind(Player player, Dictionary<int, int> diceDic)
        {
            if (!diceDic.ContainsValue(5))
            {
                return false;
            }
            else
            {
                var x = diceDic.FirstOrDefault(y => y.Value == 5).Key;
                player.BestFive = new int[] { x, x, x, x, x };
                player.Score = "1Five Of A Kind";
                return true;
            }

        }
        public static bool IsFourOfAKind(Player player, Dictionary<int, int> diceDic, List<int> allSeven)
        {
            if (!diceDic.ContainsValue(4))
            {
                return false;
            }
            else
            {
                var x = diceDic.FirstOrDefault(a => a.Value == 4).Key;
                var y = new int[5] { 0, x, x, x, x, };
                for (int i = 6; i >= 0; i--)
                {
                    if (!y.Contains(allSeven[i]))
                    {
                        y[0] = allSeven[i];
                        player.BestFive = y;
                        player.Score = "2 Four Of A Kind";
                        return true;

                    }
                }
                throw new Exception("Four of a Kind Finder Failed");
            }


        }
        public static bool IsFullHouse(Player player, Dictionary<int, int> diceDic)
        {
            if (diceDic.ContainsValue(3) && diceDic.ContainsValue(2))
            {
                var x = diceDic.FirstOrDefault(a => a.Value == 3).Key;
                var y = new int[5] { 0, 0, x, x, x };
                var z = new List<int>();
                foreach (var kvp in diceDic)
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
                return true;
            }
            else
            {

                return false;
            }

        }
        public static bool IsThreeOfAKind(Player player, Dictionary<int, int> diceDic, List<int> allSeven)
        {
            if (!diceDic.ContainsValue(3))
            {
                return false;
            }
            else
            {
                var z = new List<int>();
                foreach (var kvp in diceDic)
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
                            return true;
                        }

                    }
                }
                throw new Exception("Three Of A Kind Finder Failed");

            }
        }
        public static bool IsTwoPair(Player player, Dictionary<int, int> diceDic, List<int> allSeven)
        {
            var twoPairs = new List<int>();
            foreach (var kvp in diceDic)
            {
                if (kvp.Value == 2)
                {
                    twoPairs.Add(kvp.Key);
                }
            }
            if (twoPairs.Count < 2)
            {
                return false;
            }
            else
            {
                twoPairs.Sort();
                var y = new int[5];
                y[4] = twoPairs[twoPairs.Count - 1];
                y[3] = twoPairs[twoPairs.Count - 1];
                y[2] = twoPairs[twoPairs.Count - 2];
                y[1] = twoPairs[twoPairs.Count - 2];

                for (int i = 6; i >= 0; i--)
                {
                    if (!y.Contains(allSeven[i]))
                    {
                        y[0] = allSeven[i];
                        player.BestFive = y;
                        player.Score = "6Two Pair";
                        return true;
                    }
                }

                throw new Exception("Find Two Pair Method Failed");
            }



        }
    }
}

