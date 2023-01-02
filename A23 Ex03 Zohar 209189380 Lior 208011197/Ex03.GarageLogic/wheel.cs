using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class wheel
    {
        private string m_ManufacturerName;
        private float m_CurrAirPressure;
        private float m_MaxAirPressure;

        //Get Set
        public string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
            }
            set
            {
                m_ManufacturerName = value;
            }

        }

        public float CurrAirPressure
        {
            get
            {
                return m_CurrAirPressure;
            }
            set
            {
                m_CurrAirPressure = value;
            }

        }

        public float MaxAirPressure
        {
            get
            {
                return m_MaxAirPressure;
            }
            set
            {
                m_MaxAirPressure = value;
            }

        }

        public wheel()
        {

        }

        private void inflatingWheel(float i_airPressur)
        {
            if(CurrAirPressure + i_airPressur >= MaxAirPressure)
            {
                CurrAirPressure += i_airPressur;
            }
            else
            {
                Console.WriteLine("Cannot perform this operation, air pressure above max"); // להעביר לui
            }
        }
    }
}
