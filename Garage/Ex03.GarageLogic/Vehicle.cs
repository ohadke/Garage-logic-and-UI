using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
   public abstract class Vehicle
   {
        public PowerSystem m_PowerSystem;
        private string m_Model;


        // $G$ NTT-999 (-5) This kind of field should be readonly.
        private string m_LicenseNumber;
        private eCarStatus m_CarStatus;
        protected float m_EnergyPrecentege;
        private Wheel[] m_Wheels;
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;

        internal Vehicle(PowerSystem i_PowerSystem, string i_Model, string i_LicenseNumber, float i_EnergyPrecentege,
            int i_NumOfWheels, float[] i_WheelsAirPressure, float i_MaxAirPressure,
            string i_WheelsManufacturer,
            string i_OwnerPhoneNumber, string i_OwnerName)

        {
            m_PowerSystem = i_PowerSystem;
            m_EnergyPrecentege = i_EnergyPrecentege;
            m_LicenseNumber = i_LicenseNumber;
            m_Model = i_Model;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_OwnerName = i_OwnerName;
            m_CarStatus = eCarStatus.InRepair;
            m_Wheels = new Wheel[i_NumOfWheels];

            for (int i = 0; i < i_NumOfWheels; i++)
            {
                m_Wheels[i] = new Wheel(i_WheelsAirPressure[i], i_MaxAirPressure, i_WheelsManufacturer);
            }

        }

        internal void AddEnergy(float i_EnergyToAdd)
        {
            ElectricPowerSystem electricPowerSystem = m_PowerSystem as ElectricPowerSystem;
            if (electricPowerSystem != null)
            {
                electricPowerSystem.AddEnergy(i_EnergyToAdd);
            }
            else
            {
                {
                    //throe ex
                }
            }
        }

        internal void AddEnergy(float i_EnergyToAdd, eEnergyType i_EnergyType)
        {
            FeulPowerSystem e = m_PowerSystem as FeulPowerSystem;
            if (e != null)
            {
                e.AddEnergy(i_EnergyToAdd, i_EnergyType);
            }
            else
            {
                {
                    //throe ex
                }
            }
        }


        internal string LicensePlate
        {
            get
            {
                return (this.m_LicenseNumber);
            }
        }
        
        internal eCarStatus CarStatus
        {
            get
            {
                return this.m_CarStatus;
            }
            set
            {
                this.m_CarStatus = value;
            }
        }
      
        internal Wheel[] Wheels
        {
            get
            {
                return this.m_Wheels;
            }
        }
        public override string ToString()
        {
            StringBuilder vehicleString = new StringBuilder();
            vehicleString.AppendFormat("Model Name: {0}, ", m_Model);
            vehicleString.AppendFormat("License Number: {0} , ", m_LicenseNumber);
            vehicleString.AppendFormat("Remaining Energy: {0}% ", m_EnergyPrecentege);
            vehicleString.AppendLine();
            vehicleString.AppendFormat("Energy Source: {0}", m_PowerSystem.ToString());
            vehicleString.AppendLine();
            vehicleString.AppendFormat("Vehicle statuse: {0}", m_CarStatus.ToString());
            vehicleString.AppendLine();
            vehicleString.AppendFormat("Wheels: ");
            vehicleString.AppendLine();
            foreach (Wheel wheel in m_Wheels)
            {
                vehicleString.AppendFormat(wheel.ToString());
                vehicleString.AppendLine();
            }
            return vehicleString.ToString();
        }

    }


}
