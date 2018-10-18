using NSubstitute;
using NUnit.Framework;
using Should;
using SnakesAndLadders;

namespace SnakesAndLaddersTest
{
    public class PlayerTests
    {
        private Player _player;
        private IDie _die;

        [SetUp]
        public void Setup()
        {
            _die = Substitute.For<IDie>();
            _player = new Player(_die);
        }

        [Test]
        public void GivenICreateANewPlayer_ThenThePlayerIsAtSquareOne()
        {
            _player.Square.ShouldEqual(1);
        }

        [Test]
        public void GivenAPlayerMakesAMove_WhenTheyRollFour_ThenTheyInteractWithTheSquareFourSpacesAhead()
        {
            _die.Roll().Returns(4);

            _player.Roll();

            _die.Received(1).Roll();
            _player.Square.ShouldEqual(5);
        }

        [Test]
        public void GivenAPlayerRollsTwoThenThreeThenFive_ThenTheyMoveAsExpected()
        {
            _die.Roll().Returns(2);
            _player.Roll();

            _die.Roll().Returns(3);
            _player.Roll();

            _die.Roll().Returns(5);
            _player.Roll();

            _player.Square.ShouldEqual(11);
        }


        
        [Test]
        public void GivenAPlayerWouldExceedTheFinalSquare_ThenTheyRemainStationaryAndTheGameDoesNotEnd()
        {
            GivenIHaveMovedToSquare(97);

            _die.Roll().Returns(4);
            _player.Roll();

            _player.Square.ShouldEqual(97);
        }

        public void GivenIHaveMovedToSquare(int squareNumberToMoveTo)
        {
            _die.Roll().Returns(squareNumberToMoveTo - 1);
            _player.Roll();
        }
    }
}