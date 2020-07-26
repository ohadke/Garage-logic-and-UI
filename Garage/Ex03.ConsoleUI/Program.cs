using System;
using Ex_03_UI;
using Ex03.GarageLogic;

namespace Main_Program

{



    class Program
    {

        public static void Main()
        {
            //float[] i_WheelsAirPressure = new float[2] { 1, 2};
           
            UI program = new UI();
            while (!program.Menu()) ;
            program.Farewell();

              

        }
    }
}