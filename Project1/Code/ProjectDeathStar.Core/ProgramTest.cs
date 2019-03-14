using DeathStar.Core.Models.Battles;
using DeathStar.Core.Models.Equipments;
using DeathStar.Core.Models.Planets;
using DeathStar.Core.Models.Ships;
using ProjectDeathStar.Core.Components.Simulation;

namespace ProjectDeathStar.Core
{
    internal class ProgramTest
    {
        public static void Main(string[] args)
        {
            //var battleship = Battleship.CreateBattleShip("Raven");

            var factory = new ShipFactory<Battleship>();

            var raven = factory.CreateShip(Battleships.Raven);
            var dominix = factory.CreateShip(Battleships.Dominix);
            var rokh = factory.CreateShip(Battleships.Rokh);
            var scorpion = factory.CreateShip(Battleships.Scorpion);

            var canon = new Weapon(Weapons.Cannon, WeaponGrades.Large);
            var projectile = new Weapon(Weapons.Projectile, WeaponGrades.Large);
            var laser = new Weapon(Weapons.Laser, WeaponGrades.Large);
            var missile = new Weapon(Weapons.Missile, WeaponGrades.Large);

            raven.InstallWeapon(canon, 1);
            dominix.InstallWeapon(projectile, 1);
            rokh.InstallWeapon(laser, 1);
            scorpion.InstallWeapon(missile, 1);

            var attackingPlanetOffensiveFormation = new BattleFormation("ap of");
            var attackingPlanetDefensiveFormation = new BattleFormation("ap df");
            var defensivePlanetOffensiveFormation = new BattleFormation("dp of");
            var defensivePlanetDefensiveFormation = new BattleFormation("dp df");

            attackingPlanetOffensiveFormation.SetFormationRow(raven, 100, 1);
            attackingPlanetDefensiveFormation.SetFormationRow(dominix, 100, 1);
            defensivePlanetOffensiveFormation.SetFormationRow(raven, 100, 1);
            defensivePlanetDefensiveFormation.SetFormationRow(raven, 100, 1);
            

            var attackingPlanetOffensiveFormationGeneral = new General();
            var attackingPlanetDefensiveFormationGeneral = new General();
            var defensivePlanetOffensiveFormationGeneral = new General();
            var defensivePlanetDefensiveFormationGeneral = new General();

            attackingPlanetOffensiveFormation.SetGeneral(attackingPlanetOffensiveFormationGeneral);
            attackingPlanetDefensiveFormation.SetGeneral(attackingPlanetDefensiveFormationGeneral);
            defensivePlanetDefensiveFormation.SetGeneral(defensivePlanetDefensiveFormationGeneral);
            defensivePlanetOffensiveFormation.SetGeneral(defensivePlanetOffensiveFormationGeneral);

            var attackingPlanet = new Planet(Planets.Pandora);
            var defensivePlanet = new Planet(Planets.Desert);

            attackingPlanet.AddFormation(attackingPlanetOffensiveFormation);
            attackingPlanet.AddFormation(attackingPlanetDefensiveFormation);
            defensivePlanet.AddFormation(defensivePlanetOffensiveFormation);
            defensivePlanet.AddFormation(defensivePlanetDefensiveFormation);

            attackingPlanet.ActivateFormation(attackingPlanetOffensiveFormation, BattleFormationType.Offensive);
            attackingPlanet.ActivateFormation(attackingPlanetDefensiveFormation, BattleFormationType.Defensive);
            defensivePlanet.ActivateFormation(defensivePlanetOffensiveFormation, BattleFormationType.Offensive);
            defensivePlanet.ActivateFormation(defensivePlanetDefensiveFormation, BattleFormationType.Defensive);

            BattleSimulator.CalculateBattleResult(attackingPlanet, defensivePlanet);
        }
    }
}
