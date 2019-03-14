using DeathStar.Core.Models.Battles;
using DeathStar.Core.Models.Planets;
using System.Linq;

namespace ProjectDeathStar.Core.Components.Simulation
{
	public class BattleSimulator
	{
		public static BattleResult CalculateBattleResult(Planet offensivePlanet, Planet defensivePlanet)
		{
			var luckForOffensive = GenerateLuck();
			var luckForDefensive = GenerateLuck();

			var planetActiveFormation = offensivePlanet.ActiveOffensiveFormation;
			for (var i = 0; i < 6; i++)
			{

				uint armor = planetActiveFormation.Rows[i].SelectedShip.ArmorStrength;
				var x = armor * planetActiveFormation.Rows[i].ShipAmount;
			}

			var result = new BattleResult();
			//result.AddRound();

			return result;
		}

		public static int GenerateLuck() => 5;
	}
}
