using System;
using Mine.Models;
using NUnit.Framework;
using Mine.Helpers;

namespace UnitTests.Helpers
{
    [TestFixture]
    public class DiceHelperUnitTest
    {
        [Test]
        public void RollDice_Invalid_Roll_Zero_Should_Return_Zero()
        {
            //Arrange

            //Act
            var result = DiceHelpers.RollDice(0,1);

            //Reset

            //Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void RollDice_InValid_Roll_0_Dice_10_Should_Return_Zero()
        {
            //Arrange

            //Act
            var result = DiceHelpers.RollDice(0, 10);

            //Reset

            //Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void RollDice_InValid_Roll_1_Dice_0_Should_Return_Zero()
        {
            //Arrange

            //Act
            var result = DiceHelpers.RollDice(1, 0);

            //Reset

            //Assert
            Assert.AreEqual(0, result);

        }

        [Test]
        public void RollDice_Valid_Roll_1_Dice_6_Should_Return_Between_1_And_6()
        {
            //Arrange

            //Act
            var result = DiceHelpers.RollDice(1, 6);

            //Reset

            //Assert
            Assert.AreEqual(true, result >= 1);
            Assert.AreEqual(true, result <= 6);
        }


        [Test]
        public void RollDice_Valid_Roll_1_Dice_6_Should_Return_Between_2_And_12()
        {
            //Arrange

            //Act
            var result = DiceHelpers.RollDice(2, 12);

            //Reset

            //Assert
            Assert.AreEqual(true, result >= 2);
            Assert.AreEqual(true, result <= 12);
        }

        [Test]
        public void RollDice_Invalid_Roll_Forced_1_Should_Return_1()
        {
            //Arrange
            DiceHelpers.ForceRollsToNotRandom = true;
            DiceHelpers.ForcedRandomValue = 1;

            //Act
            var result = DiceHelpers.RollDice(1,1);

            //Reset
            DiceHelpers.ForceRollsToNotRandom = false;

            //Assert
            Assert.AreEqual(1, result);
        }


        [Test]
        public void RollDice_Valid_Roll_1_Dice_10_Fixed_5_Should_Return_5()
        {
            //Arrange
            DiceHelpers.ForceRollsToNotRandom = true;
            DiceHelpers.ForcedRandomValue = 5;

            //Act
            var result = DiceHelpers.RollDice(1, 10);

            //Reset
            DiceHelpers.ForceRollsToNotRandom = false;

            //Assert
            Assert.AreEqual(5, result);
        }

        [Test]
        public void RollDice_Valid_Roll_3_Dice_10_Fixed_5_Should_Return_5()
        {
            //Arrange
            DiceHelpers.ForceRollsToNotRandom = true;
            DiceHelpers.ForcedRandomValue = 5;

            //Act
            var result = DiceHelpers.RollDice(3, 10);

            //Reset
            DiceHelpers.ForceRollsToNotRandom = false;

            //Assert
            Assert.AreEqual(15, result);
        }
    }
}
