using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
   public abstract class PowerSystem
    {
        public float m_CurrentCapacity;
        private float m_MaxCapacity;

        internal PowerSystem(float i_CurrentCapacity, float i_MaxCapacity)
        {
            m_CurrentCapacity = i_CurrentCapacity;
            m_MaxCapacity = i_MaxCapacity;
        }
        
        internal void AddEnergy(float i_EnergyToAdd)
        {

            if (i_EnergyToAdd + m_CurrentCapacity > m_MaxCapacity)
            {
                // throw ex
            }

            else
            {
                m_CurrentCapacity = i_EnergyToAdd + m_CurrentCapacity;
                //m_EnergyPrecentege = (m_CurrentFeulLitters / m_MaxFeulLitters) * 100;
            }

            //internal abstract void AddEnergy(float i_litersToAdd, eFeulType i_eEnergyType);
            //internal abstract void AddEnergy(float i_hoursToAdd);
        }


    }
}
