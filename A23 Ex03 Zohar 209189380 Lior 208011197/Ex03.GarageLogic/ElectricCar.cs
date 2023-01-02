using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricCar : ElectricVehicle
    {       
        public const int k_NumOfWheel = 5;
        public const float k_MaxAirPresure = 32;
        public const float k_MaxAccumulatorTime = 282f;
        public enum eColor
        {
            Red,
            Blue,
            White,
            Gray
        }
        protected eColor m_Colors;
        protected int m_NumOfDoors;

        //Get Set
        public int NumOfDoors
        {
            get
            {
                return m_NumOfDoors;
            }
            set
            {
                m_NumOfDoors = value;
            }
        }
        
        public eColor Color
        {
            get
            {
                return m_Colors;
            }
            set
            {
                m_Colors = value;
            }
        }

        //Ctor
        public ElectricCar()
        {
            CreateWheels(k_NumOfWheel);
            InitMaxAccumulatorTime(k_MaxAccumulatorTime);
            MaxAirPresure = k_MaxAirPresure;
        }

        //Methods
        public override Dictionary<string, string> GetDetails()
        {
            string color = "What is your car's color? \n 1. Red \n 2. Blue \n 3. White \n 4. Gray";
            string amountOfDoors = "Amount of Doors";
            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                {"Color",color},
                {"AmountOfDoors", amountOfDoors}
            };
            foreach (KeyValuePair<string, string> kvp in base.GetDetails())
            {
                dictionary.Add(kvp.Key, kvp.Value);
            }

            return dictionary;
        }

        public override bool ValidateInputs(string i_keyOfDictionary, string i_userInput, ref string io_ExMessege)
        {
            bool isValidInput= false;
            switch (i_keyOfDictionary)
            {
                case "Color":
                    isValidInput = IsInRightRangeInt(4, 1,i_userInput, ref io_ExMessege);
                    if (isValidInput == true) { Color = (eColor)Enum.Parse(typeof(eColor), i_userInput); }
                    break;
                case "AmountOfDoors":
                    isValidInput = IsInRightRangeInt(5,2,i_userInput, ref io_ExMessege);
                    if (isValidInput == true) { NumOfDoors = int.Parse(i_userInput); }
                    break;
                case "AccumulatorTime":
                    isValidInput = IsInRightRangeFloat(k_MaxAccumulatorTime, 0, i_userInput, ref io_ExMessege);
                    if (isValidInput == true) { AccumulatorTime = float.Parse(i_userInput); }
                    break;
                case "AmountOfAirInWheels":
                    isValidInput = IsInRightRangeFloat(k_MaxAirPresure, 0,i_userInput, ref io_ExMessege);
                    if (isValidInput == true) { InitAirPresure(float.Parse(i_userInput)); }
                    break;
                default:
                    isValidInput = false;
                    break;

            }
            return isValidInput;
        }

        public override Dictionary<string, string> GetSelectedProperties()
        {          
            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                {"Color: ",Color.ToString()},
                {"Amount Of Doors: ", NumOfDoors.ToString()}
            };
            foreach (KeyValuePair<string, string> kvp in base.GetSelectedProperties())
            {
                dictionary.Add(kvp.Key, kvp.Value);
            }

            return dictionary;
        }
    }
}
