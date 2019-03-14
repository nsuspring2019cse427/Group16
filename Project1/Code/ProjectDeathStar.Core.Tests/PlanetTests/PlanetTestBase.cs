using Autofac.Extras.Moq;
using DeathStar.Core.Models.Battles;
using DeathStar.Core.Models.Planets;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

namespace PlanetTests
{
	[TestFixture, ExcludeFromCodeCoverage]
	public abstract class PlanetTestBase
	{
		protected Planet _Planet;
		protected Planet _PlanetMock;
		protected BattleFormation _FormationMock;
		protected General _General;

		public void SetupGeneral()
		{
			using (var mock = AutoMock.GetLoose())
			{
				var generalMock = mock.Mock<General>();
				generalMock.Setup(s => s.Brutality).Returns(1);
				generalMock.Setup(s => s.Foresight).Returns(1);
				generalMock.Setup(s => s.Willpower).Returns(1);
				_General = mock.Create<General>();
			}
		}

		public void SetupFormations()
		{
			using (var mock = AutoMock.GetLoose())
			{
				var formationMock = mock.Mock<BattleFormation>();
				formationMock.Setup(f=>f.GeneralInCharge).Returns(_General);
				formationMock.Setup(s => s.SetGeneral(_General)).Callback(() => { });
				_FormationMock = mock.Create<BattleFormation>();
			}
		}

		public void SetupPandora()
		{
			using (var mock = AutoMock.GetLoose())
			{
				var pandoraMock = mock.Mock<Planet>();
				//pandoraMock.Setup(s => s.AddFormation(_FormationMock)).Callback(()=>{_Planet });
			}
		}
	}
}
