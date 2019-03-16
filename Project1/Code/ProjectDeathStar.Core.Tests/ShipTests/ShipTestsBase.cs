using Autofac;
using Autofac.Extras.Moq;
using DeathStar.Core.Models.Equipments;
using DeathStar.Core.Models.Ships;
using Moq;
using NUnit.Framework;
using System;
using System.Diagnostics.CodeAnalysis;

namespace ShipTests
{
    [TestFixture, ExcludeFromCodeCoverage]
    public abstract class ShipTestBase<TShip>
        where TShip : Ship
    {
        protected ShipFactory<TShip> _Factory;
        protected ShipFactory<TShip> _FactoryMock;
        protected Mock<Weapon> _WeaponMock;
        protected Weapon _CannonMock;
        protected Weapon _ProjectileMock;
        protected Weapon _LaserMock;
        protected Weapon _MissileMock;
        protected Weapon _ShockwaveMock;
        protected Weapon _DoomsdayBeamMock;
        protected Weapon _DoomsdayMissileMock;
        protected Weapon _DoomsdayCannonMock;

        protected ShipTestBase()
            => _Factory = new ShipFactory<TShip>();

        [TearDown]
        public void Dispose()
        {
            //_Factory = null;
            //_FactoryMock = null;
        }

        public void SetupWeapons()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var weaponMock = mock.Mock<Weapon>();

                var param = new NamedParameter[2] {
                    new NamedParameter("weapons", Weapons.Cannon),
                    new NamedParameter("weaponGrades", WeaponGrades.Medium)
                };

                _CannonMock = mock.Create<Weapon>(param);

                param = new NamedParameter[2] {
                    new NamedParameter("weapons", Weapons.Projectile),
                    new NamedParameter("weaponGrades", WeaponGrades.Medium)

                };
                _ProjectileMock = mock.Create<Weapon>(param);

                param = new NamedParameter[2] {
                    new NamedParameter("weapons", Weapons.Laser),
                    new NamedParameter("weaponGrades", WeaponGrades.Medium)

                };
                _LaserMock = mock.Create<Weapon>(param);

                param = new NamedParameter[2] {
                    new NamedParameter("weapons", Weapons.Missile),
                    new NamedParameter("weaponGrades", WeaponGrades.Medium)

                };
                _MissileMock = mock.Create<Weapon>(param);

                param = new NamedParameter[2] {
                    new NamedParameter("weapons", Weapons.Shockwave),
                    new NamedParameter("weaponGrades", WeaponGrades.Medium)

                };
                _ShockwaveMock = mock.Create<Weapon>(param);

                param = new NamedParameter[2] {
                    new NamedParameter("weapons", Weapons.DoomsdayBeam),
                    new NamedParameter("weaponGrades", WeaponGrades.Medium)

                };
                _DoomsdayBeamMock = mock.Create<Weapon>(param);

                param = new NamedParameter[2] {
                    new NamedParameter("weapons", Weapons.DoomsdayMissile),
                    new NamedParameter("weaponGrades", WeaponGrades.Medium)

                };
                _DoomsdayMissileMock = mock.Create<Weapon>(param);

                param = new NamedParameter[2] {
                    new NamedParameter("weapons", Weapons.DoomsdayCannon),
                    new NamedParameter("weaponGrades", WeaponGrades.Medium)

                };
                _DoomsdayCannonMock = mock.Create<Weapon>(param);
            }


        }

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


    }
}
