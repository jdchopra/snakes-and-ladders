using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Should;
using SnakesAndLadders;

namespace SnakesAndLaddersTest
{
    public class GameTests
    {
        private IDie _die;
        private Player _player;
        private Game _game;

        [SetUp]
        public void Setup()
        {
            _die = Substitute.For<IDie>();
            _player = new Player(_die);
            _game = new Game(_player);
        }


        [Test]
        public void GivenAPlayerLandsOnTheFinalSquare_ThenTheyWinTheGame()
        {
            GivenIHaveMovedToSquare(97);
            _die.Roll().Returns(3);

            _game.MakeMove();

            _player.Square.ShouldEqual(100);
            _game.Winner.Should().BeEquivalentTo(_player);
        }

        public void GivenIHaveMovedToSquare(int squareNumberToMoveTo)
        {
            _die.Roll().Returns(squareNumberToMoveTo - 1);
            _player.Roll();
        }
    }
}