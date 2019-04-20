using DeathStar.Core.Models.Equipments;
using DeathStar.Core.Models.Ships;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShipTests.BattleShipTests
{
    internal abstract class BattleShipTests : ShipTestBase<Battleship>
    {
        protected readonly Battleship Dominix;
        protected readonly Battleship Raven;
        protected readonly Battleship Rokh;
        protected readonly Battleship Scorpion;
        protected readonly Battleship Widow;

        protected BattleShipTests()
            : base()
        {
            Dominix = _Factory.CreateShip(Battleships.Dominix);
            Raven = _Factory.CreateShip(Battleships.Raven);
            Rokh = _Factory.CreateShip(Battleships.Rokh);
            Scorpion = _Factory.CreateShip(Battleships.Scorpion);
            Widow = _Factory.CreateShip(Battleships.Widow);
        }

        
    }
}
