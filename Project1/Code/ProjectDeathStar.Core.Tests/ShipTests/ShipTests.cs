using Autofac.Extras.Moq;
using DeathStar.Core.Models.Ships;
using NUnit.Framework;
using ShipTests.BattleshipTests;
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

		protected ShipTestBase()
			=> _Factory = new ShipFactory<TShip>();

		[TearDown]
		public void Dispose()
		{
			//_Factory = null;
			//_FactoryMock = null;
		}

		public void SetupFactory()
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
