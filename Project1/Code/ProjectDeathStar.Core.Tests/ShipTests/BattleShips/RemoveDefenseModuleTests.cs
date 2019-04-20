using Autofac;
using Autofac.Core;
using Autofac.Extras.Moq;
using DeathStar.Core.Models.Equipments;
using DeathStar.Core.Models.Ships;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ShipTests.BattleShipTests
{
	internal class RemoveDefenseModuleTests
		: BattleShipTests
	{
		[SetUp]
		public void Setup()
			=> SetupDefensiveModules();

		[Test]
		public void RemoveDefenseModule_RemoveFromIncorrectSlots_ThrowsAnException()
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

                InstallDefenseModules(Dominix, moduleAndSlot);
                InstallDefenseModules(Raven, moduleAndSlot);
                InstallDefenseModules(Rokh, moduleAndSlot);
                InstallDefenseModules(Scorpion, moduleAndSlot);
                InstallDefenseModules(Widow, moduleAndSlot);

                //Act



                //weapon.VerifyAll();

                //Assert
                AssertThrowsDefensiveModuleUninstallation(Dominix);
                AssertThrowsDefensiveModuleUninstallation(Raven);
                AssertThrowsDefensiveModuleUninstallation(Rokh);
                AssertThrowsDefensiveModuleUninstallation(Scorpion);
                AssertThrowsDefensiveModuleUninstallation(Widow);
            }
		}
	}
}
