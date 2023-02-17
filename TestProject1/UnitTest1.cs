using WpfApp1;

namespace TestProject1

{
    public class UnitTest1
    {


        [Theory]
        [InlineData(new Player() { Dice = new int[7] { 1, 1, 3, 4, 5, 6, 6 }, Name = "Mike", Gold = 300, Number = 1 }, new int[5] { 5, 1, 1, 6, 6 })]
        [InlineData(new int[7] { 1, 1, 2, 4, 4, 5, 6 }, new int[5] { 6, 1, 1, 4, 4 })]
        [InlineData(new int[7] { 1, 1, 1, 2, 4, 5, 6 }, new int[5] { 5, 6, 1, 1, 1, })]
        [InlineData(new int[7] { 1, 4, 4, 4, 5, 5, 6, }, new int[5] { 5, 5, 4, 4, 4, })]
        [InlineData(new int[7] { 1, 2, 3, 4, 4, 5, 5 }, new int[5] { 1, 2, 3, 4, 5 })]
        [InlineData(new int[7] { 1, 1, 1, 1, 5, 6, 6 }, new int[5] { 6, 1, 1, 1, 1, })]
        [InlineData(new int[7] { 1, 1, 1, 1, 1, 5, 6 }, new int[5] { 1, 1, 1, 1, 1 })]
        public void FindWinnerTest(Player player, Player expected)
        {
            var gameController = new GameController();
            var actual = GameController.BestFive(dice);
            Assert.Equal(expected, actual);
        }
    }
}