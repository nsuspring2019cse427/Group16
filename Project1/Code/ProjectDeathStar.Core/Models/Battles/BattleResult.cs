using System.Collections.Generic;

namespace DeathStar.Core.Models.Battles
{
	public class BattleResult
	{
		public IList<BattleRound> Rounds { get; private set; }
		public BattleStatus Status { get; set; }

		public BattleResult() => Rounds = new List<BattleRound>();

		public void AddRound(BattleFormation offensiveFormation, BattleFormation defensiveFormation) 
			=> Rounds.Add(new BattleRound((uint)Rounds.Count + 1, offensiveFormation, defensiveFormation));
	}
}
