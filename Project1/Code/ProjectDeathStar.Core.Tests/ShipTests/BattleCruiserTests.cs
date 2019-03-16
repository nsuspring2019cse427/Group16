using Autofac.Extras.Moq;
using DeathStar.Core.Models.Equipments;
using DeathStar.Core.Models.Ships;
using NUnit.Framework;
using ShipTests;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShipTests
{
    public class BattleCruiserTests
        : ShipTestBase<BattleCruiser>
    {
        
        [SetUp]
        public void Setup()
            => SetupShipFactory();

        [Test]
        public void CreateBattleCruiser_CreateFerox_ReturnsCorrectInstance()
        {
            //Arrange	
            var type = BattleCruisers.Ferox;
            //Act
            var ship = _Factory.CreateShip(type);
            //Assert
            Assert.DoesNotThrow(() => _Factory.CreateShip(type));
            Assert.AreEqual(type.ToString(), ship.Name);
            Assert.IsNull(ship.PictureUrl);
            Assert.AreEqual(3000, ship.ShieldStrength);
            Assert.AreEqual(4000, ship.ArmorStrength);
            Assert.AreEqual(2000, ship.HullStrength);
            Assert.AreEqual(0, ship.Range);
            Assert.AreEqual(6, ship.Weapons.Length);
            Assert.AreEqual(4, ship.EngineeringModules.Length);
            Assert.AreEqual(4, ship.DefenseModules.Length);
        }

        [Test]
        public void CreateBattleCruiser_CreateDrake_ReturnsCorrectInstance()
        {
            //Arrange	
            var type = BattleCruisers.Drake;
            //Act
            var shipMock = _FactoryMock.CreateShip(type);
            //Assert
            Assert.DoesNotThrow(() => _FactoryMock.CreateShip(type));
            Assert.AreEqual(type.ToString(), shipMock.Name);
            Assert.IsNull(shipMock.PictureUrl);
            Assert.AreEqual(4000, shipMock.ShieldStrength);
            Assert.AreEqual(3000, shipMock.ArmorStrength);
            Assert.AreEqual(2000, shipMock.HullStrength);
            Assert.AreEqual(0, shipMock.Range);
            Assert.AreEqual(5, shipMock.Weapons.Length);
            Assert.AreEqual(5, shipMock.EngineeringModules.Length);
            Assert.AreEqual(4, shipMock.DefenseModules.Length);
        }

        [Test]
        public void CreateBattleCruiser_CreateNaga_ReturnsCorrectInstance()
        {
            //Arrange	
            var type = BattleCruisers.Naga;
            //Act
            var shipMock = _FactoryMock.CreateShip(type);
            //Assert
            Assert.DoesNotThrow(() => _FactoryMock.CreateShip(type));
            Assert.AreEqual(type.ToString(), shipMock.Name);
            Assert.IsNull(shipMock.PictureUrl);
            Assert.AreEqual(2500, shipMock.ShieldStrength);
            Assert.AreEqual(4500, shipMock.ArmorStrength);
            Assert.AreEqual(2000, shipMock.HullStrength);
            Assert.AreEqual(0, shipMock.Range);
            Assert.AreEqual(6, shipMock.Weapons.Length);
            Assert.AreEqual(5, shipMock.EngineeringModules.Length);
            Assert.AreEqual(3, shipMock.DefenseModules.Length);
        }

        [Test]
        public void CreateBattleCruiser_CreateNighthawk_ReturnsCorrectInstance()
        {
            //Arrange	
            var type = BattleCruisers.Nihgthawk;
            //Act
            var shipMock = _FactoryMock.CreateShip(type);
            //Assert
            Assert.DoesNotThrow(() => _FactoryMock.CreateShip(type));
            Assert.AreEqual(type.ToString(), shipMock.Name);
            Assert.IsNull(shipMock.PictureUrl);
            Assert.AreEqual(2000, shipMock.ShieldStrength);
            Assert.AreEqual(4000, shipMock.ArmorStrength);
            Assert.AreEqual(3000, shipMock.HullStrength);
            Assert.AreEqual(0, shipMock.Range);
            Assert.AreEqual(6, shipMock.Weapons.Length);
            Assert.AreEqual(3, shipMock.EngineeringModules.Length);
            Assert.AreEqual(5, shipMock.DefenseModules.Length);
        }

        [Test]
        public void CreateBattleCruiser_CreateVulture_ReturnsCorrectInstance()
        {
            //Arrange	
            var type = BattleCruisers.Vulture;
            //Act
            var shipMock = _FactoryMock.CreateShip(type);
            //Assert
            Assert.DoesNotThrow(() => _FactoryMock.CreateShip(type));
            Assert.AreEqual(type.ToString(), shipMock.Name);
            Assert.IsNull(shipMock.PictureUrl);
            Assert.AreEqual(4000, shipMock.ShieldStrength);
            Assert.AreEqual(2000, shipMock.ArmorStrength);
            Assert.AreEqual(3000, shipMock.HullStrength);
            Assert.AreEqual(0, shipMock.Range);
            Assert.AreEqual(6, shipMock.Weapons.Length);
            Assert.AreEqual(4, shipMock.EngineeringModules.Length);
            Assert.AreEqual(4, shipMock.DefenseModules.Length);
        }

        [Test]
        public void CreateBattleCruiser_CreateOracle_ReturnsCorrectInstance()
        {
            //Arrange	
            var type = BattleCruisers.Oracle;
            //Act
            var shipMock = _FactoryMock.CreateShip(type);
            //Assert
            Assert.DoesNotThrow(() => _FactoryMock.CreateShip(type));
            Assert.AreEqual(type.ToString(), shipMock.Name);
            Assert.IsNull(shipMock.PictureUrl);
            Assert.AreEqual(3000, shipMock.ShieldStrength);
            Assert.AreEqual(3000, shipMock.ArmorStrength);
            Assert.AreEqual(3000, shipMock.HullStrength);
            Assert.AreEqual(0, shipMock.Range);
            Assert.AreEqual(5, shipMock.Weapons.Length);
            Assert.AreEqual(4, shipMock.EngineeringModules.Length);
            Assert.AreEqual(5, shipMock.DefenseModules.Length);
        }

        [Test]
        public void CreateBattleCruiser_CreateUnknownShip_ThrowsInvalidOperationException()
        {
            //Arrange	
            var type = AltuFaltuShip.X;
            //Act

            //Assert
            Assert.Catch<InvalidOperationException>(() => _FactoryMock.CreateShip(type));
        }

        [Test]
        public void InstallMediumCannon_InFerox_SetsWeaponInCorrectSlot()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange
                //var weapon = mock.Mock<IWeapon>();
                //weapon.Setup(a => a.Damage).Returns(500);
                //var ship = mock.Create<Raven>();
                
                var ship = _Factory.CreateShip(BattleCruisers.Ferox);
                var weapon = _CannonMock;

                //Act
                ship.InstallWeapon(weapon, 3);

                //ship.Weapons = new List<IWeapon>() { weapon.Object, weapon.Object };

                //var damage = ship.FireWeapon();

                //weapon.VerifyAll();

                //Assert
                Assert.Contains(weapon, ship.Weapons);
                Assert.IsTrue(weapon.Equals(ship.Weapons[2]));
            }
        }
    }
}
