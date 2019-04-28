using DeathStar.Core.Models.Battles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeathStar.Core.Models.Planets
{
    public class Planet
    {
        public ICollection<BattleFormation> Formations { get; private set; }
        public string Name { get; private set; }
        public uint CivilProduction { get; private set; }
        public uint MilitaryProduction { get; private set; }
        public uint Defense { get; private set; }
        public uint Offense { get; private set; }

        public BattleFormation ActiveOffensiveFormation { get; private set; }
        public BattleFormation ActiveDefensiveFormation { get; private set; }

        public Planet(Planets p)
        {
            switch (p)
            {
                case Planets.Pandora:
                    Name = p.ToString();
                    CivilProduction = 20;
                    MilitaryProduction = 10;
                    Offense = 1;
                    Defense = 2;
                    break;
                case Planets.Desert:
                    Name = p.ToString();
                    CivilProduction = 2;
                    MilitaryProduction = 5;
                    Offense = 5;
                    Defense = 10;
                    break;
                case Planets.Lava:
                    Name = p.ToString();
                    CivilProduction = 10;
                    MilitaryProduction = 20;
                    Offense = 1;
                    Defense = 2;
                    break;
                case Planets.Oceanic:
                    Name = p.ToString();
                    CivilProduction = 5;
                    MilitaryProduction = 10;
                    Offense = 1;
                    Defense = 15;
                    break;
            }
            Formations = new List<BattleFormation>();
        }
        /* isp ActivateFormation()

        Input variables: 
           battleFormation =
           battleFormationType = 

        State variables:


       */
        public void ActivateFormation(BattleFormation battleFormation, BattleFormationType battleFormationType)
        {
            if (battleFormation is null)
                throw new ArgumentNullException(nameof(BattleFormation));
            if (battleFormation.GeneralInCharge == null)
            {
                var article = battleFormationType == BattleFormationType.Offensive ? "an" : "a";
                throw new InvalidOperationException($"A general must be assigned in charge of {battleFormation.Name} formation in your '{Name}' planet to activate it as {article} {battleFormationType.ToString().ToLower()} formation");
            }
            var formation = Formations.SingleOrDefault(f => f.Equals(battleFormation));
            if (formation == null)
                throw new ArgumentException("Formation does not exist");
            if (battleFormationType == BattleFormationType.Offensive)
            {
                battleFormation.SetStatus(true);
                ActiveOffensiveFormation = battleFormation;
            }

            if (battleFormationType == BattleFormationType.Defensive)
            {
                battleFormation.SetStatus(true);
                ActiveDefensiveFormation = battleFormation;
            }

        }
        /* isp AddFormation()

        Input variables: 
           battleFormation =

        State variables:


       */

        public void AddFormation(BattleFormation battleFormation)
        {
            if (battleFormation is null)
                throw new ArgumentNullException(nameof(BattleFormation));
            Formations?.Add(battleFormation);
        }
        /* isp RemoveFormation()

        Input variables: 
           battleFormation =

        State variables:


       */
        public void RemoveFormation(BattleFormation battleFormation)
        {
            if (battleFormation is null)
                throw new ArgumentNullException(nameof(BattleFormation));

            var formations = Formations.Where(f => f.Equals(battleFormation));
            if (formations == null || formations.Count() == 0)
                throw new ArgumentException("Battle formation does not exist");
            
            Formations.Remove(battleFormation);
        }
        /* isp ExistsFormation()

        Input variables: 
           battleFormation =

        State variables:


       */
        public bool ExistsFormation(BattleFormation battleFormation)
        {
            if (battleFormation is null)
                throw new ArgumentNullException(nameof(BattleFormation));
            return Formations?.SingleOrDefault(f => f.Equals(battleFormation)) != null;
        }

        /* isp UpdateFormation()

        Input variables: 
           battleFormation =
           newFormation = 

        State variables:


       */
        public void UpdateFormation(BattleFormation battleFormation, BattleFormation newFormation)
        {
            if (battleFormation is null)
                throw new ArgumentNullException(nameof(battleFormation), "Invalid source formation");
            if (newFormation is null)
                throw new ArgumentNullException(nameof(battleFormation), "Invalid new formation");
            var existingFormation = Formations?.SingleOrDefault(f => f.Equals(battleFormation));

            if (existingFormation != null)
                existingFormation = newFormation;

        }
    }
}
