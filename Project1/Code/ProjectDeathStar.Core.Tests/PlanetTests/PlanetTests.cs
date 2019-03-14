using DeathStar.Core.Models.Planets;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

namespace PlanetTests.PandoraTests
{
	
	public class InstanceTests
		: PlanetTestBase
	{

		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void CreatePlanet_CreatePandora_ReturnsCorrectInstance()
		{
			//Arrange
			var pandora = new Planet(Planets.Pandora);
			//Act

			//Assert
			Assert.AreEqual(20, pandora.CivilProduction);
			Assert.AreEqual(10, pandora.MilitaryProduction);
			Assert.AreEqual(1, pandora.Offense);
			Assert.AreEqual(2, pandora.Defense);
		}
	}
}
