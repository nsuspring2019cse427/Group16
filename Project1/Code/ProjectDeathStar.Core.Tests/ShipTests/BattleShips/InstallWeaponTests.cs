using Autofac.Extras.Moq;
using DeathStar.Core.Models.Equipments;
using DeathStar.Core.Models.Ships;
using NUnit.Framework;
using System;

namespace ShipTests.BattleShipTests
{
	internal class InstallWeaponTests
		: BattleShipTests 
	{
        [SetUp]
		public void Setup()
			=> SetupWeapons();		

		[Test]
		public void InstallWeaponInAnyCorrectShip_InstallWeaponInCorrectSlot_SuccessfullyInstalled()
		{
			using (var mock = AutoMock.GetLoose())
			{
                //Arrange
                
				//Act
				Dominix.InstallWeapon(_LargeCannonMock, 1);
                Dominix.InstallWeapon(_LargeLaserMock, 2);
                Dominix.InstallWeapon(_LargeMissileMock, 3);
                Dominix.InstallWeapon(_LargeProjectileMock, 4);
                Dominix.InstallWeapon(_LargeShockwaveMock, 5);

                Raven.InstallWeapon(_LargeCannonMock, 1);
                Raven.InstallWeapon(_LargeLaserMock, 2);
                Raven.InstallWeapon(_LargeMissileMock, 3);
                Raven.InstallWeapon(_LargeProjectileMock, 4);
                Raven.InstallWeapon(_LargeShockwaveMock, 5);

                Rokh.InstallWeapon(_LargeCannonMock, 1);
                Rokh.InstallWeapon(_LargeLaserMock, 2);
                Rokh.InstallWeapon(_LargeMissileMock, 3);
                Rokh.InstallWeapon(_LargeProjectileMock, 4);
                Rokh.InstallWeapon(_LargeShockwaveMock, 5);

                Scorpion.InstallWeapon(_LargeCannonMock, 1);
                Scorpion.InstallWeapon(_LargeLaserMock, 2);
                Scorpion.InstallWeapon(_LargeMissileMock, 3);
                Scorpion.InstallWeapon(_LargeProjectileMock, 4);
                Scorpion.InstallWeapon(_LargeShockwaveMock, 5);

                Widow.InstallWeapon(_LargeCannonMock, 1);
                Widow.InstallWeapon(_LargeLaserMock, 2);
                Widow.InstallWeapon(_LargeMissileMock, 3);
                Widow.InstallWeapon(_LargeProjectileMock, 4);
                Widow.InstallWeapon(_LargeShockwaveMock, 5);

                //weapon.VerifyAll();

                //Assert                
                Assert.Contains(_LargeCannonMock, Dominix.Weapons);
				Assert.IsTrue(_LargeCannonMock.Equals(Dominix.Weapons[0]));
                Assert.Contains(_LargeLaserMock, Dominix.Weapons);
                Assert.IsTrue(_LargeLaserMock.Equals(Dominix.Weapons[1]));
                Assert.Contains(_LargeMissileMock, Dominix.Weapons);
                Assert.IsTrue(_LargeMissileMock.Equals(Dominix.Weapons[2]));
                Assert.Contains(_LargeProjectileMock, Dominix.Weapons);
                Assert.IsTrue(_LargeProjectileMock.Equals(Dominix.Weapons[3]));
                Assert.Contains(_LargeShockwaveMock, Dominix.Weapons);
				Assert.IsTrue(_LargeShockwaveMock.Equals(Dominix.Weapons[4]));

                Assert.Contains(_LargeCannonMock, Raven.Weapons);
                Assert.IsTrue(_LargeCannonMock.Equals(Raven.Weapons[0]));
                Assert.Contains(_LargeLaserMock, Raven.Weapons);
                Assert.IsTrue(_LargeLaserMock.Equals(Raven.Weapons[1]));
                Assert.Contains(_LargeMissileMock, Raven.Weapons);
                Assert.IsTrue(_LargeMissileMock.Equals(Raven.Weapons[2]));
                Assert.Contains(_LargeProjectileMock, Raven.Weapons);
                Assert.IsTrue(_LargeProjectileMock.Equals(Raven.Weapons[3]));
                Assert.Contains(_LargeShockwaveMock, Raven.Weapons);
                Assert.IsTrue(_LargeShockwaveMock.Equals(Raven.Weapons[4]));

                Assert.Contains(_LargeCannonMock, Rokh.Weapons);
                Assert.IsTrue(_LargeCannonMock.Equals(Rokh.Weapons[0]));
                Assert.Contains(_LargeLaserMock, Rokh.Weapons);
                Assert.IsTrue(_LargeLaserMock.Equals(Rokh.Weapons[1]));
                Assert.Contains(_LargeMissileMock, Rokh.Weapons);
                Assert.IsTrue(_LargeMissileMock.Equals(Rokh.Weapons[2]));
                Assert.Contains(_LargeProjectileMock, Rokh.Weapons);
                Assert.IsTrue(_LargeProjectileMock.Equals(Rokh.Weapons[3]));
                Assert.Contains(_LargeShockwaveMock, Rokh.Weapons);
                Assert.IsTrue(_LargeShockwaveMock.Equals(Rokh.Weapons[4]));

                Assert.Contains(_LargeCannonMock, Scorpion.Weapons);
                Assert.IsTrue(_LargeCannonMock.Equals(Scorpion.Weapons[0]));
                Assert.Contains(_LargeLaserMock, Scorpion.Weapons);
                Assert.IsTrue(_LargeLaserMock.Equals(Scorpion.Weapons[1]));
                Assert.Contains(_LargeMissileMock, Scorpion.Weapons);
                Assert.IsTrue(_LargeMissileMock.Equals(Scorpion.Weapons[2]));
                Assert.Contains(_LargeProjectileMock, Scorpion.Weapons);
                Assert.IsTrue(_LargeProjectileMock.Equals(Scorpion.Weapons[3]));
                Assert.Contains(_LargeShockwaveMock, Scorpion.Weapons);
                Assert.IsTrue(_LargeShockwaveMock.Equals(Scorpion.Weapons[4]));

                Assert.Contains(_LargeCannonMock, Widow.Weapons);
                Assert.IsTrue(_LargeCannonMock.Equals(Widow.Weapons[0]));
                Assert.Contains(_LargeLaserMock, Widow.Weapons);
                Assert.IsTrue(_LargeLaserMock.Equals(Widow.Weapons[1]));
                Assert.Contains(_LargeMissileMock, Widow.Weapons);
                Assert.IsTrue(_LargeMissileMock.Equals(Widow.Weapons[2]));
                Assert.Contains(_LargeProjectileMock, Widow.Weapons);
                Assert.IsTrue(_LargeProjectileMock.Equals(Widow.Weapons[3]));
                Assert.Contains(_LargeShockwaveMock, Widow.Weapons);
                Assert.IsTrue(_LargeShockwaveMock.Equals(Widow.Weapons[4]));
            }
		}		

		[Test]
		public void InstallWeaponInAnyCorrectShip_InstallWeaponInIncorrectSlot_ThrowsArgumentOutOfRangeExceptions()
		{
			using (var mock = AutoMock.GetLoose())
			{
				//Arrange

				var ship = _Factory.CreateShip(Battleships.Dominix);
				//var weapon = mock.Create<Weapon>(GetWeaponParams(Weapons.Cannon, WeaponGrades.Large));

				//Act


				//weapon.VerifyAll();

				//Assert
				_Assertions
                    .AssertThrows<ArgumentOutOfRangeException>(() 
                        => ship.InstallWeapon(_LargeCannonMock, -1), exMsgInvalidSlot );
			}
		}

		[Test]
		public void InstallWeaponsInAnyCorrectShip_InstallWeaponOfInvalidSize_ThrowsInvalidOperationExceptions()
		{
			using (var mock = AutoMock.GetLoose())
			{
				//Arrange

				var dominix = _Factory.CreateShip(Battleships.Dominix);
                var raven = _Factory.CreateShip(Battleships.Raven);
                var rokh = _Factory.CreateShip(Battleships.Rokh);
                var scorpion = _Factory.CreateShip(Battleships.Scorpion);
                var widow = _Factory.CreateShip(Battleships.Widow);

                //var weapon = mock.Create<Weapon>(GetWeaponParams(Weapons.Cannon, WeaponGrades.Small));


                //Act


                //weapon.VerifyAll();

                //Assert
                #region Small

                #region Cannon
                _Assertions.AssertThrows<InvalidOperationException>(()
                    => dominix.InstallWeapon(_SmallCannonMock, 3),
                       string.Format(exMsgInvalidSize, _SmallCannonMock.Grade, _SmallCannonMock.Name, dominix.Name));

                _Assertions.AssertThrows<InvalidOperationException>(()
                    => raven.InstallWeapon(_SmallCannonMock, 3),
                       string.Format(exMsgInvalidSize, _SmallCannonMock.Grade, _SmallCannonMock.Name, raven.Name));

                _Assertions.AssertThrows<InvalidOperationException>(()
                    => rokh.InstallWeapon(_SmallCannonMock, 3),
                       string.Format(exMsgInvalidSize, _SmallCannonMock.Grade, _SmallCannonMock.Name, rokh.Name));

                _Assertions.AssertThrows<InvalidOperationException>(()
                    => scorpion.InstallWeapon(_SmallCannonMock, 3),
                       string.Format(exMsgInvalidSize, _SmallCannonMock.Grade, _SmallCannonMock.Name, scorpion.Name));

                _Assertions.AssertThrows<InvalidOperationException>(()
                    => widow.InstallWeapon(_SmallCannonMock, 3),
                       string.Format(exMsgInvalidSize, _SmallCannonMock.Grade, _SmallCannonMock.Name, widow.Name));
                #endregion

                #region Projectile
                _Assertions.AssertThrows<InvalidOperationException>(()
                    => dominix.InstallWeapon(_SmallProjectileMock, 3),
                       string.Format(exMsgInvalidSize, _SmallProjectileMock.Grade, _SmallProjectileMock.Name, dominix.Name));

                _Assertions.AssertThrows<InvalidOperationException>(()
                    => raven.InstallWeapon(_SmallProjectileMock, 3),
                       string.Format(exMsgInvalidSize, _SmallProjectileMock.Grade, _SmallProjectileMock.Name, raven.Name));

                _Assertions.AssertThrows<InvalidOperationException>(()
                    => rokh.InstallWeapon(_SmallProjectileMock, 3),
                       string.Format(exMsgInvalidSize, _SmallProjectileMock.Grade, _SmallProjectileMock.Name, rokh.Name));

                _Assertions.AssertThrows<InvalidOperationException>(()
                    => scorpion.InstallWeapon(_SmallProjectileMock, 3),
                       string.Format(exMsgInvalidSize, _SmallProjectileMock.Grade, _SmallProjectileMock.Name, scorpion.Name));

                _Assertions.AssertThrows<InvalidOperationException>(()
                    => widow.InstallWeapon(_SmallProjectileMock, 3),
                       string.Format(exMsgInvalidSize, _SmallProjectileMock.Grade, _SmallProjectileMock.Name, widow.Name));
                #endregion

                #region Missile
                _Assertions.AssertThrows<InvalidOperationException>(()
                    => dominix.InstallWeapon(_SmallMissileMock, 3),
                       string.Format(exMsgInvalidSize, _SmallMissileMock.Grade, _SmallMissileMock.Name, dominix.Name));

                _Assertions.AssertThrows<InvalidOperationException>(()
                    => raven.InstallWeapon(_SmallMissileMock, 3),
                       string.Format(exMsgInvalidSize, _SmallMissileMock.Grade, _SmallMissileMock.Name, raven.Name));

                _Assertions.AssertThrows<InvalidOperationException>(()
                    => rokh.InstallWeapon(_SmallMissileMock, 3),
                       string.Format(exMsgInvalidSize, _SmallMissileMock.Grade, _SmallMissileMock.Name, rokh.Name));

                _Assertions.AssertThrows<InvalidOperationException>(()
                    => scorpion.InstallWeapon(_SmallMissileMock, 3),
                       string.Format(exMsgInvalidSize, _SmallMissileMock.Grade, _SmallMissileMock.Name, scorpion.Name));

                _Assertions.AssertThrows<InvalidOperationException>(()
                    => widow.InstallWeapon(_SmallMissileMock, 3),
                       string.Format(exMsgInvalidSize, _SmallMissileMock.Grade, _SmallMissileMock.Name, widow.Name));
                #endregion

                #region Laser
                _Assertions.AssertThrows<InvalidOperationException>(()
                    => dominix.InstallWeapon(_SmallLaserMock, 3),
                       string.Format(exMsgInvalidSize, _SmallLaserMock.Grade, _SmallLaserMock.Name, dominix.Name));

                _Assertions.AssertThrows<InvalidOperationException>(()
                    => raven.InstallWeapon(_SmallLaserMock, 3),
                       string.Format(exMsgInvalidSize, _SmallLaserMock.Grade, _SmallLaserMock.Name, raven.Name));

                _Assertions.AssertThrows<InvalidOperationException>(()
                    => rokh.InstallWeapon(_SmallLaserMock, 3),
                       string.Format(exMsgInvalidSize, _SmallLaserMock.Grade, _SmallLaserMock.Name, rokh.Name));

                _Assertions.AssertThrows<InvalidOperationException>(()
                    => scorpion.InstallWeapon(_SmallLaserMock, 3),
                       string.Format(exMsgInvalidSize, _SmallLaserMock.Grade, _SmallLaserMock.Name, scorpion.Name));

                _Assertions.AssertThrows<InvalidOperationException>(()
                    => widow.InstallWeapon(_SmallLaserMock, 3),
                       string.Format(exMsgInvalidSize, _SmallLaserMock.Grade, _SmallLaserMock.Name, widow.Name));
                #endregion

                #region Shock wave
                _Assertions.AssertThrows<InvalidOperationException>(()
                    => dominix.InstallWeapon(_SmallShockwaveMock, 3),
                       string.Format(exMsgInvalidSize, _SmallShockwaveMock.Grade, _SmallShockwaveMock.Name, dominix.Name));

                _Assertions.AssertThrows<InvalidOperationException>(()
                    => raven.InstallWeapon(_SmallShockwaveMock, 3),
                       string.Format(exMsgInvalidSize, _SmallShockwaveMock.Grade, _SmallShockwaveMock.Name, raven.Name));

                _Assertions.AssertThrows<InvalidOperationException>(()
                    => rokh.InstallWeapon(_SmallShockwaveMock, 3),
                       string.Format(exMsgInvalidSize, _SmallShockwaveMock.Grade, _SmallShockwaveMock.Name, rokh.Name));

                _Assertions.AssertThrows<InvalidOperationException>(()
                    => scorpion.InstallWeapon(_SmallShockwaveMock, 3),
                       string.Format(exMsgInvalidSize, _SmallShockwaveMock.Grade, _SmallShockwaveMock.Name, scorpion.Name));

                _Assertions.AssertThrows<InvalidOperationException>(()
                    => widow.InstallWeapon(_SmallShockwaveMock, 3),
                       string.Format(exMsgInvalidSize, _SmallShockwaveMock.Grade, _SmallShockwaveMock.Name, widow.Name));
                #endregion

                #region Doomsday 
                _Assertions.AssertThrows<InvalidOperationException>(()
                    => dominix.InstallWeapon(_DoomsdayBeamMock, 3),
                       string.Format(exMsgInvalidSize, _DoomsdayBeamMock.Grade, _DoomsdayBeamMock.Name, dominix.Name));

                _Assertions.AssertThrows<InvalidOperationException>(()
                    => raven.InstallWeapon(_DoomsdayCannonMock, 3),
                       string.Format(exMsgInvalidSize, _DoomsdayCannonMock.Grade, _DoomsdayCannonMock.Name, raven.Name));

                _Assertions.AssertThrows<InvalidOperationException>(()
                    => rokh.InstallWeapon(_DoomsdayMissileMock, 3),
                       string.Format(exMsgInvalidSize, _DoomsdayMissileMock.Grade, _DoomsdayMissileMock.Name, rokh.Name));
                
                #endregion

                #endregion
            }
        }
	}
}
