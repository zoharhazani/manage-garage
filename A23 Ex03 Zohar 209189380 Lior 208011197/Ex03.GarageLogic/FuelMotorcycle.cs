using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelMotorcycle : FuelVehicle
    {
        public const int k_NumOfWheel = 2;
        public const float k_MaxAirPresure = 28;
        public const string k_TypeOfFuel = "Octan98";
        public const float k_MaxAmountOfFuelInLiters = 6;
        public enum eLicenseType
        {
            A=1,
            A1,
            AA,
            B
        }
        private eLicenseType m_LicenseType;
        private int m_EngineCapacity;

        //Get Set
        public int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }
            set
            {
                m_EngineCapacity = value;
            }
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
            set
            {
                m_LicenseType = value;
            }
        }

        //Ctor
        public FuelMotorcycle()
        {
            CreateWheels(k_NumOfWheel);
            InitTypeOfFuel(k_TypeOfFuel);
            InitMaxAmountOfFuelInLiters(k_MaxAmountOfFuelInLiters);
            MaxAirPresure = k_MaxAirPresure;
        }

        public override Dictionary<string, string> GetDetails()
        {
            string typeOfLicence = "What is your Licence type: \n 1. A \n 2. A1 \n 3. AA \n 4. B ";
            string engineCapacity = "Engine Capacity: ";
            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                {"TypeOfLicence",typeOfLicence},
                {"EngineCapacity",engineCapacity }
            };
            foreach (KeyValuePair<string, string> kvp in base.GetDetails())
            {
                dictionary.Add(kvp.Key, kvp.Value);
            }

            return dictionary;
        }

        public override bool ValidateInputs(string i_keyOfDictinary,string i_userInput, ref string io_ExMessege)
        {
            bool isValidInput;
            switch (i_keyOfDictinary)
            {
                case "TypeOfLicence":
                    isValidInput = IsInRightRangeInt(4, 1, i_userInput, ref io_ExMessege);
                    if (isValidInput == true) { LicenseType = (eLicenseType)Enum.Parse(typeof(eLicenseType), i_userInput); }
                    break;

                case "EngineCapacity":
                    isValidInput = IsInRightRangeFloat(float.MaxValue, 0, i_userInput, ref io_ExMessege);
                    if (isValidInput) { EngineCapacity = int.Parse(i_userInput); }
                    break;

                case "AmountOfFuel":
                    isValidInput = IsInRightRangeFloat(k_MaxAmountOfFuelInLiters, 0, i_userInput, ref io_ExMessege);
                    if (isValidInput == true) { CurrentAmountOfFuelInLiters = float.Parse(i_userInput); }
                    break;
                case "AmountOfAirInWheels":
                    isValidInput = IsInRightRangeFloat(k_MaxAirPresure, 0, i_userInput, ref io_ExMessege);
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
                {"Type Of Licence",LicenseType.ToString()},
                {"Engine Capacity",EngineCapacity.ToString() }
            };

            foreach (KeyValuePair<string, string> kvp in base.GetSelectedProperties())
            {
                dictionary.Add(kvp.Key, kvp.Value);
            }

            return dictionary;

        }
    }
}
