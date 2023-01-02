using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : FuelVehicle
    {
        public const int k_NumOfWheel = 14;
        public const float k_MaxAirPresure = 34;
        public const string k_TypeOfFuel = "Solar";
        public const float k_MaxAmountOfFuelInLiters = 120;
        private bool m_TransportsHazardousMaterials;
        private float m_CargoVolume;

        //Get Set
        public bool TransportsHazardousMaterials
        {
            get
            {
                return m_TransportsHazardousMaterials;
            }
            set
            {
                m_TransportsHazardousMaterials = value;
            }
        }

        public float CargoVolume
        {
            get
            {
                return m_CargoVolume;
            }
            set
            {
                m_CargoVolume = value;
            }
        }

        //Ctor
        public Truck()
        {
            CreateWheels(k_NumOfWheel);
            InitTypeOfFuel(k_TypeOfFuel);
            InitMaxAmountOfFuelInLiters(k_MaxAmountOfFuelInLiters);
            MaxAirPresure = k_MaxAirPresure;
        }

        public override Dictionary<string, string> GetDetails()
        {
            string cargoVolume = "CargoVolume: ";
            string transportsHazardousMaterials = "Does transport Hazardous Materials (yes/no): ";
            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                {"CargoVolume",cargoVolume},
                {"TransportsHazardousMaterials",transportsHazardousMaterials }
            };
            foreach (KeyValuePair<string, string> kvp in base.GetDetails())
            {
                dictionary.Add(kvp.Key, kvp.Value);
            }

            return dictionary;
        }

        public override bool ValidateInputs(string i_keyOfDictionary, string i_userInput, ref string io_ExMessege)
        {
            bool isValid;            
            switch (i_keyOfDictionary)
            {
                case "CargoVolume":
                                       
                    isValid = IsInRightRangeFloat(float.MaxValue, 0, i_userInput, ref io_ExMessege);  
                    if (isValid== true) { CargoVolume = float.Parse(i_userInput); }
                    break;

                case "TransportsHazardousMaterials":
                    isValid = IsYesOrNoValidation(i_userInput, ref io_ExMessege); 
                    if (isValid==true) { TransportsHazardousMaterials = true; }
                    else { TransportsHazardousMaterials = false; }
                    break;

                case "AmountOfFuel":
                    isValid = IsInRightRangeFloat(k_MaxAmountOfFuelInLiters, 0,i_userInput, ref io_ExMessege);
                    if (isValid == true) { CurrentAmountOfFuelInLiters = float.Parse(i_userInput); }
                    break;
                case "AmountOfAirInWheels":
                    isValid = IsInRightRangeFloat(k_MaxAirPresure, 0,i_userInput, ref io_ExMessege);
                    if (isValid == true) { InitAirPresure(float.Parse(i_userInput)); }
                    break;

                default:
                    isValid = false;
                    break;

            }
            return isValid;
        }

        public override Dictionary<string, string> GetSelectedProperties()
        {           
            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                {"Cargo Volume: ",CargoVolume.ToString()},
                {"Transport sHazardou sMaterials: ",TransportsHazardousMaterials.ToString() }

            };
            foreach (KeyValuePair<string, string> kvp in base.GetSelectedProperties())
            {
                dictionary.Add(kvp.Key, kvp.Value);
            }

            return dictionary;
        }

    }
}
