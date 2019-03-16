using Autofac;
using Autofac.Extras.Moq;
using DeathStar.Core.Models.Equipments;
using DeathStar.Core.Models.Ships;
using NUnit.Framework;
using System;

namespace ShipTests
{
    public class BattleshipTests
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
        public void InstallLargeCannon_InstallInRaven_SetsWeaponInCorrectSlot()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                var param = new NamedParameter[2] {
                    new NamedParameter("weapons", Weapons.Cannon),
                    new NamedParameter("weaponGrades", WeaponGrades.Large)
                };

                var ship = _Factory.CreateShip(Battleships.Dominix);
                var weapon = mock.Create<Weapon>(param);

                //Act
                ship.InstallWeapon(weapon, 3);

                //weapon.VerifyAll();

                //Assert
                Assert.Contains(weapon, ship.Weapons);
                Assert.IsTrue(weapon.Equals(ship.Weapons[2]));
            }
        }

        [Test]
        public void InstallLargeCannon_InstallInDominix_SetsWeaponInCorrectSlot()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                var param = new NamedParameter[2] {
                    new NamedParameter("weapons", Weapons.Cannon),
                    new NamedParameter("weaponGrades", WeaponGrades.Large)
                };

                var ship = _Factory.CreateShip(Battleships.Dominix);
                var weapon = mock.Create<Weapon>(param);


                //Act
                ship.InstallWeapon(weapon, 3);

                //weapon.VerifyAll();

                //Assert
                Assert.Contains(weapon, ship.Weapons);
                Assert.IsTrue(weapon.Equals(ship.Weapons[2]));
            }
        }

        [Test]
        public void InstallLargeCannon_InstallInScorpion_SetsWeaponInCorrectSlot()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                var param = new NamedParameter[2] {
                    new NamedParameter("weapons", Weapons.Cannon),
                    new NamedParameter("weaponGrades", WeaponGrades.Large)
                };

                var ship = _Factory.CreateShip(Battleships.Scorpion);
                var weapon = mock.Create<Weapon>(param);

                //Act
                ship.InstallWeapon(weapon, 3);

                //weapon.VerifyAll();

                //Assert
                Assert.Contains(weapon, ship.Weapons);
                Assert.IsTrue(weapon.Equals(ship.Weapons[2]));
            }
        }

        [Test]
        public void InstallLargeCannon_InstallInWidow_SetsWeaponInCorrectSlot()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                var param = new NamedParameter[2] {
                    new NamedParameter("weapons", Weapons.Cannon),
                    new NamedParameter("weaponGrades", WeaponGrades.Large)
                };

                var ship = _Factory.CreateShip(Battleships.Widow);
                var weapon = mock.Create<Weapon>(param);


                //Act
                ship.InstallWeapon(weapon, 3);

                //weapon.VerifyAll();

                //Assert
                Assert.Contains(weapon, ship.Weapons);
                Assert.IsTrue(weapon.Equals(ship.Weapons[2]));
            }
        }

        [Test]
        public void InstallLargeCannon_InstallInRokh_SetsWeaponInCorrectSlot()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                var param = new NamedParameter[2] {
                    new NamedParameter("weapons", Weapons.Cannon),
                    new NamedParameter("weaponGrades", WeaponGrades.Large)
                };

                var ship = _Factory.CreateShip(Battleships.Rokh);
                var weapon = mock.Create<Weapon>(param);

                //Act
                ship.InstallWeapon(weapon, 3);

                //weapon.VerifyAll();

                //Assert
                Assert.Contains(weapon, ship.Weapons);
                Assert.IsTrue(weapon.Equals(ship.Weapons[2]));
            }
        }

        [Test]
        public void InstallLargeCannon_InstallInAnyShip_SetsWeaponInIncorrectSlot()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                var param = new NamedParameter[2] {
                    new NamedParameter("weapons", Weapons.Cannon),
                    new NamedParameter("weaponGrades", WeaponGrades.Large)
                };

                var ship = _Factory.CreateShip(Battleships.Dominix);
                var weapon = mock.Create<Weapon>(param);


                //Act


                //weapon.VerifyAll();

                //Assert
                Assert.Catch<ArgumentOutOfRangeException>(() => ship.InstallWeapon(weapon, -1));
            }
        }

        [Test]
        public void InstallMediumCannon_InstallInAnyShip_SetsWeaponInCorrectSlot()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                var param = new NamedParameter[2] {
                    new NamedParameter("weapons", Weapons.Cannon),
                    new NamedParameter("weaponGrades", WeaponGrades.Medium)
                };

                var ship = _Factory.CreateShip(Battleships.Dominix);
                var weapon = mock.Create<Weapon>(param);

                //Act


                //weapon.VerifyAll();

                //Assert
                Assert.Catch<InvalidOperationException>(() => ship.InstallWeapon(weapon, 3));
            }
        }

        [Test]
        public void InstallSmallCannon_InstallInAnyShip_SetsWeaponInIncorrectSlot()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                var param = new NamedParameter[2] {
                    new NamedParameter("weapons", Weapons.Cannon),
                    new NamedParameter("weaponGrades", WeaponGrades.Small)
                };

                var ship = _Factory.CreateShip(Battleships.Dominix);
                var weapon = mock.Create<Weapon>(param);


                //Act


                //weapon.VerifyAll();

                //Assert
                Assert.Catch<ArgumentOutOfRangeException>(() => ship.InstallWeapon(weapon, -1));
                Assert.Catch<InvalidOperationException>(() => ship.InstallWeapon(weapon, 3));
            }
        }

        [Test]
        public void RemoveWeapon_RemoveFromCorrectSlots_SuccessfullyRemoved()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                var param = new NamedParameter[2] {
                    new NamedParameter("weapons", Weapons.Cannon),
                    new NamedParameter("weaponGrades", WeaponGrades.Large)
                };

                var ship = _Factory.CreateShip(Battleships.Dominix);
                var weapon = mock.Create<Weapon>(param);

                ship.InstallWeapon(weapon, 3);

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

                var param = new NamedParameter[2] {
                    new NamedParameter("weapons", Weapons.Cannon),
                    new NamedParameter("weaponGrades", WeaponGrades.Large)
                };

                var ship = _Factory.CreateShip(Battleships.Dominix);
                var weapon = mock.Create<Weapon>(param);

                ship.InstallWeapon(weapon, 3);

                //Act



                //weapon.VerifyAll();

                //Assert
                Assert.Catch<ArgumentOutOfRangeException>(() => ship.RemoveWeapon(-1));
            }
        }

        [Test]
        public void RemoveDefenseModule_RemoveFromCorrectSlots_SuccessfullyRemoved()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                var param = new NamedParameter[2] {
                    new NamedParameter("defensiveModules", DefenseModules.ShieldAmplifier),
                    new NamedParameter("defensiveWeaponGrades", DefenseModuleGrades.Large)
                };

                var ship = _Factory.CreateShip(Battleships.Dominix);
                var defenseModule = mock.Create<DefenseModule>(param);

                ship.InstallDefensiveModule(defenseModule, 3);

                //Act

                ship.RemoveDefenseModule(3);

                //weapon.VerifyAll();

                //Assert
                Assert.IsNull(ship.DefenseModules[2]);
            }
        }

        [Test]
        public void RemoveDefenseModule_RemoveFromIncorrectSlots_SuccessfullyRemoved()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                var param = new NamedParameter[2] {
                    new NamedParameter("defensiveModules", DefenseModules.ShieldAmplifier),
                    new NamedParameter("defensiveWeaponGrades", DefenseModuleGrades.Large)
                };

                var ship = _Factory.CreateShip(Battleships.Dominix);
                var defenseModule = mock.Create<DefenseModule>(param);

                ship.InstallDefensiveModule(defenseModule, 3);

                //Act



                //weapon.VerifyAll();

                //Assert
                Assert.Catch<ArgumentOutOfRangeException>(() => ship.RemoveDefenseModule(-1));
            }
        }

        [Test]
        public void InstallDefensiveModule_InstallShieldAmplifierDefensiveModuleInDominix_SetsDefensiveModuleInCorrectSlot()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                var param = new NamedParameter[2] {
                    new NamedParameter("defensiveModules", DefenseModules.ShieldAmplifier),
                    new NamedParameter("defensiveWeaponGrades", DefenseModuleGrades.Large)
                };

                var ship = _Factory.CreateShip(Battleships.Dominix);
                var defenseModule = mock.Create<DefenseModule>(param);

                //Act

                ship.InstallDefensiveModule(defenseModule, 3);

                //weapon.VerifyAll();

                //Assert
                Assert.Contains(defenseModule, ship.DefenseModules);
                Assert.AreEqual(defenseModule, ship.DefenseModules[2]);
            }
        }

        [Test]
        public void InstallDefensiveModule_InstallHullPlateDefensiveModuleInDominix_SetsDefensiveModuleInCorrectSlot()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                var param = new NamedParameter[2] {
                    new NamedParameter("defensiveModules", DefenseModules.HullPlate),
                    new NamedParameter("defensiveWeaponGrades", DefenseModuleGrades.Large)
                };

                var ship = _Factory.CreateShip(Battleships.Dominix);
                var defenseModule = mock.Create<DefenseModule>(param);

                //Act

                ship.InstallDefensiveModule(defenseModule, 3);

                //weapon.VerifyAll();

                //Assert
                Assert.Contains(defenseModule, ship.DefenseModules);
                Assert.AreEqual(defenseModule, ship.DefenseModules[2]);
            }
        }

        [Test]
        public void InstallDefensiveModule_InstallArmorPlateDefensiveModuleInDominix_SetsDefensiveModuleInCorrectSlot()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                var param = new NamedParameter[2] {
                    new NamedParameter("defensiveModules", DefenseModules.ArmorPlate),
                    new NamedParameter("defensiveWeaponGrades", DefenseModuleGrades.Large)
                };

                var ship = _Factory.CreateShip(Battleships.Dominix);
                var defenseModule = mock.Create<DefenseModule>(param);

                //Act

                ship.InstallDefensiveModule(defenseModule, 3);

                //weapon.VerifyAll();

                //Assert
                Assert.Contains(defenseModule, ship.DefenseModules);
                Assert.AreEqual(defenseModule, ship.DefenseModules[2]);
            }
        }

        [Test]
        public void InstallDefensiveModule_InstallShieldAmplifierDefensiveModuleInDominix_SetsDefensiveModuleInIncorrectSlot()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                var param = new NamedParameter[2] {
                    new NamedParameter("defensiveModules", DefenseModules.ShieldAmplifier),
                    new NamedParameter("defensiveWeaponGrades", DefenseModuleGrades.Large)
                };

                var ship = _Factory.CreateShip(Battleships.Dominix);
                var defenseModule = mock.Create<DefenseModule>(param);

                //Act



                //weapon.VerifyAll();

                //Assert
                Assert.Catch<ArgumentOutOfRangeException>(() => ship.InstallDefensiveModule(defenseModule, -1));
            }
        }
    }
}