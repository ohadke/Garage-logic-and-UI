using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class FeulPowerSystem : PowerSystem
    { 
        private eEnergyType m_FuelType;

        internal FeulPowerSystem(float i_CurrentCapacity, float i_MaxCapacity, eEnergyType i_FuelType) :
            base(i_CurrentCapacity, i_MaxCapacity)
        {
            m_FuelType = i_FuelType;
        }
        
        internal void AddEnergy(float i_EnergyToAdd, eEnergyType i_eEnergyType)
        {
            if (i_eEnergyType != m_FuelType)
            {
                //throw ex
            }
            else
            {
                base.AddEnergy(i_EnergyToAdd);
            }
        }
        public override string ToString()
        {
            StringBuilder FuelPowerSystem = new StringBuilder();
            FuelPowerSystem.AppendLine();
            FuelPowerSystem.AppendFormat("The type of this engine  is  Fuel engine ");
            FuelPowerSystem.AppendLine();
            FuelPowerSystem.AppendFormat("The type of fuel is used in this vehicle is: {0}.", m_FuelType.ToString());
            return FuelPowerSystem.ToString();
        }


    }
}
