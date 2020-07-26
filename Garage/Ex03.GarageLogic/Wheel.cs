using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
   public class Wheel
    {
        private string m_Manufacturer;
        private float m_CurrentAirPressure;


        // $G$ DSN-999 (-4) The "maximum air pressure" field should be readonly member of class wheel.
        private float m_MaxAirPressure;

        internal string Manufacturer
        {
            get
            {
                return m_Manufacturer;
            }
        }

        internal float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
        }

        internal Wheel(float i_AirPressure, float i_MaxAirPressure, string i_Maunfacturer)
        {
            m_CurrentAirPressure = i_AirPressure;
            m_MaxAirPressure = i_MaxAirPressure;
            m_Manufacturer = i_Maunfacturer;
        }
        public void BlowAir(float i_AmountAirToAdd)
        {
            //change air pressure if dosnt exceed the maximum
            if (i_AmountAirToAdd + m_CurrentAirPressure > m_MaxAirPressure)
            {
                // throw exception
            }
            else
            {
                m_CurrentAirPressure = i_AmountAirToAdd + m_CurrentAirPressure;
            }
        }
        public override string ToString()
        {
            StringBuilder Wheel = new StringBuilder();
            Wheel.AppendLine();
            Wheel.AppendFormat("ManuFactur is : {0}, ", m_Manufacturer.ToString());
            Wheel.AppendFormat("Wheel current air pressure: {0}.", m_CurrentAirPressure.ToString());
            Wheel.AppendFormat("Wheel Max air pressure: {0}.", m_MaxAirPressure.ToString());
            return Wheel.ToString();
        }


    }
}
