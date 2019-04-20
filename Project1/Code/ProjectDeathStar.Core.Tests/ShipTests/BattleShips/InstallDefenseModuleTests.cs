using Autofac.Extras.Moq;
using DeathStar.Core.Models.Equipments;
using NUnit.Framework;
using System.Collections.Generic;

namespace ShipTests.BattleShipTests
{
    internal class InstallDefenseModuleTests
        : BattleShipTests
    {
        [SetUp]
        public void Setup()
            => SetupDefensiveModules();

        [Test]
        public void InstallAnyDefensiveModuleInAnyShip_SetModuleInCorrectSlot_InstallationSuccessful()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                var moduleAndSlot = new Dictionary<DefenseModule, uint>
                {
                    { _LargeArmorPlateMock, 1 },
                    { _LargeHullPlateMock, 2 },
                    { _LargeShieldAmplifierMock, 3 }
                };

                //Act

                InstallDefenseModules(Dominix, moduleAndSlot);
                InstallDefenseModules(Raven, moduleAndSlot);
                InstallDefenseModules(Rokh, moduleAndSlot);
                InstallDefenseModules(Scorpion, moduleAndSlot);
                InstallDefenseModules(Widow, moduleAndSlot);


                //weapon.VerifyAll();

                //Assert
                AssertDefensiveModuleSuccefulInstallation(Dominix, moduleAndSlot);

                AssertDefensiveModuleSuccefulInstallation(Raven, new Dictionary<DefenseModule, uint>
                {
                    { _LargeArmorPlateMock, 1 },
                    { _LargeHullPlateMock, 2 },
                    { _LargeShieldAmplifierMock, 3 }
                });

                AssertDefensiveModuleSuccefulInstallation(Rokh, new Dictionary<DefenseModule, uint>
                {
                    { _LargeArmorPlateMock, 1 },
                    { _LargeHullPlateMock, 2 },
                    { _LargeShieldAmplifierMock, 3 }
                });

                AssertDefensiveModuleSuccefulInstallation(Scorpion, new Dictionary<DefenseModule, uint>
                {
                    { _LargeArmorPlateMock, 1 },
                    { _LargeHullPlateMock, 2 },
                    { _LargeShieldAmplifierMock, 3 }
                });

                AssertDefensiveModuleSuccefulInstallation(Widow, new Dictionary<DefenseModule, uint>
                {
                    { _LargeArmorPlateMock, 1 },
                    { _LargeHullPlateMock, 2 },
                    { _LargeShieldAmplifierMock, 3 }
                });
                //Assert.Contains(_LargeArmorPlateMock, Dominix.DefenseModules);
                //Assert.AreEqual(_LargeArmorPlateMock, Dominix.DefenseModules[0]);
                //Assert.Contains(_LargeHullPlateMock, Dominix.DefenseModules);
                //Assert.AreEqual(_LargeHullPlateMock, Dominix.DefenseModules[1]);
                //Assert.Contains(_LargeShieldAmplifierMock, Dominix.DefenseModules);
                //Assert.AreEqual(_LargeShieldAmplifierMock, Dominix.DefenseModules[2]);

                //Assert.Contains(_LargeArmorPlateMock, Raven.DefenseModules);
                //Assert.AreEqual(_LargeArmorPlateMock, Raven.DefenseModules[0]);
                //Assert.Contains(_LargeHullPlateMock, Raven.DefenseModules);
                //Assert.AreEqual(_LargeHullPlateMock, Raven.DefenseModules[1]);
                //Assert.Contains(_LargeShieldAmplifierMock, Raven.DefenseModules);
                //Assert.AreEqual(_LargeShieldAmplifierMock, Raven.DefenseModules[2]);

                //Assert.Contains(_LargeArmorPlateMock, Rokh.DefenseModules);
                //Assert.AreEqual(_LargeArmorPlateMock, Rokh.DefenseModules[0]);
                //Assert.Contains(_LargeHullPlateMock, Rokh.DefenseModules);
                //Assert.AreEqual(_LargeHullPlateMock, Rokh.DefenseModules[1]);
                //Assert.Contains(_LargeShieldAmplifierMock, Rokh.DefenseModules);
                //Assert.AreEqual(_LargeShieldAmplifierMock, Rokh.DefenseModules[2]);

                //Assert.Contains(_LargeArmorPlateMock, Scorpion.DefenseModules);
                //Assert.AreEqual(_LargeArmorPlateMock, Scorpion.DefenseModules[0]);
                //Assert.Contains(_LargeHullPlateMock, Scorpion.DefenseModules);
                //Assert.AreEqual(_LargeHullPlateMock, Scorpion.DefenseModules[1]);
                //Assert.Contains(_LargeShieldAmplifierMock, Scorpion.DefenseModules);
                //Assert.AreEqual(_LargeShieldAmplifierMock, Scorpion.DefenseModules[2]);

                //Assert.Contains(_LargeArmorPlateMock, Widow.DefenseModules);
                //Assert.AreEqual(_LargeArmorPlateMock, Widow.DefenseModules[0]);
                //Assert.Contains(_LargeHullPlateMock, Widow.DefenseModules);
                //Assert.AreEqual(_LargeHullPlateMock, Widow.DefenseModules[1]);
                //Assert.Contains(_LargeShieldAmplifierMock, Widow.DefenseModules);
                //Assert.AreEqual(_LargeShieldAmplifierMock, Widow.DefenseModules[2]);
            }
        }



        [Test]
        public void InstallAnyDefensiveModuleInAnyShip_SetModuleInIncorrectSlot_ThrowsExceptions()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                //Act

                //weapon.VerifyAll();

                //Assert

                AssertThrowsDefensiveModuleInstallation(Dominix, new Dictionary<DefenseModule, (int, int)>
                {
                    { _LargeArmorPlateMock, (Dominix.DefenseModules.Length, Dominix.DefenseModules.Length + 1) },
                    { _LargeHullPlateMock, (Dominix.DefenseModules.Length, Dominix.DefenseModules.Length + 1) },
                    { _LargeShieldAmplifierMock, (Dominix.DefenseModules.Length, Dominix.DefenseModules.Length + 1) }
                });

                AssertThrowsDefensiveModuleInstallation(Raven, new Dictionary<DefenseModule, (int, int)>
                {
                    { _LargeArmorPlateMock, (Raven.DefenseModules.Length, Raven.DefenseModules.Length + 1) },
                    { _LargeHullPlateMock, (Raven.DefenseModules.Length, Raven.DefenseModules.Length + 1) },
                    { _LargeShieldAmplifierMock, (Raven.DefenseModules.Length, Raven.DefenseModules.Length + 1) }
                });

                AssertThrowsDefensiveModuleInstallation(Rokh, new Dictionary<DefenseModule, (int, int)>
                {
                    { _LargeArmorPlateMock, (Rokh.DefenseModules.Length, Rokh.DefenseModules.Length + 1) },
                    { _LargeHullPlateMock, (Rokh.DefenseModules.Length, Rokh.DefenseModules.Length + 1) },
                    { _LargeShieldAmplifierMock, (Rokh.DefenseModules.Length, Rokh.DefenseModules.Length + 1) }
                });

                AssertThrowsDefensiveModuleInstallation(Scorpion, new Dictionary<DefenseModule, (int, int)>
                {
                    { _LargeArmorPlateMock, (Scorpion.DefenseModules.Length, Scorpion.DefenseModules.Length + 1) },
                    { _LargeHullPlateMock, (Scorpion.DefenseModules.Length, Scorpion.DefenseModules.Length + 1) },
                    { _LargeShieldAmplifierMock, (Scorpion.DefenseModules.Length, Scorpion.DefenseModules.Length + 1) }
                });

                AssertThrowsDefensiveModuleInstallation(Widow, new Dictionary<DefenseModule, (int, int)>
                {
                    { _LargeArmorPlateMock, (Widow.DefenseModules.Length, Widow.DefenseModules.Length + 1) },
                    { _LargeHullPlateMock, (Widow.DefenseModules.Length, Widow.DefenseModules.Length + 1) },
                    { _LargeShieldAmplifierMock, (Widow.DefenseModules.Length, Widow.DefenseModules.Length + 1) }
                });
                //AssertThrowsDefensiveModuleInstallation(Raven);
                //AssertThrowsDefensiveModuleInstallation(Rokh);
                //AssertThrowsDefensiveModuleInstallation(Scorpion);
                //AssertThrowsDefensiveModuleInstallation(Widow);

            }
        }


    }
}
