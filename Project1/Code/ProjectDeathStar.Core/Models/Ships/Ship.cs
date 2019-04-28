using DeathStar.Core.Models.Equipments;
using System;

namespace DeathStar.Core.Models.Ships
{
	public abstract class Ship
	{
		public string Name { get; protected set; }
		public string PictureUrl { get; protected set; }
		public uint ShieldStrength { get; protected set; }
		public uint ArmorStrength { get; protected set; }
		public uint HullStrength { get; protected set; }
		public uint Range { get; protected set; }

		public Weapon[] Weapons { get; protected set; }
		public EngineeringModule[] EngineeringModules { get; protected set; }
		public DefenseModule[] DefenseModules { get; protected set; }

		protected Ship(string name, string pictureUrl, uint shield, uint armor, uint hull, uint range, uint weaponSlot, uint engineeringSlot, uint defensiveSlot)
		{

			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentNullException(nameof(name));
			}

			Name = name;
			ShieldStrength = shield;
			ArmorStrength = armor;
			HullStrength = hull;
			Range = range;

		}

        /* isp InstallDefensiveModule()
         
         Input variables: 
            defenseModule:
                defenseModule.Size = 
                defenseModule.name = 
            slot =

         State variables:
            DefenseModules [slot -1] = null, defenseModule 
            
        */

        public void InstallDefensiveModule(DefenseModule defenseModule, uint slot)
		{
			if (slot >= DefenseModules.Length)
				throw new ArgumentOutOfRangeException(nameof(slot), "Invalid slot.");


			if (this is Shuttle || this is Corvette || this is Frigate)
			{
				if (defenseModule.Size == DefenseModuleGrades.Small)
				{
					DefenseModules[slot - 1] = defenseModule;
				}
				else
					throw new InvalidOperationException($"Can not install a small '{defenseModule.Name}' defensive module in '{Name}' ship");
			}
			else if (this is Destroyer || this is Cruiser || this is BattleCruiser)
			{
				if (defenseModule.Size == DefenseModuleGrades.Medium)
				{
					DefenseModules[slot - 1] = defenseModule;
				}
				else
					throw new InvalidOperationException($"Can not install a medium '{defenseModule.Name}' defensive module in '{Name}' ship");
			}
			else if (this is Battleship || this is Dreadnaut || this is Juggernaut)
			{
				if (defenseModule.Size == DefenseModuleGrades.Large)
				{
					DefenseModules[slot - 1] = defenseModule;
				}
				else
					throw new InvalidOperationException($"Can not install a large '{defenseModule.Name}' defensive module in '{Name}' ship");
			}
			else if (this is Carrier || this is SuperCarrier)
			{
				if (defenseModule.Size == DefenseModuleGrades.XLarge)
				{
					DefenseModules[slot - 1] = defenseModule;
				}
				else
					throw new InvalidOperationException($"Can not install a xlarge '{defenseModule.Name}' defensive module in '{Name}' ship");
			}
			else if (this is Titan || this is SuperTitan)
			{
				if (defenseModule.Size == DefenseModuleGrades.XXLagre)
				{
					DefenseModules[slot - 1] = defenseModule;
				}
				else
					throw new InvalidOperationException($"Can not install a xxlarge '{defenseModule.Name}' defensive module in '{Name}' ship");
			}
			else if (this is DeathStar)
			{
				if (defenseModule.Size == DefenseModuleGrades.Doomsday)
				{
					DefenseModules[slot - 1] = defenseModule;
				}
				else
					throw new InvalidOperationException($"Can not install a doomsday '{defenseModule.Name}' defensive module in '{Name}' ship");
			}
			else
				throw new InvalidOperationException("Invlid ship");

		}

		public void InstallEngineeringModule(EngineeringModule engineeringModule, int slot)
		{

		}

        /* isp InstallWeapon()
         
         Input variables: 
            weapon: 
                weapon.name = 
                weapon.grade = 
            slot = 

         State variables:
            Weapons[slot - 1] = null, weapon
            
        */

        public void InstallWeapon(Weapon weapon, int slot)
		{

			if (slot < 0 || slot >= Weapons.Length)
				throw new ArgumentOutOfRangeException(nameof(slot), "Invalid slot.");

			if (this is Shuttle || this is Corvette || this is Frigate)
			{
				if (weapon.Grade == WeaponGrades.Small)
				{
					Weapons[slot - 1] = weapon;
				}
				else
					throw new InvalidOperationException($"Can not install a small '{weapon.Name}' weapon in '{Name}' ship");
			}
			else if (this is Destroyer || this is Cruiser || this is BattleCruiser)
			{
				if (weapon.Grade == WeaponGrades.Medium)
				{

					Weapons[slot - 1] = weapon;
				}
				else
					throw new InvalidOperationException($"Can not install a medium '{weapon.Name}' weapon in '{Name}' ship");
			}
			else if (this is Battleship || this is Dreadnaut || this is Juggernaut)
			{
				if (weapon.Grade == WeaponGrades.Large)
				{
					Weapons[slot - 1] = weapon;
				}
				else
					throw new InvalidOperationException($"Can not install a {weapon.Grade} '{weapon.Name}' weapon in '{Name}' ship");
			}
			else if (this is Carrier || this is SuperCarrier)
			{
				if (weapon.Grade == WeaponGrades.XLarge)
				{
					Weapons[slot - 1] = weapon;
				}
				else
					throw new InvalidOperationException($"Can not install a xlarge '{weapon.Name}' weapon in '{Name}' ship");
			}
			else if (this is Titan || this is SuperTitan)
			{
				if (weapon.Grade == WeaponGrades.XXLarge)
				{
					Weapons[slot - 1] = weapon;
				}
				else
					throw new InvalidOperationException($"Can not install a xxlarge '{weapon.Name}' weapon in '{Name}' ship");
			}
			else if (this is DeathStar)
			{
				if (weapon.Grade == WeaponGrades.Doomsday)
				{
					Weapons[slot - 1] = weapon;
				}
				else
					throw new InvalidOperationException($"Can not install a doomsday '{weapon.Name}' weapon in '{Name}' ship");
			}
			else
				throw new InvalidOperationException("Unknown ship");

		}
        /* isp RemoveWeapon()

        Input variables: 
           slot = 

        State variables:
           Weapons[slot - 1] = null, !null

       */

        public void RemoveWeapon(uint slot)
		{
			if (slot >= Weapons.Length)
				throw new ArgumentOutOfRangeException(nameof(slot));
			Weapons[slot - 1] = null;

		}

        /* isp RemoveEngineeringModule()

        Input variables: 
           slot = 

        State variables:
            

       */

        public void RemoveEngineeringModule(uint slot)
		{
			if (slot >= EngineeringModules.Length)
				throw new ArgumentOutOfRangeException(nameof(slot));
			EngineeringModules[slot] = null;

		}

        /* isp RemoveDefenseModule()

        Input variables: 
           slot =

        State variables:
           

       */

        public void RemoveDefenseModule(uint slot)
		{
			if (slot >= DefenseModules.Length)
				throw new ArgumentOutOfRangeException(nameof(slot), "Invalid slot.");
			DefenseModules[slot - 1] = null;

		}

		//public abstract void FireWeapon();

	}
}
