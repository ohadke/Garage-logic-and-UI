using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
   internal class Motorcycle : Vehicle
    {
        public eLicenseType m_LicenseType;
        public int m_EngineCapacity;

        internal Motorcycle(PowerSystem i_PowerSystem, string i_Model, string i_LicenseNumber, float i_EnergyPrecentege,
            int i_NumOfWheels, float[] i_WheelsAirPressure, float i_MaxAirPressure,
            string i_WheelsManufacturer,
            string i_OwnerPhoneNumber, string i_OwnerName)

            : base(i_PowerSystem, i_Model, i_LicenseNumber, i_EnergyPrecentege,
                i_NumOfWheels, i_WheelsAirPressure, i_MaxAirPressure,
                i_WheelsManufacturer, i_OwnerPhoneNumber, i_OwnerName)
        {
            
        }

        internal eLicenseType LicenseType
        {
            get
            {
                return this.m_LicenseType;
            }
            set
            {
                this.m_LicenseType = value;
            }
        }
        internal int EngineCapacity
        {
            get
            {
                return this.m_EngineCapacity;
            }
            set
            {
                this.m_EngineCapacity = value;
            }
        }
        public override string ToString()
        {
            StringBuilder Motorcycle = new StringBuilder();
            Motorcycle.AppendLine();
            Motorcycle.AppendFormat(base.ToString());
            Motorcycle.AppendFormat("license type  is: {0}, ", m_LicenseType.ToString());
            Motorcycle.AppendFormat("enginge capacity is: {0}.", m_EngineCapacity.ToString());
            return Motorcycle.ToString();
        }


    }


}
