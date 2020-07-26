using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car: Vehicle
    {
        public eCarColor m_Color;
        public int m_NumOfDoors;
        
        internal Car(PowerSystem i_PowerSystem, string i_Model, string i_LicenseNumber, float i_EnergyPrecentege,
                int i_NumOfWheels, float[] i_WheelsAirPressure, float i_MaxAirPressure,
                string i_WheelsManufacturer,
                string i_OwnerPhoneNumber, string i_OwnerName)
            : base(i_PowerSystem,  i_Model,  i_LicenseNumber,  i_EnergyPrecentege,
                 i_NumOfWheels, i_WheelsAirPressure,  i_MaxAirPressure,
                 i_WheelsManufacturer,i_OwnerPhoneNumber,  i_OwnerName)
        {
            
        }

        internal eCarColor CarColor
        {
            get
            {
                return this.m_Color;
            }
            set
            {
                this.m_Color = value;
            }
        }

        internal int NumDoors
        {
            get
            {
                return this.m_NumOfDoors;
            }
            set
            {
                this.m_NumOfDoors = value;
            }
        }
        public override string ToString()
        {
            StringBuilder Car = new StringBuilder();
            Car.AppendLine();
            Car.AppendFormat(base.ToString());
            Car.AppendFormat("car color is: {0}, ", m_Color.ToString());
            Car.AppendFormat("Number of doors is: {0}.", m_NumOfDoors.ToString());
            return Car.ToString();
        }



    }
}
