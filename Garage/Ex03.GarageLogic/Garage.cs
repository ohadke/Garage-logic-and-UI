using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        List<Vehicle> m_VehicleDB;

        public Garage()
        {
            m_VehicleDB = new List<Vehicle>();

        }


        public void InsertVehicleToGarage(int i_EnergyType, int i_WhichVehicleType, string i_Model,
            string i_LicenseNumber, float[] i_WheelsAirPressure,
            string i_WheelsManufacturer, float i_EnergyLeft,
            string i_OwnerPhoneNumber, string i_OwnerName, object[] i_VehicleParameters)
        {
            Vehicle newVehicle = CreateNewVehicle.MakeNewVehicle((eEnergyType)i_EnergyType, (eVehicleType)i_WhichVehicleType,
                i_Model, i_LicenseNumber, i_WheelsAirPressure, i_WheelsManufacturer, i_EnergyLeft, i_OwnerPhoneNumber
                , i_OwnerName, i_VehicleParameters);
            m_VehicleDB.Add(newVehicle);
        }

        public void ChangeVehicleStatus(string i_PlateNum, int i_newStatusEnumIndx)
        {
            Vehicle vehicleToChange = (FindVehicleInDB(i_PlateNum));
            if (vehicleToChange != null)
            {
                vehicleToChange.CarStatus = (eCarStatus)i_newStatusEnumIndx;
            }
        }

        private Vehicle FindVehicleInDB(string i_PlateNum)
        {

            foreach (Vehicle currVehicle in m_VehicleDB)
            {
                if (currVehicle.LicensePlate == i_PlateNum)
                {
                    return currVehicle;
                }
            }
            throw new ArgumentException();
        }

        public void FillFuelVehicle(string i_PlateNum, int i_FuelTypeEnumIndx, float i_amountToAdd)
        {
            Vehicle vehicleToFeul = (FindVehicleInDB(i_PlateNum));
            if (vehicleToFeul != null)
            {
                vehicleToFeul.AddEnergy(i_amountToAdd, (eEnergyType)i_FuelTypeEnumIndx);
            }
        }

        public void FillElectricVehicle(string i_PlateNum, float i_AmountToAdd)
        {
            Vehicle vehicleToChange = (FindVehicleInDB(i_PlateNum));
            if (vehicleToChange != null)
            {
                vehicleToChange.AddEnergy(i_AmountToAdd);
            }
        }

        public List<string> GetPlateNumbersInGarage(int i_StatusEnumIndx)
        {
            Console.Clear();
            List<string> PlatesToPrint = new List<string>();
            foreach (Vehicle currVehicle in m_VehicleDB)
            {
                if (i_StatusEnumIndx == 4 || (int)currVehicle.CarStatus == i_StatusEnumIndx)
                {
                    PlatesToPrint.Add(currVehicle.LicensePlate);
                }
            }

            return PlatesToPrint;
        }

        public void BlowWheelsToMax()
        {

        }

        public string GetInfoToPrint(string i_PlateNum)
        {
            Vehicle vehicleInfo = (FindVehicleInDB(i_PlateNum));
            return vehicleInfo.ToString();
        }


    }
}

