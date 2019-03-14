using System;
using System.Collections.Generic;
using System.Text;

namespace DeathStar.Core.Models.Equipments
{
    public class EngineeringModule
    {
        public string Name { get; protected set; }
        public int KineticDamageEffectFactor { get; protected set; }
        public int ThermalDamageEffectFactor { get; protected set; }
        public int ExplosiveDamageEffectFactor { get; protected set; }
        public int ElectromagneticDamageEffectFactor { get; protected set; }
        public int RangeEffectFactor { get; protected set; }
    }
}
