using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{

    public class CreateNewVehicle
    {
        //Wheels amount
        private const int k_MotorcycleWheelsAmount = 2;
        private const int k_CarWheelsAmount = 4;
        private const int k_TruckWheelsAmount = 12;

        //Air pressure
        private const float k_DefaultStartingAirPressure = 0;
        private const float k_MotorcycleWheelsMaxAirPressure = 28;
        private const float k_CarWheelsMaxAirPressure = 30;
        private const float k_TruckWheelsMaxAirPressure = 26;

        //Fuel capacity
        private const float k_TruckMaxGasCapacity = 120;
        private const float k_CarMaxGasCapacity = 42;
        private const float k_MotorcycleMaxGasCapacity = 5.5f;
        private const float k_CarMaxBatteryCapacity = 2.5f;
        private const float k_MotorcycleMaxBatteryCapacity = 1.6f;

        public static Vehicle MakeNewVehicle(eEnergyType i_EnergyType, eVehicleType i_VehicleType, string i_Model,
            string i_LicenseNumber, float[] i_WheelsAirPressure,
            string i_WheelsManufacturer, float i_CurrentEnrgeyLevel,
            string i_OwnerPhoneNumber, string i_OwnerName,object [] i_VehicleParameters)
        
        {
            Vehicle newVehicle = null;
            //i_WheelsAirPressure = new float[2] {1,2};
            float energyPrecentage;
            PowerSystem powerSystem;
            
            switch (i_VehicleType)
            {
                case eVehicleType.Car:
                {
                    if (i_EnergyType != eEnergyType.Electric)
                    {
                         powerSystem = new FeulPowerSystem(i_CurrentEnrgeyLevel, k_CarMaxGasCapacity, i_EnergyType);
                         energyPrecentage = (i_CurrentEnrgeyLevel / k_CarMaxGasCapacity) * 100;

                    }
                    else
                    {
                        powerSystem = new ElectricPowerSystem(i_CurrentEnrgeyLevel, k_CarMaxBatteryCapacity);
                        energyPrecentage = (i_CurrentEnrgeyLevel / k_CarMaxBatteryCapacity) * 100;

                    }
                    newVehicle = new Car(powerSystem, i_Model, 
                        i_LicenseNumber, energyPrecentage, k_CarWheelsAmount, i_WheelsAirPressure,
                        k_CarWheelsMaxAirPressure,
                        i_WheelsManufacturer, i_OwnerPhoneNumber, i_OwnerName);

                   
                    (newVehicle as Car).m_Color = (eCarColor)i_VehicleParameters[0];
                    (newVehicle as Car).m_NumOfDoors = (int)i_VehicleParameters[1];

                    }
                    break;

                case eVehicleType.Motorcycle:
                {
                    if (i_EnergyType != eEnergyType.Electric)
                    {
                        powerSystem = new FeulPowerSystem(i_CurrentEnrgeyLevel, k_MotorcycleMaxGasCapacity, i_EnergyType);
                        energyPrecentage = (i_CurrentEnrgeyLevel / k_MotorcycleMaxGasCapacity) * 100;

                    }
                    else
                    {
                        powerSystem = new ElectricPowerSystem(i_CurrentEnrgeyLevel, k_MotorcycleMaxBatteryCapacity);
                        energyPrecentage = (i_CurrentEnrgeyLevel / k_MotorcycleMaxBatteryCapacity) * 100;

                    }
                    newVehicle = new Motorcycle(powerSystem, i_Model,
                        i_LicenseNumber, energyPrecentage, k_MotorcycleWheelsAmount, i_WheelsAirPressure,
                        k_MotorcycleWheelsMaxAirPressure,
                        i_WheelsManufacturer, i_OwnerPhoneNumber, i_OwnerName);

                        (newVehicle as Motorcycle).m_LicenseType= (eLicenseType)i_VehicleParameters[0];
                        (newVehicle as Motorcycle).m_EngineCapacity = (int)i_VehicleParameters[1];

                    }
                    break;

                case eVehicleType.Truck:
                {
                    if (i_EnergyType != eEnergyType.Electric)
                    {
                        powerSystem = new FeulPowerSystem(i_CurrentEnrgeyLevel, k_TruckMaxGasCapacity, i_EnergyType);
                        energyPrecentage = (i_CurrentEnrgeyLevel / k_TruckMaxGasCapacity) * 100;

                    }
                    else
                    {
                        powerSystem = new ElectricPowerSystem(i_CurrentEnrgeyLevel, k_TruckMaxGasCapacity);
                        energyPrecentage = (i_CurrentEnrgeyLevel / k_TruckMaxGasCapacity) * 100;

                    }
                    newVehicle = new Truck(powerSystem, i_Model,
                        i_LicenseNumber, energyPrecentage, k_TruckWheelsAmount, i_WheelsAirPressure,
                        k_TruckWheelsMaxAirPressure,
                        i_WheelsManufacturer, i_OwnerPhoneNumber, i_OwnerName);

                        (newVehicle as Truck).m_IsCarryingDangerousMeterials =(bool)i_VehicleParameters[0];
                        (newVehicle as Truck).m_CargoCapacity = (int)i_VehicleParameters[1];

                    }
                    break;


            }

            return newVehicle;

        }
    }
}
