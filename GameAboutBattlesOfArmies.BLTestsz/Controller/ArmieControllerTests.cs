using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameAboutBattlesOfArmies.BL.Controlller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameAboutBattlesOfArmies.BL.Models;
using GameAboutBattlesOfArmies.BL.Models.UnitSA;
using GameAboutBattlesOfArmies.BL.Models.Unit;
using GameAboutBattlesOfArmies.BL.Controlller.Exceptions;
using GameAboutBattlesOfArmies.BL.Contracts;
using System.Reflection;
using GameAboutBattlesOfArmies.BL.Models.UnitHealer;

namespace GameAboutBattlesOfArmies.BL.Controlller.Tests
{
    [TestClass()]
    public class ArmieControllerTests
    {
        [TestMethod()]
        public void ArmieControllerTest()
        {
            //Arrange
            var price = 100;
            //Act
            var controller = new ArmieController(price);
            //Assert
            Assert.AreEqual(price, controller.ArmiePrice);
        }

        [TestMethod()]
        public void AddUnitTest()
        {
            //Arrange
            var unitArcher = new KnightArcher("Archer",3,3,3,10);
            var unit = new Knight("Knight", 3, 3, 3, 10);
            var controller = new ArmieController(100);
            void Add(IUnit unit)=> controller.AddUnit(unit);
            //Act
            Add(unitArcher);
            Add(unit);
            //Assert
            // Assert.ThrowsException<ArmieException>(()=> { Add(unitArcher); });
            Assert.IsFalse(controller.armie.AllUnits.Contains(unitArcher));
            Assert.IsTrue(controller.armie.AllUnits.Contains(unit));
        }

        [TestMethod()]
        public void SaveTest()
        {
            //Arrange
            var price = 100;
            var unitArcher = new KnightArcher("Archer", 3, 2, 5, 10);
            var unitKnight = new Knight("Knight", 3, 3, 5, 9);
            var unitLight = new LightInfantry("light", 1, 2, 3, 8);
            var unitHealer = new HeavyHealer("Healer", 2, 2, 4, 7);
            var controller = new ArmieController(price);
            controller.AddUnit(unitArcher);
            controller.AddUnit(unitLight);
            controller.AddUnit(unitHealer);
            controller.AddUnit(unitKnight);
            //Act
            controller.Save(controller.armie);
            var controller2 = new ArmieController(price);
            controller2.AddUnit(unitArcher);
            controller2.AddUnit(unitLight);
            controller2.AddUnit(unitHealer);
            controller2.AddUnit(unitKnight);
            //Assert
            Assert.AreEqual(controller.armie.ArmiePrice, controller2.armie.ArmiePrice);
        }
    }
}