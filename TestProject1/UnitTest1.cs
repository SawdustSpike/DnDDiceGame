//using WpfApp1;

//namespace TestProject1

//{
//    public class UnitTest1
//    {
       
//            [Theory]
//            [InlineData(new int[5] { 1, 1, 3, 4, 5 }, "7Pair")]
//            [InlineData(new int[5] { 1, 1, 4, 4, 5 }, "6Two Pair")]
//            [InlineData(new int[5] { 1, 1, 1, 4, 5 }, "5Three Of A Kind")]
//            [InlineData(new int[5] { 4, 4, 4, 5, 5 }, "4Full House")]
//            [InlineData(new int[5] { 1, 2, 3, 4, 5 }, "3Straight")]
//            [InlineData(new int[5] { 1, 1, 1, 1, 5 }, "2 Four Of A Kind")]
//            [InlineData(new int[5] { 1, 1, 1, 1, 1 }, "1Five Of A Kind")]

//            public void ScoreDiceTest(int[] dice, string expected)
//            {
//                //Arrange
//                var gameController = new GameController();
//                //Act
//                var actual = GameController.ScoreDice(dice);
//                //Assert
//                Assert.Equal(expected, actual);
//            }

//            [Theory]
//            [InlineData(new int[7] { 1, 1, 3, 4, 5, 6, 6 }, new int[5] {5, 1, 1, 6, 6 })]
//            [InlineData(new int[7] { 1, 1, 2, 4, 4, 5, 6 }, new int[5] {6, 1, 1, 4, 4 })]
//            [InlineData(new int[7] { 1, 1, 1, 2, 4, 5, 6 }, new int[5] { 5,6,1, 1, 1, })]
//            [InlineData(new int[7] { 1, 4, 4, 4, 5, 5, 6, }, new int[5] { 5,5,4, 4, 4, })]
//            [InlineData(new int[7] { 1, 2, 3, 4, 4, 5, 5 }, new int[5] { 1, 2, 3, 4, 5 })]
//            [InlineData(new int[7] { 1, 1, 1, 1, 5, 6, 6 }, new int[5] { 6, 1, 1, 1, 1,  })]
//            [InlineData(new int[7] { 1, 1, 1, 1, 1, 5, 6 }, new int[5] { 1, 1, 1, 1, 1 })]
//            public void BestFiveTest(int[] dice, int[] expected)
//            {
//                var gameController = new GameController();
//                var actual = GameController.BestFive(dice);
//                Assert.Equal(expected, actual);
//            }
//        }
//}