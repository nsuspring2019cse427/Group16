using Autofac;
using Autofac.Core;
using Autofac.Extras.Moq;
using DeathStar.Core.Models.Equipments;
using DeathStar.Core.Models.Ships;
using DeathStar.Core.Tests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ShipTests
{
    [TestFixture, ExcludeFromCodeCoverage]
    internal abstract class ShipTestBase<TShip>
       where TShip : Ship
    {
        protected ShipFactory<TShip> _Factory;
        protected ShipFactory<TShip> _FactoryMock;

        protected readonly string exMsgInvalidSlot = "Invalid slot.\r\nParameter name: slot";
        protected readonly string exMsgInvalidSize = "Can not install a {0} '{1}' weapon in '{2}' ship";

        #region weapons

        #region Cannon        
        protected Weapon _SmallCannonMock;
        protected Weapon _MediumCannonMock;
        protected Weapon _LargeCannonMock;
        protected Weapon _XLargeCannonMock;
        protected Weapon _XXLargeCannonMock;
        #endregion

        #region Projectile
        protected Weapon _SmallProjectileMock;
        protected Weapon _MediumProjectileMock;
        protected Weapon _LargeProjectileMock;
        protected Weapon _XLargeProjectileMock;
        protected Weapon _XXLargeProjectileMock;
        #endregion

        #region Laser
        protected Weapon _SmallLaserMock;
        protected Weapon _MediumLaserMock;
        protected Weapon _LargeLaserMock;
        protected Weapon _XLargeLaserMock;
        protected Weapon _XXLargeLaserMock;
        #endregion

        #region Missile
        protected Weapon _SmallMissileMock;
        protected Weapon _MediumMissileMock;
        protected Weapon _LargeMissileMock;
        protected Weapon _XLargeMissileMock;
        protected Weapon _XXLargeMissileMock;
        #endregion

        #region Shockwave
        protected Weapon _SmallShockwaveMock;
        protected Weapon _MediumShockwaveMock;
        protected Weapon _LargeShockwaveMock;
        protected Weapon _XLargeShockwaveMock;
        protected Weapon _XXLargeShockwaveMock;
        #endregion

        #region Doomsday
        protected Weapon _DoomsdayBeamMock;
        protected Weapon _DoomsdayCannonMock;
        protected Weapon _DoomsdayMissileMock;
        #endregion
        #endregion

        #region Defensive Module

        #region Amplifier
        protected DefenseModule _SmallShieldAmplifierMock;
        protected DefenseModule _MediumShieldAmplifierMock;
        protected DefenseModule _LargeShieldAmplifierMock;
        protected DefenseModule _XLargeShieldAmplifierMock;
        protected DefenseModule _XXLargeShieldAmplifierMock;
        protected DefenseModule _DoomsdayShieldAmplifierMock;
        #endregion

        #region Armor Plate
        protected DefenseModule _SmallArmorPlateMock;
        protected DefenseModule _MediumArmorPlateMock;
        protected DefenseModule _LargeArmorPlateMock;
        protected DefenseModule _XLargeArmorPlateMock;
        protected DefenseModule _XXLargeArmorPlateMock;
        protected DefenseModule _DoomsdayArmorPlateMock;
        #endregion

        #region Hull Plate
        protected DefenseModule _SmallHullPlateMock;
        protected DefenseModule _MediumHullPlateMock;
        protected DefenseModule _LargeHullPlateMock;
        protected DefenseModule _XLargeHullPlateMock;
        protected DefenseModule _XXLargeHullPlateMock;
        protected DefenseModule _DoomsdayHullPlateMock;
        #endregion

        #endregion

        protected Assertions _Assertions;

        protected ShipTestBase()
        {
            _Factory = new ShipFactory<TShip>();
            _Assertions = new Assertions();
        }

        [TearDown]
        public void Dispose()
        {
            //_Factory = null;
            //_FactoryMock = null;
        }

        protected uint GetShipRange(TShip ship)
        {
            if (ship is Shuttle || ship is Corvette)
                return 1;
            else if (ship is Frigate || ship is Destroyer)
                return 2;
            else if (ship is Cruiser || ship is BattleCruiser)
                return 3;
            else if (ship is Battleship || ship is Dreadnaut)
                return 4;
            else if (ship is Juggernaut || ship is Carrier || ship is SuperCarrier)
                return 5;
            else if (ship is Titan || ship is SuperTitan || ship is DeathStar.Core.Models.Ships.DeathStar)
                return 6;
            else
                throw new InvalidOperationException();
        }

        public Parameter[] GetWeaponParams<TWeapon, TWeaponGrade>(TWeapon weapon, TWeaponGrade grade)
            where TWeapon : Enum
            where TWeaponGrade : Enum
        {
            if (weapon is Weapons w && grade is WeaponGrades wg)
            {
                return new Parameter[2]
                {
                    new NamedParameter("weapons", w),
                    new NamedParameter("weaponGrades", wg)
                };
            }
            else if (weapon is DefenseModules d && grade is DefenseModuleGrades dwg)
            {
                return new Parameter[2]
                {
                    new NamedParameter("defenseModule", d),
                    new NamedParameter("defenseModuleGrades", dwg)
                };
            }
            else
                throw new ArgumentException();
        }

        #region setup weapons 

        private void SetupSmallWeapons(AutoMock mock)
        {
            var param = new NamedParameter[2]
            {
                new NamedParameter("weapons", Weapons.Cannon),
                new NamedParameter("weaponGrades", WeaponGrades.Small)
            };

            _SmallCannonMock = mock.Create<Weapon>(param);

            param[0] = new NamedParameter("weapons", Weapons.Laser);
            _SmallLaserMock = mock.Create<Weapon>(param);

            param[0] = new NamedParameter("weapons", Weapons.Missile);
            _SmallMissileMock = mock.Create<Weapon>(param);

            param[0] = new NamedParameter("weapons", Weapons.Projectile);
            _SmallProjectileMock = mock.Create<Weapon>(param);

            param[0] = new NamedParameter("weapons", Weapons.Shockwave);
            _SmallShockwaveMock = mock.Create<Weapon>(param);
        }

        private void SetupMediumWeapons(AutoMock mock)
        {
            var param = new NamedParameter[2]
            {
                new NamedParameter("weapons", Weapons.Cannon),
                new NamedParameter("weaponGrades", WeaponGrades.Medium)
            };

            _MediumCannonMock = mock.Create<Weapon>(param);

            param[0] = new NamedParameter("weapons", Weapons.Laser);
            _MediumLaserMock = mock.Create<Weapon>(param);

            param[0] = new NamedParameter("weapons", Weapons.Missile);
            _MediumMissileMock = mock.Create<Weapon>(param);

            param[0] = new NamedParameter("weapons", Weapons.Projectile);
            _MediumProjectileMock = mock.Create<Weapon>(param);

            param[0] = new NamedParameter("weapons", Weapons.Shockwave);
            _MediumShockwaveMock = mock.Create<Weapon>(param);

            param[0] = new NamedParameter("weapons", Weapons.Shockwave);
            _SmallShockwaveMock = mock.Create<Weapon>(param);
        }

        private void SetupLargeWeapons(AutoMock mock)
        {
            var param = new NamedParameter[2]
            {
                new NamedParameter("weapons", Weapons.Cannon),
                new NamedParameter("weaponGrades", WeaponGrades.Large)
            };

            _LargeCannonMock = mock.Create<Weapon>(param);

            param[0] = new NamedParameter("weapons", Weapons.Laser);
            _LargeLaserMock = mock.Create<Weapon>(param);

            param[0] = new NamedParameter("weapons", Weapons.Missile);
            _LargeMissileMock = mock.Create<Weapon>(param);

            param[0] = new NamedParameter("weapons", Weapons.Projectile);
            _LargeProjectileMock = mock.Create<Weapon>(param);

            param[0] = new NamedParameter("weapons", Weapons.Shockwave);
            _LargeShockwaveMock = mock.Create<Weapon>(param);
        }

        private void SetupXLargeWeapons(AutoMock mock)
        {
            var param = new NamedParameter[2]
            {
                new NamedParameter("weapons", Weapons.Cannon),
                new NamedParameter("weaponGrades", WeaponGrades.XLarge)
            };

            _XLargeCannonMock = mock.Create<Weapon>(param);

            param[0] = new NamedParameter("weapons", Weapons.Laser);
            _XLargeLaserMock = mock.Create<Weapon>(param);

            param[0] = new NamedParameter("weapons", Weapons.Missile);
            _XLargeMissileMock = mock.Create<Weapon>(param);

            param[0] = new NamedParameter("weapons", Weapons.Projectile);
            _XLargeProjectileMock = mock.Create<Weapon>(param);

            param[0] = new NamedParameter("weapons", Weapons.Shockwave);
            _XLargeShockwaveMock = mock.Create<Weapon>(param);
        }

        private void SetupXXLargeWeapons(AutoMock mock)
        {
            var param = new NamedParameter[2]
            {
                new NamedParameter("weapons", Weapons.Cannon),
                new NamedParameter("weaponGrades", WeaponGrades.XXLarge)
            };

            _XXLargeCannonMock = mock.Create<Weapon>(param);

            param[0] = new NamedParameter("weapons", Weapons.Laser);
            _XXLargeLaserMock = mock.Create<Weapon>(param);

            param[0] = new NamedParameter("weapons", Weapons.Missile);
            _XXLargeMissileMock = mock.Create<Weapon>(param);

            param[0] = new NamedParameter("weapons", Weapons.Projectile);
            _XXLargeProjectileMock = mock.Create<Weapon>(param);

            param[0] = new NamedParameter("weapons", Weapons.Shockwave);
            _XXLargeShockwaveMock = mock.Create<Weapon>(param);
        }

        private void SetupDoomsdayWeapons(AutoMock mock)
        {
            var param = new NamedParameter[2]
            {
                new NamedParameter("weapons", Weapons.DoomsdayCannon),
                new NamedParameter("weaponGrades", WeaponGrades.Doomsday)
            };

            _DoomsdayCannonMock = mock.Create<Weapon>(param);

            param[0] = new NamedParameter("weapons", Weapons.DoomsdayMissile);
            _DoomsdayMissileMock = mock.Create<Weapon>(param);

            param[0] = new NamedParameter("weapons", Weapons.DoomsdayBeam);
            _DoomsdayBeamMock = mock.Create<Weapon>(param);
        }

        public void SetupWeapons()
        {
            using (var mock = AutoMock.GetLoose())
            {
                SetupSmallWeapons(mock);
                SetupMediumWeapons(mock);
                SetupLargeWeapons(mock);
                SetupXLargeWeapons(mock);
                SetupXXLargeWeapons(mock);
                SetupDoomsdayWeapons(mock);
            }
        }

        #endregion

        #region set up defensive modules
        private void SetupSmallDefensiveModule(AutoMock mock)
        {
            var param = new Parameter[2]
            {
                new NamedParameter("defenseModules", DefenseModules.ShieldAmplifier),
                new NamedParameter("defenseModuleGrades", DefenseModuleGrades.Small)
            };

            _SmallShieldAmplifierMock = mock.Create<DefenseModule>(param);

            param[0] = new NamedParameter("defenseModules", DefenseModules.ArmorPlate);
            _SmallArmorPlateMock = mock.Create<DefenseModule>(param);

            param[0] = new NamedParameter("defenseModules", DefenseModules.HullPlate);
            _SmallHullPlateMock = mock.Create<DefenseModule>(param);
        }

        private void SetupMediumDefensiveModule(AutoMock mock)
        {
            var param = new Parameter[2]
            {
                new NamedParameter("defenseModules", DefenseModules.ShieldAmplifier),
                new NamedParameter("defenseModuleGrades", DefenseModuleGrades.Medium)
            };

            _MediumShieldAmplifierMock = mock.Create<DefenseModule>(param);

            param[0] = new NamedParameter("defenseModules", DefenseModules.ArmorPlate);
            _MediumArmorPlateMock = mock.Create<DefenseModule>(param);

            param[0] = new NamedParameter("defenseModules", DefenseModules.HullPlate);
            _MediumHullPlateMock = mock.Create<DefenseModule>(param);
        }

        private void SetupLargeDefensiveModule(AutoMock mock)
        {
            var param = new Parameter[2]
            {
                new NamedParameter("defenseModules", DefenseModules.ShieldAmplifier),
                new NamedParameter("defenseModuleGrades", DefenseModuleGrades.Large)
            };

            _LargeShieldAmplifierMock = mock.Create<DefenseModule>(param);

            param[0] = new NamedParameter("defenseModules", DefenseModules.ArmorPlate);
            _LargeArmorPlateMock = mock.Create<DefenseModule>(param);

            param[0] = new NamedParameter("defenseModules", DefenseModules.HullPlate);
            _LargeHullPlateMock = mock.Create<DefenseModule>(param);
        }

        private void SetupXLargeDefensiveModule(AutoMock mock)
        {
            var param = new Parameter[2]
            {
                new NamedParameter("defenseModules", DefenseModules.ShieldAmplifier),
                new NamedParameter("defenseModuleGrades", DefenseModuleGrades.XLarge)
            };

            _XLargeShieldAmplifierMock = mock.Create<DefenseModule>(param);

            param[0] = new NamedParameter("defenseModules", DefenseModules.ArmorPlate);
            _XLargeArmorPlateMock = mock.Create<DefenseModule>(param);

            param[0] = new NamedParameter("defenseModules", DefenseModules.HullPlate);
            _XLargeHullPlateMock = mock.Create<DefenseModule>(param);
        }

        private void SetupXXLargeDefensiveModule(AutoMock mock)
        {
            var param = new Parameter[2]
            {
                new NamedParameter("defenseModules", DefenseModules.ShieldAmplifier),
                new NamedParameter("defenseModuleGrades", DefenseModuleGrades.XXLagre)
            };

            _XXLargeShieldAmplifierMock = mock.Create<DefenseModule>(param);

            param[0] = new NamedParameter("defenseModules", DefenseModules.ArmorPlate);
            _XXLargeArmorPlateMock = mock.Create<DefenseModule>(param);

            param[0] = new NamedParameter("defenseModules", DefenseModules.HullPlate);
            _XXLargeHullPlateMock = mock.Create<DefenseModule>(param);
        }

        private void SetupDoomsdayDefensiveModule(AutoMock mock)
        {
            var param = new Parameter[2]
            {
                    new NamedParameter("defenseModules", DefenseModules.ShieldAmplifier),
                    new NamedParameter("defenseModuleGrades", DefenseModuleGrades.Doomsday)
            };

            _DoomsdayShieldAmplifierMock = mock.Create<DefenseModule>(param);

            param[0] = new NamedParameter("defenseModules", DefenseModules.ArmorPlate);
            _DoomsdayArmorPlateMock = mock.Create<DefenseModule>(param);

            param[0] = new NamedParameter("defenseModules", DefenseModules.HullPlate);
            _DoomsdayHullPlateMock = mock.Create<DefenseModule>(param);
        }

        public void SetupDefensiveModules()
        {
            using (var mock = AutoMock.GetLoose())
            {
                SetupSmallDefensiveModule(mock);
                SetupMediumDefensiveModule(mock);
                SetupLargeDefensiveModule(mock);
                SetupXLargeDefensiveModule(mock);
                SetupXXLargeDefensiveModule(mock);
                SetupDoomsdayDefensiveModule(mock);
            }
        }
        #endregion


        public void SetupShipFactory()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var ravenType = Battleships.Raven;
                var dominixType = Battleships.Dominix;
                var rokhType = Battleships.Rokh;
                var scorpionType = Battleships.Scorpion;
                var widowType = Battleships.Widow;
                var factoryMock = mock.Mock<ShipFactory<TShip>>();

                factoryMock.Setup(s => s.CreateShip(ravenType)).Returns(_Factory.CreateShip(ravenType));
                factoryMock.Setup(s => s.CreateShip(dominixType)).Returns(_Factory.CreateShip(dominixType));
                factoryMock.Setup(s => s.CreateShip(rokhType)).Returns(_Factory.CreateShip(rokhType));
                factoryMock.Setup(s => s.CreateShip(scorpionType)).Returns(_Factory.CreateShip(scorpionType));
                factoryMock.Setup(s => s.CreateShip(widowType)).Returns(_Factory.CreateShip(widowType));
                factoryMock.Setup(s => s.CreateShip(AltuFaltuShip.X)).Throws(new InvalidOperationException("Invalid Ship"));
                _FactoryMock = mock.Create<ShipFactory<TShip>>();
            }
        }

        #region Acts

        protected void InstallDefenseModules(Ship ship, IDictionary<DefenseModule, uint> moduleAndSlots)
        {
            foreach (var ms in moduleAndSlots)
            {
                ship.InstallDefensiveModule(ms.Key, ms.Value);
            }
            //ship.InstallDefensiveModule(_LargeArmorPlateMock, 1);
            //ship.InstallDefensiveModule(_LargeHullPlateMock, 2);
            //ship.InstallDefensiveModule(_LargeShieldAmplifierMock, 3);
        }

        #endregion

        #region Assertions

        protected void AssertDefensiveModuleSuccefulInstallation(TShip ship, IDictionary<DefenseModule, uint> modulesAndSlots)
        {
            foreach (var ms in modulesAndSlots)
            {
                Assert.Contains(ms.Key, ship.DefenseModules);
                Assert.AreEqual(ms.Key, ship.DefenseModules[ms.Value - 1]);
            }
        }

        protected void AssertThrowsDefensiveModuleInstallation(TShip ship, IDictionary<DefenseModule, (int len, int gtLen)> modulesAndSlots)
        {
            foreach (var ms in modulesAndSlots)
            {

                _Assertions.AssertThrows<ArgumentOutOfRangeException>(()
                    => ship
                       .InstallDefensiveModule(ms.Key, (uint)ms.Value.len), exMsgInvalidSlot);

                _Assertions.AssertThrows<ArgumentOutOfRangeException>(()
                    => ship
                       .InstallDefensiveModule(ms.Key, (uint)ms.Value.gtLen), exMsgInvalidSlot);
            }

            //_Assertions.AssertThrows<ArgumentOutOfRangeException>(()
            //    => ship
            //       .InstallDefensiveModule(_LargeArmorPlateMock, ship.DefenseModules.Length), exMsgInvalidSlot);
            //_Assertions.AssertThrows<ArgumentOutOfRangeException>(()
            //    => ship
            //       .InstallDefensiveModule(_LargeHullPlateMock, ship.DefenseModules.Length), exMsgInvalidSlot);
            //_Assertions.AssertThrows<ArgumentOutOfRangeException>(()
            //    => ship
            //       .InstallDefensiveModule(_LargeShieldAmplifierMock, ship.DefenseModules.Length), exMsgInvalidSlot);
            //_Assertions.AssertThrows<ArgumentOutOfRangeException>(()
            //    => ship
            //       .InstallDefensiveModule(_LargeArmorPlateMock, ship.DefenseModules.Length + 1), exMsgInvalidSlot);
            //_Assertions.AssertThrows<ArgumentOutOfRangeException>(()
            //    => ship
            //       .InstallDefensiveModule(_LargeHullPlateMock, ship.DefenseModules.Length + 1), exMsgInvalidSlot);
            //_Assertions.AssertThrows<ArgumentOutOfRangeException>(()
            //    => ship
            //       .InstallDefensiveModule(_LargeShieldAmplifierMock, ship.DefenseModules.Length + 1), exMsgInvalidSlot);
        }

        protected void AssertThrowsDefensiveModuleUninstallation(TShip ship)
        {
            _Assertions.AssertThrows<NullReferenceException>(()
                    => ship.RemoveDefenseModule((uint)ship.DefenseModules.Length), "Weapon slot is already empty");

            _Assertions.AssertThrows<ArgumentOutOfRangeException>(()
                    => ship.RemoveDefenseModule(0), exMsgInvalidSlot);

            _Assertions.AssertThrows<ArgumentOutOfRangeException>(()
                    => ship.RemoveDefenseModule((uint)ship.DefenseModules.Length), exMsgInvalidSlot);

            _Assertions.AssertThrows<ArgumentOutOfRangeException>(()
                    => ship.RemoveDefenseModule((uint)ship.DefenseModules.Length + 1), exMsgInvalidSlot);
        }
        #endregion
    }
}
