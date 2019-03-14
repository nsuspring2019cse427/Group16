namespace DeathStar.Core.Models.Ships
{
	public class Battleship : Ship
	{
		internal Battleship(string name, string pictureUrl, uint shield, uint armor, uint hull, uint range, uint weaponSlot, uint engineeringSlot, uint defensiveSlot)
		    : base(name, pictureUrl, shield, armor, hull, range, weaponSlot, engineeringSlot, defensiveSlot)
		{
            switch(name)
            {
                case "Dominix":
                    Weapons = new Equipments.Weapon[7];
                    EngineeringModules = new Equipments.EngineeringModule[5];
                    DefenseModules = new Equipments.DefenseModule[5];
                    break;
                case "Raven":
                    Weapons = new Equipments.Weapon[8];
                    EngineeringModules = new Equipments.EngineeringModule[4];
                    DefenseModules = new Equipments.DefenseModule[5];
                    break;
                case "Scorpion":
                    Weapons = new Equipments.Weapon[8];
                    EngineeringModules = new Equipments.EngineeringModule[3];
                    DefenseModules = new Equipments.DefenseModule[6];
                    break;
                case "Widow":
                    Weapons = new Equipments.Weapon[8];
                    EngineeringModules = new Equipments.EngineeringModule[5];
                    DefenseModules = new Equipments.DefenseModule[4];
                    break;
                case "Rokh":
                    Weapons = new Equipments.Weapon[7];
                    EngineeringModules = new Equipments.EngineeringModule[4];
                    DefenseModules = new Equipments.DefenseModule[6];
                    break;
            }
		}
	}
}
