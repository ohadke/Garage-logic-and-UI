using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Ex03.GarageLogic;

namespace Ex_03_UI
{
    public class UI
    {


        Garage s_mGarage = new Garage();

        public bool Menu()
        {
            int userChosenOption;
            bool isProgramFinish = false;
            string menuMessege = string.Format(@"Hello,and welcome to Ohad&Noy Garage
            Garage Menu:
            1.Add new vehicle to the Garage
            2.Show license plate of  the  Vehicles according to status
            3.Change an Vehicle status
            4.Fill Air in wheels of an vehicle to  max 
            5.Fuel a gas Vehicle
            6.Charge an electric Vehicle
            7.Show Full Vehicle Details according to license plate
            8.Exit
            Enter the matching number to desired Action");
            Console.WriteLine(menuMessege);
            userChosenOption = GetOptionFromUser(8);
            if (userChosenOption == 8)
            {
                isProgramFinish = true;
            }
            else
            {
                missonAccordingToUserInput(userChosenOption);
            }
            return isProgramFinish;
        }


        // $G$ CSS-013 (-5) Bad variable name (should be in the form of: i_CamelCase).
        private string getStringFromUser(string i_msgType)
        {
            Console.WriteLine("Please enter the " + i_msgType + " of the vehicle:");
            return Console.ReadLine();
        }



        private int GetOptionFromUser(int i_MaxPossibleInput)
        {
            bool isAnswerValid = false;
            string inputAnswer;
            int userChosenOption = 0;
            while (!isAnswerValid)
            {
                inputAnswer = Console.ReadLine();
                isAnswerValid = int.TryParse(inputAnswer, out userChosenOption);
                if (isAnswerValid && (userChosenOption > i_MaxPossibleInput || userChosenOption < 1))
                {
                    Console.WriteLine("Sorry,The input is not valid,please try again");
                    isAnswerValid = false;
                }
            }
            return userChosenOption;

        }

        // $G$ CSS-010 (-5) Private methods should start with an lowercase letter.
        private float GetOptionFromUser(float i_MaxPossibleInput)
        {
            bool isAnswerValid = false;
            string inputAnswer;
            float userChosenOption = 0;
            while (!isAnswerValid)
            {
                inputAnswer = Console.ReadLine();
                isAnswerValid = float.TryParse(inputAnswer, out userChosenOption);
                if (isAnswerValid && (userChosenOption > i_MaxPossibleInput || userChosenOption < 1))
                {
                    Console.WriteLine("Sorry,The input is not valid,please try again");
                    isAnswerValid = false;
                }
            }
            return userChosenOption;

        }
        // $G$ CSS-018 (-5) You should have used enumerations here.
        private void missonAccordingToUserInput(int i_UserChosenOption)
        {
            Console.Clear();
            switch (i_UserChosenOption)
            {
                case 1:
                    GetInfoToAddVehicle();
                    break;
                case 2:
                    showAllLicensePlate();
                    break;
                case 3:
                    ChangeCarStatus();
                    break;
                case 4:
                    FillAirInWheels();
                    break;
                case 5:
                    FuelGasVehicle();
                    break;
                case 6:
                    ChargeElectricVehicle();
                    break;
                case 7:
                    ShowVehicleDetails();
                    break;
            }
        }
        private void ChangeCarStatus()
        {
            Console.WriteLine("Please enter license plate number of the vehicle you want to change");
            string desiredPlateNumber = Console.ReadLine();
            string Message = string.Format(@"Choose to which status do you want  to change:
                1.Still in Repair, 2.Repaired, 3.Paid all expenses 
                Please Enter the matching number according to the desired Action");
            Console.WriteLine(Message);
            int userChosenOption = GetOptionFromUser(3);
            try
            {
                s_mGarage.ChangeVehicleStatus(desiredPlateNumber, userChosenOption );
            }
            catch (Exception)
            {
                Console.WriteLine("The License Plate Number you have enteres does not exist in the database\nplease try again\n");
                ChangeCarStatus();
            }


            Console.Clear();
        }
        private void showAllLicensePlate()
        {
            int userChosenOption;
            string Message = string.Format(@"Choose which Vehicles to display:
             1.Still in Repair, 2.Repaired, 3.Paid all expenses, 4.All Vehicles 
             please enter the  number  according to the desired Action");
            Console.WriteLine(Message);
            userChosenOption = GetOptionFromUser(4);
            List<string> vehiclesToPrint = s_mGarage.GetPlateNumbersInGarage(userChosenOption);
            foreach (string currString in vehiclesToPrint)
            {
                Console.WriteLine(currString);
            }
        }

        private void FillAirInWheels()
        {
            Console.WriteLine("Please enter license plate number of the vehicle you want to Fill the air");
            string desiredPlateNumber = Console.ReadLine();
            try
            {
                //s_mGarage.FillMaxAirPressureInWheels(desiredPlateNumber);
            }
            catch (Exception)
            {
                Console.WriteLine("The License Plate Number you have enteres does not exist in the database\nplease try again\n");
                FillAirInWheels();
            }
            Console.Clear();
        }
        private void FuelGasVehicle()
        {
            Console.WriteLine("Please enter license plate number of a gas vehicle you want to change");
            string desiredPlateNumber = Console.ReadLine();
            string Message = string.Format(@"Choose to which Fuel Type to Use:
            1.Octan96, 2.Octan95, 3.Octan98, 4.Soler
            Enter the matching number to desired Action");
            int userChosenFuelOption = GetOptionFromUser(4);
            Console.WriteLine("Enter Desired Amout of Liters to fill Vehicle");
            float userChosenAmountOfFuel = GetOptionFromUser((float)1000);
            try
            {
                s_mGarage.FillFuelVehicle(desiredPlateNumber, userChosenFuelOption - 1, userChosenAmountOfFuel);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The License Plate Number you have enteres does not exist in the database\nplease try again\n");
                FuelGasVehicle();
            }
            catch (Ex03.Excpetion.ValueOutOfRangeException vor)
            {
                Console.WriteLine(vor.Message);
            }

            Console.Clear();
        }
        private void ChargeElectricVehicle()
        {
            Console.WriteLine("Please enter license plate number of an electric vehicle you want to change");
            string desiredPlateNumber = Console.ReadLine();
            Console.WriteLine("Enter Desired Amout of minutes to charge Vehicle");
            float userChosenAmountOfCharge = GetOptionFromUser((float)1000);
            try
            {
                s_mGarage.FillElectricVehicle(desiredPlateNumber, userChosenAmountOfCharge);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The License Plate Number you have enteres does not exist in the database\nplease try again\n");
                FuelGasVehicle();
            }
            catch (Ex03.Excpetion.ValueOutOfRangeException vor)
            {
                Console.WriteLine(vor.Message);
            }

            Console.Clear();
        }
        private void ShowVehicleDetails()
        {
            Console.Clear();
            Console.WriteLine("Please enter license plate number of the vehicle you want to see info about it");
            string desiredPlateNumber = Console.ReadLine();
            string VehicleInfo = "";
            try
            {
                VehicleInfo = s_mGarage.GetInfoToPrint(desiredPlateNumber);
            }
            catch (Exception)
            {
                Console.WriteLine("The License Plate Number you have enteres does not exist in the database\nplease try again\n");
                FillAirInWheels();
            }
            Console.Clear();
            Console.WriteLine(VehicleInfo);
        }
        private void GetInfoToAddVehicle()
        {

            int vehicleType, engineType;
            string carModel, licenseNumber, wheelsManufacturer, ownerPhoneNumber, ownerName;
            float[] wheelsPressure;
            float energyLvl;
            object[] vehicleParameters;

            vehicleType = getVehicleTypeFromUser();
            carModel = getStringFromUser("model");
            licenseNumber = getStringFromUser("licence number");
            wheelsManufacturer = getStringFromUser("wheels manufacturer");
            ownerName = getStringFromUser("name of the owner");
            ownerPhoneNumber = getStringFromUser("phone number of the owner");
            wheelsPressure = getWheelsPressureFromUser(vehicleType);
            energyLvl = getAmountOfEnergyLeft(vehicleType);
            engineType = getTypeOfEngineFromUser(vehicleType);
            vehicleParameters = getVehicleParametersFromUser(vehicleType);

            s_mGarage.InsertVehicleToGarage(engineType, vehicleType, carModel, licenseNumber, wheelsPressure, wheelsManufacturer, energyLvl, ownerPhoneNumber
            , ownerName, vehicleParameters);


            Console.Clear();
        }
        private int getVehicleTypeFromUser()
        {
            string messege = string.Format(@"What type of vehicle would you like to add?
             1. Motorcycle
             2. Car
             3. Truck ");
            Console.WriteLine(messege);
            return GetOptionFromUser(3);
        }

        
        // $G$ CSS-013 (-5) Bad variable name (should be in the form of: i_CamelCase).
        // $G$ CSS-999 (-5) If you use number as a condition --> then you should have use constant here.
        private int getTypeOfEngineFromUser(int i_vehicleType)
        {
            int typeOfEngine = 4;//in case this is truck;
            int engineSelection;
            if (i_vehicleType == 2)//car
            {
                Console.WriteLine("Please Enter The Type of Engine That you Have in your Car 1 for electric ,2 for Octan96");
                engineSelection = GetOptionFromUser(2);
                if (engineSelection == 1)
                {
                    typeOfEngine = 1;
                }
                else
                {
                    typeOfEngine = 2;
                }

            }

            else if (i_vehicleType == 1)//motor
            {
                Console.WriteLine("Please Enter The Type of Engine That you Have in your motorcycle 1 for electric ,2 for Octan95");
                engineSelection = GetOptionFromUser(2);
                if (engineSelection == 1)
                {
                    typeOfEngine = 1;
                }
                else
                {
                    typeOfEngine = 3;
                }

            }
            return typeOfEngine;


        }

        // $G$ DSN-002 (-10) There is no separation between the project of the garage logic and the UI project.
        private float getAmountOfEnergyLeft(int i_vehicleType)
        {
            float maxEnergy = 0, input;
            switch (i_vehicleType)
            {
                case 1:
                    maxEnergy = 5.5f;
                    break;
                case 2:
                    maxEnergy = 1.6f;
                    break;
                case 3:
                    maxEnergy = 42;
                    break;
                case 4:
                    maxEnergy = 2.5f;
                    break;
                case 5:
                    maxEnergy = 120;
                    break;
            }
            Console.WriteLine("Enter current energy (Liters/Hours left):");
            input = float.Parse(Console.ReadLine());
            while (input > maxEnergy || input < 0)
            {
                Console.WriteLine("Error, Try again:");
                input = float.Parse(Console.ReadLine());
            }

            return input;
        }
        private float[] getWheelsPressureFromUser(int i_vehicleType)
        {
            float[] outArray;
            int wheelsNum = 0;
            float maxPressure = 0, input;
            if (i_vehicleType == 1)
            {
                wheelsNum = 2;
                maxPressure = 28;
            }
            else if (i_vehicleType == 2)
            {
                wheelsNum = 4;
                maxPressure = 30;
            }
            else if (i_vehicleType == 3)
            {
                wheelsNum = 16;
                maxPressure = 26;
            }
            outArray = new float[wheelsNum];
            for (int i = 0; i < wheelsNum; i++)
            {
                Console.WriteLine("Enter air pressure for wheel number " + (i+1) + ":");
                input = float.Parse(Console.ReadLine());
                while (input > maxPressure || input < 0)
                {
                    Console.WriteLine("Error, Try again:");
                    input = float.Parse(Console.ReadLine());
                }
                outArray[i] = input;
            }
            return outArray;
        }

        // $G$ DSN-002 (-10) The UI should not know Car\Truck\Motorcycle
        private object[] getVehicleParametersFromUser(int i_vehicleType)
        {
            switch (i_vehicleType)
            {
                case 1:
                    return getMotorcycleParameters();
                case 2:
                    return getCarParameters();
                case 3:
                    return getTruckParameters();
            }
            return null;
        }
        private object[] getCarParameters()
        {
            object[] outArray = new object[2];
            string message = string.Format(@"Enter the car's color:
            1.Yellow
            2.White
            3.Red
            4.black");
            Console.WriteLine(message);
            outArray[0] = GetOptionFromUser(4);
            message = string.Format(@"How many doors the car has?
            2, 3, 4, 5");
            Console.WriteLine(message);
            outArray[1] = GetOptionFromUser(5);
            while ((int)outArray[1] == 1)
            {
                Console.WriteLine("I never heard about a car with one door,please try again ");
                outArray[1] = GetOptionFromUser(5);
            }
            return outArray;
        }
        private object[] getMotorcycleParameters()
        {
            int engineVolume = -1;
            object[] outArray = new object[2];
            string message = string.Format(@"Enter the motorcycle's license type:
            1.A
            2.A1
            3.AB
            4.B1");
            Console.WriteLine(message);
            outArray[0] = GetOptionFromUser(4);
            Console.WriteLine("Enter the engine's volume:");
            engineVolume = int.Parse(Console.ReadLine());
            while (engineVolume < 0)
            {
                Console.WriteLine("Error, Try again:");
                engineVolume = int.Parse(Console.ReadLine());
            }
            outArray[1] = engineVolume;
            return outArray;
        }
        private object[] getTruckParameters()
        {
            float cargoSize = -1;
            object[] outArray = new object[2];
            string msg = string.Format(@"Does the truck carries dangerous meterials?
            1.Yes
            2.No");
            Console.WriteLine(msg);
            outArray[0] = GetOptionFromUser(2) == 1 ? true : false;
            Console.WriteLine("Enter the engine's volume:");
            cargoSize = float.Parse(Console.ReadLine());
            while (cargoSize < 0)
            {
                Console.WriteLine("Error, Try again:");
                cargoSize = float.Parse(Console.ReadLine());
            }
            outArray[1] = cargoSize;
            return outArray;
        }

        public void Farewell()
        {
            Console.WriteLine("Have a Great Day!");
        }

    }
}



    
    
    


