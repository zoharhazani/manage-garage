using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        //Get Set
        public float MaxValue
        {
            get
            {
                return m_MaxValue;
            }
            set
            {
                m_MaxValue = value;
            }
        }

        public float MinValue
        {
            get
            {
                return m_MinValue;
            }
            set
            {
                m_MinValue = value;
            }
        }

        //Ctor
        public ValueOutOfRangeException(string message, float minValue, float maxValue) : base(message)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public ValueOutOfRangeException(string message, Exception innerException, int minValue, int maxValue) : base(message, innerException)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }
    }
}
