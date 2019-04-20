using System;

namespace DeathStar.Core.Models.Equipments
{
	public class DefenseModule
	{
		public virtual string Name { get; private set; }
		public virtual int ShieldEffectFactor { get; private set; }
		public virtual int ArmorEffectFactor { get; private set; }
		public virtual int HullEffectFactor { get; private set; }

		public virtual DefenseModuleGrades Size { get; private set; }
		public virtual uint Bonus { get; private set; }

		public DefenseModule(DefenseModules defenseModules, DefenseModuleGrades defenseModuleGrades)
		{
			Name = defenseModules.ToString();
			Size = defenseModuleGrades;

			if (defenseModules == DefenseModules.ShieldAmplifier)
			{
				switch (defenseModuleGrades)
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
					case DefenseModuleGrades.Small:
						Bonus = 5;
						break;
                    case DefenseModuleGrades.Doomsday:
                        Bonus = 0;
                        break;
                    default:
						throw new InvalidOperationException("Invalid Size");
				}
			}
			else if (defenseModules == DefenseModules.ArmorPlate)
			{
				Bonus = 0;
			}
			else if (defenseModules == DefenseModules.HullPlate)
			{
				switch (Size)
				{
					case DefenseModuleGrades.Small:
						Bonus = 10;
						break;
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
                        Bonus = 0;
                        break;
                    default:
						throw new InvalidOperationException("Invalid size");
				}
			}
			else
				throw new InvalidOperationException("Invalid defensive module");
		}

	}


}

