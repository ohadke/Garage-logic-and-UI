using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        public bool m_IsCarryingDangerousMeterials;
        public int m_CargoCapacity;

        internal Truck(PowerSystem i_PowerSystem, string i_Model, string i_LicenseNumber, float i_EnergyPrecentege,
            int i_NumOfWheels, float[] i_WheelsAirPressure, float i_MaxAirPressure,
            string i_WheelsManufacturer,
            string i_OwnerPhoneNumber, string i_OwnerName)
            : base(i_PowerSystem, i_Model, i_LicenseNumber, i_EnergyPrecentege,
                i_NumOfWheels, i_WheelsAirPressure, i_MaxAirPressure,
                i_WheelsManufacturer, i_OwnerPhoneNumber, i_OwnerName)
        {
            
        }

        internal bool IsCarryingDangerousMeterials
        {
            get
            {
                return this.m_IsCarryingDangerousMeterials;
            }
            set
            {
                this.m_IsCarryingDangerousMeterials = value;
            }
        }
        internal int CargoCapacity
        {
            get
            {
                return this.m_CargoCapacity;
            }
            set
            {
                this.m_CargoCapacity = value;
            }
        }
        public override string ToString()
        {
            StringBuilder truck = new StringBuilder();
            truck.AppendLine();
            truck.AppendFormat(base.ToString());
            truck.AppendFormat("Truck does carry hazardous materials: {0}, ", m_IsCarryingDangerousMeterials.ToString());
            truck.AppendFormat("Cargo volume: {0}.", m_CargoCapacity.ToString());
            return truck.ToString();
        }


    }
}
