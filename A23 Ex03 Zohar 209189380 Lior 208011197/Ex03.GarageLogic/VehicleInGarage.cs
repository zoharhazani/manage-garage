using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleInGarage
    {
        public enum eState
        {
            UnderRepair = 1,
            Fixed,
            Paid
        }
        private Owner m_OwnerOfVehicle;
        private eState m_State;
        private Vehicle m_VehicleInTheGarage;

        //get set
        public eState State
        {
            get
            {
                return m_State;
            }
            set
            {
                m_State = value;
            }

        }

        public Vehicle VehicleInTheGarage
        {
            get
            {
                return m_VehicleInTheGarage;
            }
            set
            {
                m_VehicleInTheGarage = value;
            }
        }

        public Owner OwnerOfVehicle
        {
            get
            {
                return m_OwnerOfVehicle;
            }
            set
            {
                m_OwnerOfVehicle = value;
            }
        }

        //Ctor        
        public VehicleInGarage(Vehicle vehicleInTheGarage, string licenceNumber, string modelName)
        {
            VehicleInTheGarage = new Vehicle();
            VehicleInTheGarage = vehicleInTheGarage;
            VehicleInTheGarage.LicenseNumber = licenceNumber;
            VehicleInTheGarage.ModelName = modelName;
            State = eState.UnderRepair;
        }

        public VehicleInGarage(string licenceNumber)
        {
            VehicleInTheGarage = new Vehicle();
            VehicleInTheGarage.LicenseNumber = licenceNumber;
        }

        public void InsertDetailsOfOwner(string i_nameOfCarsOwner, string i_phoneNumberOfOwner)
        {
            OwnerOfVehicle = new Owner();
            OwnerOfVehicle.Name = i_nameOfCarsOwner;
            OwnerOfVehicle.PhoneNumber = i_phoneNumberOfOwner;            
        }

        public bool ValidateOwnerPhoneNum(string i_phoneNumOfOwner)
        {
            int phoneNumOfOwner;
            bool isValid = true;
            if(int.TryParse(i_phoneNumOfOwner, out phoneNumOfOwner) == false)
            {
                isValid = false;
            }
            return isValid;

        }

        public Dictionary<string, string> GetSelectedProperties()
        {

            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                {"Car's state: ",State.ToString()},
                {"Owner's name:  ", OwnerOfVehicle.Name },
                {"Owner's phone number: ",OwnerOfVehicle.PhoneNumber }

            };
            foreach (KeyValuePair<string, string> kvp in VehicleInTheGarage.GetSelectedProperties())
            {
                dictionary.Add(kvp.Key, kvp.Value);
            }

            return dictionary;
        }
    }
}

