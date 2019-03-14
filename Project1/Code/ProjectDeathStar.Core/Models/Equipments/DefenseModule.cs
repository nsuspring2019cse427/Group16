namespace DeathStar.Core.Models.Equipments
{
    public class DefenseModule
    {
        public string Name { get; private set; }
        public int ShieldEffectFactor { get; private set; }
        public int ArmorEffectFactor { get; private set; }
        public int HullEffectFactor { get; private set; }

        public DefenseModuleGrades Size { get; private set; }
        public uint Bonus { get; private set; }

        public DefenseModule(DefenseModules defensiveModules, DefenseModuleGrades defensiveWeaponGrades)
        {
            Name = defensiveModules.ToString();
            Size = defensiveWeaponGrades;
            if (defensiveModules == DefenseModules.ShieldAmplifier)
            {
                switch (Size)
                {
                    case DefenseModuleGrades.Medium:
                        Bonus = 20;
                        break;
                    case DefenseModuleGrades.Large:
                        Bonus = 50;
                        break;
                    case DefenseModuleGrades.XLarge:
                        Bonus = 100;
                        break;
                    case DefenseModuleGrades.XXLagre:
                        Bonus = 500;
                        break;
                    case DefenseModuleGrades.Doomsday:
                        Bonus = 500;
                        break;
                    case DefenseModuleGrades.Small:
                    default:
                        Bonus = 5;
                        break;
                }
            }
            else if (defensiveModules == DefenseModules.HullPlate)
            {
                switch (Size)
                {
                    case DefenseModuleGrades.Medium:
                        Bonus = 20;
                        break;
                    case DefenseModuleGrades.Large:
                        Bonus = 50;
                        break;
                    case DefenseModuleGrades.XLarge:
                        Bonus = 100;
                        break;
                    case DefenseModuleGrades.XXLagre:
                        Bonus = 500;
                        break;
                    case DefenseModuleGrades.Doomsday:
                        Bonus = 500;
                        break;
                    case DefenseModuleGrades.Small:

                    default:
                        Bonus = 10;
                        break;
                }

            }
        }

    }


}

