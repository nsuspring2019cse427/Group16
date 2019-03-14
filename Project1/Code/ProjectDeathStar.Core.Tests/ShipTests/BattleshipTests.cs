using Autofac.Extras.Moq;
using DeathStar.Core.Models.Equipments;
using DeathStar.Core.Models.Ships;
using NUnit.Framework;
using System;

namespace ShipTests.BattleshipTests
{
    public class InstanceTests
        : ShipTestBase<Battleship>
    {
        [SetUp]
        public void Setup()
            => SetupFactory();

        [Test]
        public void CreateBattleShip_CreateRaven_ReturnsCorrectInstance()
        {
            //Arrange	
            var type = Battleships.Raven;
            //Act
            var ship = _Factory.CreateShip(type);
            //Assert
            Assert.DoesNotThrow(() => _Factory.CreateShip(type));
            Assert.AreEqual(type.ToString(), ship.Name);
            Assert.IsNull(ship.PictureUrl);
            Assert.AreEqual(7000, ship.ShieldStrength);
            Assert.AreEqual(8000, ship.ArmorStrength);
            Assert.AreEqual(5000, ship.HullStrength);
            Assert.AreEqual(0, ship.Range);
            Assert.AreEqual(8, ship.Weapons.Length);
            Assert.AreEqual(4, ship.EngineeringModules.Length);
            Assert.AreEqual(5, ship.DefenseModules.Length);
        }

        [Test]
        public void CreateBattleShip_CreateDominix_ReturnsCorrectInstance()
        {
            //Arrange	
            var type = Battleships.Dominix;
            //Act
            var shipMock = _FactoryMock.CreateShip(type);
            //Assert
            Assert.DoesNotThrow(() => _FactoryMock.CreateShip(type));
            Assert.AreEqual(type.ToString(), shipMock.Name);
            Assert.IsNull(shipMock.PictureUrl);
            Assert.AreEqual(8000, shipMock.ShieldStrength);
            Assert.AreEqual(7000, shipMock.ArmorStrength);
            Assert.AreEqual(5000, shipMock.HullStrength);
            Assert.AreEqual(0, shipMock.Range);
            Assert.AreEqual(7, shipMock.Weapons.Length);
            Assert.AreEqual(5, shipMock.EngineeringModules.Length);
            Assert.AreEqual(5, shipMock.DefenseModules.Length);
        }

        [Test]
        public void CreateBattleShip_CreateScorpion_ReturnsCorrectInstance()
        {
            //Arrange	
            var type = Battleships.Scorpion;
            //Act
            var shipMock = _FactoryMock.CreateShip(type);
            //Assert
            Assert.DoesNotThrow(() => _FactoryMock.CreateShip(type));
            Assert.AreEqual(type.ToString(), shipMock.Name);
            Assert.IsNull(shipMock.PictureUrl);
            Assert.AreEqual(7000, shipMock.ShieldStrength);
            Assert.AreEqual(7000, shipMock.ArmorStrength);
            Assert.AreEqual(6000, shipMock.HullStrength);
            Assert.AreEqual(0, shipMock.Range);
            Assert.AreEqual(8, shipMock.Weapons.Length);
            Assert.AreEqual(3, shipMock.EngineeringModules.Length);
            Assert.AreEqual(6, shipMock.DefenseModules.Length);
        }

        [Test]
        public void CreateBattleShip_CreateWidow_ReturnsCorrectInstance()
        {
            //Arrange	
            var type = Battleships.Widow;
            //Act
            var shipMock = _FactoryMock.CreateShip(type);
            //Assert
            Assert.DoesNotThrow(() => _FactoryMock.CreateShip(type));
            Assert.AreEqual(type.ToString(), shipMock.Name);
            Assert.IsNull(shipMock.PictureUrl);
            Assert.AreEqual(9000, shipMock.ShieldStrength);
            Assert.AreEqual(7000, shipMock.ArmorStrength);
            Assert.AreEqual(4000, shipMock.HullStrength);
            Assert.AreEqual(0, shipMock.Range);
            Assert.AreEqual(8, shipMock.Weapons.Length);
            Assert.AreEqual(5, shipMock.EngineeringModules.Length);
            Assert.AreEqual(4, shipMock.DefenseModules.Length);
        }

        [Test]
        public void CreateBattleShip_CreateRokh_ReturnsCorrectInstance()
        {
            //Arrange	
            var type = Battleships.Rokh;
            //Act
            var shipMock = _FactoryMock.CreateShip(type);
            //Assert
            Assert.DoesNotThrow(() => _FactoryMock.CreateShip(type));
            Assert.AreEqual(type.ToString(), shipMock.Name);
            Assert.IsNull(shipMock.PictureUrl);
            Assert.AreEqual(7000, shipMock.ShieldStrength);
            Assert.AreEqual(8000, shipMock.ArmorStrength);
            Assert.AreEqual(5000, shipMock.HullStrength);
            Assert.AreEqual(0, shipMock.Range);
            Assert.AreEqual(7, shipMock.Weapons.Length);
            Assert.AreEqual(4, shipMock.EngineeringModules.Length);
            Assert.AreEqual(6, shipMock.DefenseModules.Length);
        }

        [Test]
        public void CreateBattleShip_CreateUnknownShip_ThrowsInvalidOperationException()
        {
            //Arrange	
            var type = AltuFaltuShip.X;
            //Act

            //Assert
            Assert.Catch<InvalidOperationException>(() => _FactoryMock.CreateShip(type));
        }

        [Test]
        public void InstallWeapon_setWeaponInSlot_setsWeaponInCorrectSlot()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange
                //var weapon = mock.Mock<IWeapon>();
                //weapon.Setup(a => a.Damage).Returns(500);
                //var ship = mock.Create<Raven>();

                var factory = new ShipFactory<Battleship>();
                var raven = factory.CreateShip(Battleships.Raven);
                var cannon = new Weapon(Weapons.Cannon, WeaponGrades.Large);

                //Act
                raven.InstallWeapon(cannon, 3);

                //ship.Weapons = new List<IWeapon>() { weapon.Object, weapon.Object };

                //var damage = ship.FireWeapon();

                //weapon.VerifyAll();

                //Assert
                Assert.Contains(cannon, raven.Weapons);
            }
        }
    }
}