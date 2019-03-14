using DeathStar.Core.Models.Battles;
using DeathStar.Core.Models.Planets;
using System.Collections.Generic;

namespace DeathStar.Core.Models.Games
{
    public class Player
    {
        public string Name { get; private set; }
        public string PictureUrl { get; private set; }
        public IList<BattleFormation> Formations { get; private set; }
        public IList<Planet> Planets { get; private set; }
        public IList<General> Generals { get; private set; }
        public IList<BattleResult>BattleHistory { get; private set; }

        public Player()
        {
            Formations = new List<BattleFormation>();
            Planets = new List<Planet>();
            Generals = new List<General>();
            BattleHistory = new List<BattleResult>();
        } 
    }
}
