using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class ElectricPowerSystem : PowerSystem
    {
        internal ElectricPowerSystem(float i_CurrentCapacity, float i_MaxCapacity) : base(i_CurrentCapacity, i_MaxCapacity)
        {

        }

        internal void AddEnergy(float i_EnergyToAdd)
        {
            
            base.AddEnergy(i_EnergyToAdd);
            
        }
        public override string ToString()
        {
            StringBuilder ElectricPowerSystem = new StringBuilder();
            ElectricPowerSystem.AppendLine();
            ElectricPowerSystem.AppendFormat("The type of this engine  is electric ");
            return ElectricPowerSystem.ToString();
        }


    }
}
