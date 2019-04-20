using DeathStar.Core.Models.Ships;
using NUnit.Framework;
using System;

namespace ShipTests.BattleShipTests
{
	internal class InstanceTests
	   : ShipTestBase<Battleship>
	{
	

		[SetUp]
		public void Setup()
			=> SetupShipFactory();

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
			Assert.AreEqual(GetShipRange(ship), ship.Range);
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
			var shipMock = _Factory.CreateShip(type);
			//Assert
			Assert.DoesNotThrow(() => _FactoryMock.CreateShip(type));
			Assert.AreEqual(type.ToString(), shipMock.Name);
			Assert.IsNull(shipMock.PictureUrl);
			Assert.AreEqual(8000, shipMock.ShieldStrength);
			Assert.AreEqual(7000, shipMock.ArmorStrength);
			Assert.AreEqual(5000, shipMock.HullStrength);
			Assert.AreEqual(GetShipRange(shipMock), shipMock.Range);
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
			var ship = _Factory.CreateShip(type);
			//Assert
			Assert.DoesNotThrow(() => _Factory.CreateShip(type));
			Assert.AreEqual(type.ToString(), ship.Name);
			Assert.IsNull(ship.PictureUrl);
			Assert.AreEqual(7000, ship.ShieldStrength);
			Assert.AreEqual(7000, ship.ArmorStrength);
			Assert.AreEqual(6000, ship.HullStrength);
			Assert.AreEqual(GetShipRange(ship), ship.Range);
			Assert.AreEqual(8, ship.Weapons.Length);
			Assert.AreEqual(3, ship.EngineeringModules.Length);
			Assert.AreEqual(6, ship.DefenseModules.Length);
		}

		[Test]
		public void CreateBattleShip_CreateWidow_ReturnsCorrectInstance()
		{
			//Arrange	
			var type = Battleships.Widow;
			//Act
			var ship = _Factory.CreateShip(type);
			//Assert
			Assert.DoesNotThrow(() => _Factory.CreateShip(type));
			Assert.AreEqual(type.ToString(), ship.Name);
			Assert.IsNull(ship.PictureUrl);
			Assert.AreEqual(9000, ship.ShieldStrength);
			Assert.AreEqual(7000, ship.ArmorStrength);
			Assert.AreEqual(4000, ship.HullStrength);
			Assert.AreEqual(GetShipRange(ship), ship.Range);
			Assert.AreEqual(8, ship.Weapons.Length);
			Assert.AreEqual(5, ship.EngineeringModules.Length);
			Assert.AreEqual(4, ship.DefenseModules.Length);
		}

		[Test]
		public void CreateBattleShip_CreateRokh_ReturnsCorrectInstance()
		{
			//Arrange	
			var type = Battleships.Rokh;
			//Act
			var ship = _Factory.CreateShip(type);
			//Assert
			Assert.DoesNotThrow(() => _Factory.CreateShip(type));
			Assert.AreEqual(type.ToString(), ship.Name);
			Assert.IsNull(ship.PictureUrl);
			Assert.AreEqual(7000, ship.ShieldStrength);
			Assert.AreEqual(8000, ship.ArmorStrength);
			Assert.AreEqual(5000, ship.HullStrength);
			Assert.AreEqual(GetShipRange(ship), ship.Range);
			Assert.AreEqual(7, ship.Weapons.Length);
			Assert.AreEqual(4, ship.EngineeringModules.Length);
			Assert.AreEqual(6, ship.DefenseModules.Length);
		}

		[Test]
		public void CreateBattleShip_CreateUnknownShip_ThrowsInvalidOperationException()
		{
			//Arrange	
			var type = AltuFaltuShip.X;
			//Act

			//Assert
			_Assertions.AssertThrows<InvalidOperationException>(() => { _Factory.CreateShip(type); }, "Invalid Ship");
		}
	}
}