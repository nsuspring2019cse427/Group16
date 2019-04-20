using Autofac;
using Autofac.Extras.Moq;
using DeathStar.Core.Models.Equipments;
using DeathStar.Core.Models.Ships;
using NUnit.Framework;
using System;

namespace ShipTests.BattleShipTests
{
	internal class RemoveWeaponTestscs
		: ShipTestBase<Battleship>
	{
		[SetUp]
		public void Setup()
			=> SetupWeapons();

		[Test]
		public void RemoveWeapon_RemoveFromCorrectSlots_SuccessfullyRemoved()
		{
			using (var mock = AutoMock.GetLoose())
			{
				//Arrange

				var ship = _Factory.CreateShip(Battleships.Dominix);

				ship.InstallWeapon(_LargeCannonMock, 3);

				//Act

				ship.RemoveWeapon(3);

				//weapon.VerifyAll();

				//Assert
				Assert.IsNull(ship.Weapons[2]);
			}
		}

		[Test]
		public void RemoveWeapon_RemoveFromIncorrectSlots_ThrowsException()
		{
			using (var mock = AutoMock.GetLoose())
			{
				//Arrange

				var ship = _Factory.CreateShip(Battleships.Dominix);

				ship.InstallWeapon(_LargeCannonMock, 3);

				//Act

				//weapon.VerifyAll();

				//Assert
				_Assertions.AssertThrows<ArgumentOutOfRangeException>(() => ship.RemoveWeapon((uint)ship.Weapons.Length));
			}
		}
	}
}
