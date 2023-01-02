using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelCar : FuelVehicle
    {
        public const int k_NumOfWheel = 5;
        public const float k_MaxAirPresure = 32;
        public const string k_TypeOfFuel = "Octan95";
        public const float k_MaxAmountOfFuelInLiters = 50;
        public enum eColor
        {
            Red = 1,
            Blue,
            White,
            Gray
        }
        protected int m_NumOfDoors;
        private eColor m_color;

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
                return m_color;
            }
            set
            {
                m_color = value;
            }
        }

        //Ctor
        public FuelCar()
        {
            CreateWheels(k_NumOfWheel);
            InitTypeOfFuel(k_TypeOfFuel);
            InitMaxAmountOfFuelInLiters(k_MaxAmountOfFuelInLiters);
            MaxAirPresure = k_MaxAirPresure;

        }

        //Methods
        public override Dictionary<string, string> GetDetails()
        {
            string color = "What is your car's color? \n 1. Red \n 2. Blue \n 3. White \n 4. Gray";
            string amountOfDoors = "Amount of Doors: ";
            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                {"Color",color},
                {"AmountOfDoors",amountOfDoors }
            };
            foreach (KeyValuePair<string, string> kvp in base.GetDetails())
            {
                dictionary.Add(kvp.Key, kvp.Value);
            }

            return dictionary;
        }

        public override bool ValidateInputs(string key, string userInput, ref string io_ExMessege)
        {
            bool isValid;
            switch (key)
            {
                case "Color":
                    isValid = IsInRightRangeInt(4, 1, userInput, ref io_ExMessege);
                    if (isValid == true) { Color = (eColor)Enum.Parse(typeof(eColor), userInput); }
                    break;

                case "AmountOfDoors":
                    isValid = IsInRightRangeInt(5, 2, userInput, ref io_ExMessege);
                    if (isValid == true) { NumOfDoors = int.Parse(userInput); }
                    break;

                case "AmountOfFuel":
                    isValid = IsInRightRangeFloat(k_MaxAmountOfFuelInLiters, 0, userInput, ref io_ExMessege);
                    if (isValid == true) { CurrentAmountOfFuelInLiters = float.Parse(userInput); }
                    break;
                case "AmountOfAirInWheels":
                    isValid = IsInRightRangeFloat(k_MaxAirPresure, 0, userInput, ref io_ExMessege);
                    if (isValid == true) { InitAirPresure(float.Parse(userInput)); }
                    break;

                default:
                    isValid = false;
                    io_ExMessege = "";
                    break;

            }
            return isValid;
        }

        public override Dictionary<string, string> GetSelectedProperties()
        {
            
            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                {"Color: ",Color.ToString()},
                {"Sum of doors: ",NumOfDoors.ToString() },
                {"Fuel type: ",FuelType.ToString() },
            };
            foreach (KeyValuePair<string, string> kvp in base.GetSelectedProperties())
            {
                dictionary.Add(kvp.Key, kvp.Value);
            }

            return dictionary;
        }          
    }
}
