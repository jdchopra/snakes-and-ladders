using NUnit.Framework;
using Should;
using SnakesAndLadders;
using System.Linq;

namespace SnakesAndLaddersTest
{
    class DiceRollerTests
    {
        [Test]
        public void GivenIRollTheDice100Times_ThenIShouldRollAllNumbersInTheRangeOneToSixInclusive()
        {
            var diceRoller = new Die();

            var wasNumberRolled = new bool[6];

            for (var i = 0; i < 100; i++)
            {
                var numberRolled = diceRoller.Roll();
                wasNumberRolled[numberRolled - 1] = true;
            }

            wasNumberRolled.Count(wasRolled => wasRolled).ShouldEqual(6);
        }
    }
}
