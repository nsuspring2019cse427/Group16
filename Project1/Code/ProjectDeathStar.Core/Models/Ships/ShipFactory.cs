using System;

namespace DeathStar.Core.Models.Ships
{
    public class ShipFactory<TShip>
        where TShip : Ship
    {
        public virtual TShip CreateShip<TShipType>(TShipType type)
            where TShipType : Enum
        {
            var name = type.ToString();
            var exceptionMsg = $"Invalid {name}";
            if (type is Battleships bs)
            {
                switch (bs)
                {
                    case Battleships.Raven:
                        return new Battleship(name, "", 7000, 8000, 5000, 0, 8, 4, 5) as TShip;
                    case Battleships.Dominix:
                        return new Battleship(name, "", 8000, 7000, 5000, 0, 7, 5, 5) as TShip;
                    case Battleships.Scorpion:
                        return new Battleship(name, "", 7000, 7000, 6000, 0, 8, 3, 6) as TShip;
                    case Battleships.Widow:
                        return new Battleship(name, "", 9000, 7000, 4000, 0, 8, 5, 4) as TShip;
                    case Battleships.Rokh:
                        return new Battleship(name, "", 7000, 8000, 5000, 0, 7, 4, 6) as TShip;
                    default:
                        throw new InvalidOperationException(exceptionMsg);
                }
            }
            else if (type is BattleCruisers bc)
            {
                switch (bc)
                {
                    case BattleCruisers.Ferox:
                        return new BattleCruiser(name, "", 3000, 4000, 2000, 0, 6, 4, 4) as TShip;
                    case BattleCruisers.Drake:
                        return new BattleCruiser(name, "", 4000, 3000, 2000, 0, 5, 5, 4) as TShip;
                    case BattleCruisers.Naga:
                        return new BattleCruiser(name, "", 2500, 4500, 2000, 0, 6, 5, 3) as TShip;
                    case BattleCruisers.Nihgthawk:
                        return new BattleCruiser(name, "", 2000, 4000, 3000, 0, 6, 3, 5) as TShip;
                    case BattleCruisers.Vulture:
                        return new BattleCruiser(name, "", 4000, 2000, 3000, 0, 6, 4, 4) as TShip;
                    case BattleCruisers.Oracle:
                        return new BattleCruiser(name, "", 3000, 3000, 3000, 0, 5, 4, 5) as TShip;
                    default:
                        throw new InvalidOperationException(exceptionMsg);
                }
            }

            else if (type is Shuttles st)
            {
                switch (st)
                {
                    case Shuttles.Comet:
                        return new Shuttle(name, "", 300, 500, 200, 0, 1, 2, 1) as TShip;
                    case Shuttles.Griffin:
                        return new Shuttle(name, "", 400, 400, 200, 0, 1, 1, 2) as TShip;
                    default:
                        throw new InvalidOperationException(exceptionMsg);
                }
            }
            else if (type is Titans t)
            {
                switch (t)
                {
                    case Titans.Molok:
                        return new Titan(name, "", 10000, 120000, 10000, 0, 18, 12, 8) as TShip;
                    case Titans.Erebus:
                        return new Titan(name, "", 10000, 10000, 12000, 0, 18, 8, 12) as TShip;
                    case Titans.Avatar:
                        return new Titan(name, "", 12000, 10000, 10000, 0, 18, 10, 10) as TShip;
                    default:
                        throw new InvalidOperationException(exceptionMsg);
                }
            }
            else if (type is Carriers c)
            {
                switch (c)
                {
                    case Carriers.Hel:
                        return new Carrier(name, "", 40000, 50000, 30000, 0, 15, 10, 10) as TShip;
                    case Carriers.Loggerhead:
                        return new Carrier(name, "", 40000, 50000, 30000, 0, 15, 10, 10) as TShip;
                    case Carriers.Revenant:
                        return new Carrier(name, "", 40000, 40000, 40000, 0, 15, 12, 8) as TShip;
                    default:
                        throw new InvalidOperationException(exceptionMsg);
                }
            }

            else if (type is Corvettes cr)
            {
                switch (cr)
                {
                    case Corvettes.Condor:
                        return new Corvette(name, "", 500, 800, 300, 0, 2, 3, 2) as TShip;
                    case Corvettes.Hawk:
                        return new Corvette(name, "", 600, 600, 400, 0, 2, 3, 2) as TShip;
                    case Corvettes.Raptor:
                        return new Corvette(name, "", 400, 700, 500, 0, 3, 2, 2) as TShip;
                    default:
                        throw new InvalidOperationException(exceptionMsg);
                }
            }

            else if (type is SuperCarriers sc)
            {
                switch (sc)
                {
                    case SuperCarriers.Dragon:
                        return new SuperCarrier(name, "", 70000, 70000, 80000, 0, 15, 11, 12) as TShip;
                    case SuperCarriers.Nightmare:
                        return new SuperCarrier(name, "", 70000, 80000, 70000, 0, 16, 10, 12) as TShip;
                    case SuperCarriers.Phantom:
                        return new SuperCarrier(name, "", 80000, 70000, 70000, 0, 16, 12, 10) as TShip;
                    default:
                        throw new InvalidOperationException(exceptionMsg);
                }
            }

            else if (type is Cruisers cru)
            {
                switch (cru)
                {
                    case Cruisers.Blackbird:
                        return new Cruiser(name, "", 2500, 2000, 2000, 0, 5, 2, 5) as TShip;
                    case Cruisers.Caracal:
                        return new Cruiser(name, "", 1500, 3000, 2000, 0, 5, 5, 2) as TShip;
                    case Cruisers.Deimos:
                        return new Cruiser(name, "", 2000, 2500, 2000, 0, 6, 3, 3) as TShip;
                    case Cruisers.Thorax:
                        return new Cruiser(name, "", 2000, 3000, 1500, 0, 5, 4, 3) as TShip;
                    case Cruisers.Vexor:
                        return new Cruiser(name, "", 3000, 2000, 1500, 0, 5, 3, 4) as TShip;
                    default:
                        throw new InvalidOperationException(exceptionMsg);
                }
            }

            else if (type is Deathstars ds)
            {
                switch (ds)
                {
                    case Deathstars.Astero:
                        return new DeathStar(name, "", 1000000, 1000000, 1000000, 0, 3, 3, 5) as TShip;
                    case Deathstars.Dramiel:
                        return new DeathStar(name, "", 900000, 1100000, 1000000, 0, 3, 2, 4) as TShip;
                    case Deathstars.Terminator:
                        return new DeathStar(name, "", 1100000, 1000000, 1000000, 0, 3, 4, 2) as TShip;
                    default:
                        throw new InvalidOperationException(exceptionMsg);
                }
            }

            else if (type is Destroyers dst)
            {
                switch (dst)
                {
                    case Destroyers.Thrasher:
                        return new Destroyer(name, "", 1200, 1500, 1000, 0, 4, 3, 2) as TShip;
                    case Destroyers.Sabre:
                        return new Destroyer(name, "", 1500, 1000, 1200, 0, 5, 2, 3) as TShip;
                    case Destroyers.Bifrost:
                        return new Destroyer(name, "", 1000, 1500, 1200, 0, 4, 3, 2) as TShip;
                    case Destroyers.Nemesis:
                        return new Destroyer(name, "", 1000, 1200, 1500, 0, 5, 3, 2) as TShip;
                    case Destroyers.Incursus:
                        return new Destroyer(name, "", 1300, 1200, 1200, 0, 4, 4, 2) as TShip;
                    default:
                        throw new InvalidOperationException(exceptionMsg);
                }
            }

            else if (type is Dreadnauts drt)
            {
                switch (drt)
                {
                    case Dreadnauts.Moros:
                        return new Dreadnaunt(name, "", 12000, 10000, 8000, 0, 9, 6, 5) as TShip;
                    case Dreadnauts.Naglfar:
                        return new Dreadnaunt(name, "", 9000, 1200, 9000, 0, 9, 5, 6) as TShip;
                    case Dreadnauts.Phoenix:
                        return new Dreadnaunt(name, "", 10000, 12000, 8000, 0, 10, 5, 5) as TShip;
                    case Dreadnauts.Revelation:
                        return new Dreadnaunt(name, "", 10000, 10000, 10000, 0, 10, 4, 6) as TShip;
                    default:
                        throw new InvalidOperationException(exceptionMsg);
                }
            }

            else if (type is Juggernauts jn)
            {
                switch (jn)
                {
                    case Juggernauts.Aeon:
                        return new Juggernaut(name, "", 20000, 30000, 20000, 0, 12, 8, 5) as TShip;
                    case Juggernauts.Archon:
                        return new Juggernaut(name, "", 30000, 20000, 20000, 0, 11, 9, 5) as TShip;
                    case Juggernauts.Nyx:
                        return new Juggernaut(name, "", 25000, 20000, 25000, 0, 12, 7, 6) as TShip;
                    case Juggernauts.Thanatos:
                        return new Juggernaut(name, "", 25000, 25000, 20000, 0, 11, 7, 7) as TShip;
                    default:
                        throw new InvalidOperationException(exceptionMsg);
                }
            }

            else if (type is Frigates f)
            {
                switch (f)
                {
                    case Frigates.Heron:
                        return new Frigate(name, "", 800, 1000, 600, 0, 3, 3, 3) as TShip;
                    case Frigates.Punisher:
                        return new Frigate(name, "", 900, 900, 600, 0, 3, 2, 4) as TShip;
                    case Frigates.Rifter:
                        return new Frigate(name, "", 600, 900, 900, 0, 4, 3, 2) as TShip;
                    case Frigates.Slicer:
                        return new Frigate(name, "", 600, 900, 800, 0, 4, 2, 3) as TShip;
                    case Frigates.Vengeance:
                        return new Frigate(name, "", 1000, 900, 500, 0, 3, 4, 2) as TShip;
                    default:
                        throw new InvalidOperationException(exceptionMsg);
                }
            }

            else if (type is SuperTitans spt)
            {
                switch (spt)
                {
                    case SuperTitans.cynabal:
                        return new SuperTitan(name, "", 300000, 300000, 1000, 0, 20, 12, 8) as TShip;
                    case SuperTitans.Komodo:
                        return new SuperTitan(name, "", 30000, 40000, 20000, 0, 20, 8, 12) as TShip;
                    case SuperTitans.Leviathan:
                        return new SuperTitan(name, "", 20000, 40000, 30000, 0, 20, 10, 10) as TShip;
                    case SuperTitans.Machariel:
                        return new SuperTitan(name, "", 250000, 35000, 30000, 0, 20, 10, 10) as TShip;
                    default:
                        throw new InvalidOperationException(exceptionMsg);
                }
            }

            else throw new InvalidOperationException("Invalid Ship");


        }
    }
}
