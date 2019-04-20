using DeathStar.Core.Models.Ships;
using System;

namespace DeathStar.Core.Models.Battles
{
    public class BattleFormation
    {
        public string Name { get; private set; }
        public FormationRow[] Rows { get; private set; }
        public bool IsActive { get; private set; }
        

        public General GeneralInCharge { get; private set; }

        public BattleFormation(string name)
        {
            Name = name;
            Rows = new FormationRow[6];
        }

        public void SetStatus(bool isActive)
        {
            IsActive = isActive;
        }

        /* isp 
         
         Input variables: 
            SelectedShip = valid ship names, invalid ship names 
            amountOfShips = 0, >0
            rowposition = <0, >0 && <6, >=6

         State variables:
            row = empty || null, not empty
            rowPosition = null, ship formation exists
            
        */ 
        public void SetFormationRow(Ship selectedShip, uint amountOfShips, uint rowPosition)
        {
            if (Rows[rowPosition] != null)
            {
                throw new Exception("Slot not empty");
            }
            else if (rowPosition < 6 && rowPosition >=0)
            {
                Rows[rowPosition] = new FormationRow(selectedShip, amountOfShips);
            }
            else
            {
                throw new Exception("Invalid Row Position");
            }
        }

        /* isp 
         
         Input variables: 
            SelectedShip = valid ship names, invalid ship names 
            amountOfShips = 0, >0
            rowposition = <0, >0 && <6, >=6

         State variables:
            row = empty || null, not empty
            rowPosition = null, ship formation exists
            
        */

        public void UpdateFormationRow(Ship selectedShip, uint amountOfShips, uint rowPosition) {
            if (rowPosition < 6 && rowPosition >= 0)
            {
                Rows[rowPosition] = new FormationRow(selectedShip, amountOfShips);
            }
            else
            {
                throw new Exception("Invalid Row Position");
            }
        }

        /* isp 
         
         Input variables: 
            rowposition = <0, >0 && <6, >=6

         State variables:
            row = empty || null, not empty
            rowPosition = null, ship formation exists
            
        */
        public void RemoveFormationRow(uint rowPosition) {
            if (rowPosition < 6 && rowPosition >= 0)
            {
                Rows[rowPosition] = null;
            }
            else
            {
                throw new Exception("Invalid Row Position");
            }
        }

        /* isp 
         
         Input variables: 
            general = null, String

         State variables:
            GeneralInCharge = null, not null
            
        */

        public void SetGeneral(General general)
        {
            if (general is null)
                throw new ArgumentNullException(nameof(general));
            else if(GeneralInCharge != null)
                throw new Exception("General already exists");
            GeneralInCharge = general;
        }

        /* isp 
         
         Input variables: 
            general = null, String

         State variables:
            GeneralInCharge = null, not null
            
        */

        public void UpdateGeneral(General general)
        {
            if (general is null)
                throw new ArgumentNullException(nameof(general));
            GeneralInCharge = general;
        }

        public void SetFormationType(bool isActive = false)
            => IsActive = isActive;
    }
}
