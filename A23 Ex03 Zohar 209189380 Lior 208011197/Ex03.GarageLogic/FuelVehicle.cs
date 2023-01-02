using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelVehicle : Vehicle
    {
        //Data members
        public enum efuelType
        {
            Solar=1,
            Octan95,
            Octan96,
            Octan98
        }
        protected efuelType m_FuelType;
        protected float m_CurrentAmountOfFuelInLiters;
        protected float m_MaxAmountOfFuelInLiters;

        //Get Set
        public float CurrentAmountOfFuelInLiters
        {
            get
            {
                return m_CurrentAmountOfFuelInLiters;
            }
            set
            {
                m_CurrentAmountOfFuelInLiters = value;
                base.InitEnergyPercentage(MaxAmountOfFuelInLiters, CurrentAmountOfFuelInLiters);

            }
        }

        public float MaxAmountOfFuelInLiters
        {
            get
            {
                return m_MaxAmountOfFuelInLiters;
            }
            set
            {
                m_MaxAmountOfFuelInLiters = value;
            }
        }

        public efuelType FuelType
        {
            get
            {
                return m_FuelType;
            }
            set
            {
                m_FuelType = value;
            }

        }

        //Ctor
        public FuelVehicle()
        {

        }

        // methods
        public bool Refuel(string i_fuelInLiters, ref string io_exMessage)
        {
            bool isRefueledSucceed = false; 
            if (IsInRightRangeFloat(MaxAmountOfFuelInLiters - CurrentAmountOfFuelInLiters, 0, i_fuelInLiters, ref io_exMessage)==false )
            {
                isRefueledSucceed = false;
            }
            else
            {
                isRefueledSucceed = true;
                CurrentAmountOfFuelInLiters = CurrentAmountOfFuelInLiters + float.Parse(i_fuelInLiters);
                base.InitEnergyPercentage(MaxAmountOfFuelInLiters, CurrentAmountOfFuelInLiters);
            }
            return isRefueledSucceed;
        }

        protected void InitTypeOfFuel(string i_typeOfFuel)
        {
            switch (i_typeOfFuel)
            {
                case "Solar":
                    FuelType = efuelType.Solar;
                    break;
                case "Octan95":
                    FuelType = efuelType.Octan95;
                    break;
                case "Octan96":
                    FuelType = efuelType.Octan96;
                    break;
                case "Octan98":
                    FuelType = efuelType.Octan98;
                    break;
            }
        }

        protected void InitMaxAmountOfFuelInLiters(float i_maxAmountOfFuelInLiters)
        {
            MaxAmountOfFuelInLiters = i_maxAmountOfFuelInLiters;
        }

        public override Dictionary<string, string> GetDetails()
        {            
            string amountOfFuel = "Amount of fuel: ";

            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                {"AmountOfFuel",amountOfFuel }
            };

            foreach (KeyValuePair<string, string> kvp in base.GetDetails())
            {
                dictionary.Add(kvp.Key, kvp.Value);
            }

            return dictionary;
        }

        public override bool ValidateInputs(string i_keyOfDictionary,string io_userInput, ref string io_exMesege)
        {           
            return true;
        }

        public bool IsItTheCorrectTypeOfFuel(string i_userInputTypeOfFuel, ref string io_exMessege)
        {         
            bool isValid;
            try
            {
                // Validate the input               
                if ( FuelType != (efuelType)int.Parse(i_userInputTypeOfFuel))
                {

                    throw new ArgumentException(string.Format("Wrong type of fuel"));
                }
                isValid = true;
            }
            catch (ArgumentException ex)
            {               
                isValid = false;
                io_exMessege = ex.Message;
            }
            return isValid;
        }

        public override Dictionary<string, string> GetSelectedProperties()
        {            
            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                {"Fuel in liters", CurrentAmountOfFuelInLiters.ToString()}
            };

            foreach (KeyValuePair<string, string> kvp in base.GetSelectedProperties())
            {
                dictionary.Add(kvp.Key, kvp.Value);
            }

            return dictionary;
        }
    }
}
