using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricVehicle :Vehicle
    {
        //Data Members
        protected float m_AccumulatorTime;
        protected float m_MaxAccumulatorTime;

        //Get Set
        public float AccumulatorTime
        {
            get
            {
                return m_AccumulatorTime;
            }
            set
            {
                m_AccumulatorTime = value;
                base.InitEnergyPercentage(MaxAccumulatorTime, AccumulatorTime);
            }
        }

        public float MaxAccumulatorTime
        {
            get
            {
                return m_MaxAccumulatorTime;
            }
            set
            {
                m_MaxAccumulatorTime = value;
            }
        }

        //Ctor
        public ElectricVehicle()
        {

        }

        //Methods
        protected void InitMaxAccumulatorTime( float i_maxAccumulatorTime)
        {
            MaxAccumulatorTime = i_maxAccumulatorTime;
        }

        public bool BatteryCharging( string i_requestedChargingTime, ref string io_exMessage)
        {
            bool isRechargedSucceed;
            if (IsInRightRangeFloat(MaxAccumulatorTime - AccumulatorTime, 0, i_requestedChargingTime, ref io_exMessage) == false)
            {
                isRechargedSucceed = false;
            }
            else
            {
                isRechargedSucceed = true;
                AccumulatorTime += float.Parse(i_requestedChargingTime);
                base.InitEnergyPercentage(MaxAccumulatorTime, AccumulatorTime);

            }
            return isRechargedSucceed;
        }
     
        public override Dictionary<string, string> GetDetails()
        {
            string accumulatorTime = "Accumulator Time: ";
            Dictionary<string, string> dictionary = new Dictionary<string, string>()
            {
                {"AccumulatorTime in minutes",accumulatorTime }
            };

            foreach (KeyValuePair<string, string> kvp in base.GetDetails())
            {
                dictionary.Add(kvp.Key, kvp.Value);
            }

            return dictionary;
        }

        public override bool ValidateInputs(string key,string io_userInput, ref string io_ExMesege)
        {           
            return true;
        }

        public override Dictionary<string, string> GetSelectedProperties()
        {           
            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                {"Accumulator Time", AccumulatorTime.ToString() }
            };

            foreach (KeyValuePair<string, string> kvp in base.GetSelectedProperties())
            {
                dictionary.Add(kvp.Key, kvp.Value);
            }

            return dictionary;
        }
    }
}
