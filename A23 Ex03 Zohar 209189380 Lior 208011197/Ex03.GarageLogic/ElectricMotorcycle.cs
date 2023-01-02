using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : ElectricVehicle
    {
        public const int k_NumOfWheel = 2;
        public const float k_MaxAirPresure = 28;
        public const float k_MaxAccumulatorTime = 96f;
        public enum eLicenseType
        {
            A=1,
            A1,
            AA,
            B
        }       
        private int m_engineCapacity;
        private eLicenseType m_LicenseType;
        
        //Get Set
        public int EngineCapacity
        {
            get
            {
                return m_engineCapacity;
            }
            set
            {
                m_engineCapacity = value;
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
        public ElectricMotorcycle()
        {
            CreateWheels(k_NumOfWheel);
            InitMaxAccumulatorTime(k_MaxAccumulatorTime);
            MaxAirPresure = k_MaxAirPresure;
        }

        //Methods
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

        public override bool ValidateInputs(string i_keyOfDictionary,string i_userInput, ref string io_ExMessege)
        {
            bool isValidInput;
            switch (i_keyOfDictionary)
            {
                case "TypeOfLicence":
                    isValidInput = IsInRightRangeInt(4, 1,i_userInput, ref io_ExMessege);
                    if (isValidInput == true) { LicenseType = (eLicenseType)Enum.Parse(typeof(eLicenseType), i_userInput); }
                    break;
                case "EngineCapacity":
                    isValidInput = IsInRightRangeFloat(float.MaxValue, 0, i_userInput, ref io_ExMessege);
                    if (isValidInput == true) { EngineCapacity = int.Parse(i_userInput); }
                    break;
                case "AccumulatorTime":
                    isValidInput = IsInRightRangeFloat(k_MaxAccumulatorTime, 0,i_userInput, ref io_ExMessege);
                    if (isValidInput == true) { AccumulatorTime = float.Parse(i_userInput); }
                    break;
                case "AmountOfAirInWheels":
                    isValidInput = IsInRightRangeFloat(MaxAirPresure, 0, i_userInput, ref io_ExMessege);
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
                {"License Type ",LicenseType.ToString()},
                {"Engine Capacity ", EngineCapacity.ToString()}
                
            };
            foreach (KeyValuePair<string, string> kvp in base.GetSelectedProperties())
            {
                dictionary.Add(kvp.Key, kvp.Value);
            }

            return dictionary;
        }
    }
}
