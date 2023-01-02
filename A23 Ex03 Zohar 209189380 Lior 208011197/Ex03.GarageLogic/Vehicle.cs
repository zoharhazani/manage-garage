using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        protected string m_ModelName;
        protected string m_LicenseNumber;
        protected float m_EnergyPercentage;
        protected List<wheel> m_ListOfwheels;
        protected int m_NumOfWheels;
        private float m_MaxAirPresure;

        //get set
        public int NumOfWheels
        {
            get
            {
                return m_NumOfWheels;
            }
            set
            {
                m_NumOfWheels = value;
            }
        }

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }
            set
            {
                m_ModelName = value;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }
            set
            {
                m_LicenseNumber = value;
            }
        }

        public float MaxAirPresure
        {
            get
            {
                return m_MaxAirPresure;
            }
            set
            {
                m_MaxAirPresure = value;
            }
        }

        public float EnergyPercentage
        {
            get
            {
                return m_EnergyPercentage;
            }
            set
            {
                m_EnergyPercentage = value;
            }
        }

        public List<wheel> ListOfwheels
        {
            get
            {
                return m_ListOfwheels;
            }
            set
            {
                m_ListOfwheels = value;
            }
        }

        //Ctor
        public Vehicle()
        {
            ListOfwheels = new List<wheel>();
            EnergyPercentage = 0;
        }

        public Vehicle(string licenseNumber)
        {
            LicenseNumber = licenseNumber;
            EnergyPercentage = 0;
        }
        
        public void InitEnergyPercentage(float i_maxValue, float i_currValue)
        {
            EnergyPercentage = i_currValue / i_maxValue;
        }

        protected void CreateWheels(int i_numOfWheel)
        {
            NumOfWheels = i_numOfWheel;
            for (int i=0;i<i_numOfWheel;i++)
            {
                ListOfwheels.Add(new wheel());
            }
        }

        protected void InitAirPresure(float i_CurrairPresure)
        {
            foreach(wheel wheel in ListOfwheels)
            {
                wheel.CurrAirPressure = i_CurrairPresure;
            }
        }

        public void FillAirPresureToMax()
        {
            foreach (wheel wheel in ListOfwheels)
            {
                wheel.CurrAirPressure =m_MaxAirPresure ;
            }
        }

        public virtual Dictionary<string, string> GetDetails()
        {
            string amountOfAirInTheWheels = "Amount of air in your Wheels: ";

            Dictionary<string, string> dictionary = new Dictionary<string, string>()
            {
                {"AmountOfAirInWheels", amountOfAirInTheWheels }
            };
            return dictionary;
        }
        
        public virtual bool ValidateInputs(string i_keyOfDictionary, string io_userInput, ref string io_ExMessege)
        {           
            return true;
        }

        //Validation function
        protected bool IsInRightRangeFloat(float i_maxValue, float i_minValue, string i_userInput, ref string io_ExMessege)
        {            
            bool isValid;
            try
            {
                // Validate the input
                float num = float.Parse(i_userInput);
                if (num < i_minValue || num > i_maxValue)
                {
                    if (i_maxValue == float.MaxValue)
                    {
   
                        throw new ValueOutOfRangeException("Number is invalid must be above 0.", i_minValue, i_maxValue);
                    }
                    else
                    {
                        throw new ValueOutOfRangeException(string.Format("Number must be between {0} to {1} .", i_minValue, i_maxValue), i_minValue, i_maxValue);
                    }

                }

                // If the input is valid, do something with it
                isValid = true;
            }
            catch (FormatException)
            {
                io_ExMessege = "Invalid input format. Please enter a valid number.";
                isValid = false;
            }
            catch (ValueOutOfRangeException ex)
            {
                io_ExMessege = ex.Message;
                isValid = false;
            }
            return isValid;

        }

        public bool IsInRightRangeInt(int i_maxValue, int i_minValue, string i_userInput, ref string io_ExMessege)
        {            
            bool isValid;
            try
            {
                // Validate the input
                int num = int.Parse(i_userInput);
                if (num < i_minValue || num > i_maxValue)
                {
                    
                    throw new ValueOutOfRangeException(string.Format("Number must be between {0} to {1} .", i_minValue, i_maxValue), i_minValue, i_maxValue);
                }
                // If the input is valid, do something with it
                isValid = true;
            }
            catch (FormatException)
            {
                io_ExMessege = "Invalid input format. Please enter a valid number.";
                isValid = false;
            }
            catch (ValueOutOfRangeException ex)
            {
                io_ExMessege = ex.Message;
                isValid = false;
            }

            return isValid;
        }

        protected bool IsYesOrNoValidation(string i_userInput, ref string io_ExMessege)
        {
            bool isValid;            
            try
            {
                // Validate the input
                if (i_userInput != "yes" && i_userInput != "Yes" && i_userInput != "no" && i_userInput != "No")
                {
                    throw new FormatException("Answer is invalid must be yes or no.");
                }
                else
                {
                    if (i_userInput == "yes" || i_userInput == "Yes")
                    {
                        i_userInput = "True";

                    }
                    else
                    {
                        i_userInput = "False";
                    }
                    isValid = true;
                }

            }
            catch (FormatException ex)
            {
                io_ExMessege = ex.Message;
                isValid = false;
            }

            return isValid;
        }

        public virtual Dictionary<string, string> GetSelectedProperties()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>()
            {
                {"Air Presure", ListOfwheels[0].CurrAirPressure.ToString() },
                {"Model Name", ModelName},
                {"License Number",LicenseNumber },
                {"Number Of Wheels", NumOfWheels.ToString() },
                {"Energy Percentage", EnergyPercentage.ToString() }
                
            };
            return dictionary;
        }
    }
}
