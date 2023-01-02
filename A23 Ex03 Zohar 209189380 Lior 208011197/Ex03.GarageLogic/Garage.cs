using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private List<VehicleInGarage> m_ListOfVehicle;
       
        //Get Set
        public List<VehicleInGarage> ListOfVehicle
        {
            get
            {
                return m_ListOfVehicle;
            }
            set
            {
                m_ListOfVehicle = value;
            }
        }

        //Ctor
        public Garage()
        {
            ListOfVehicle = new List<VehicleInGarage>();
        }

        public List<VehicleInGarage> FilterLicenceByState(VehicleInGarage.eState i_vehicleState)
        {
            List<VehicleInGarage> filteredListOfVehicle = new List<VehicleInGarage>();
            foreach (VehicleInGarage vehicle in m_ListOfVehicle)
            {
                if (vehicle.State == i_vehicleState)
                {
                    filteredListOfVehicle.Add(vehicle);
                }
            }
            return filteredListOfVehicle;
        }

        public void ChangeStateOfVehicle(string i_licenceNumber, VehicleInGarage.eState i_state)
        {
            int idxOfVehicle = CheckIfExistInTheListAndGetIdx(i_licenceNumber);
            if (idxOfVehicle >= 0)
            {
                ListOfVehicle[idxOfVehicle].State = i_state;
            }
        }

        public int CheckIfExistInTheListAndGetIdx(string i_licenceNumer)
        {
            bool isInTheList = false;
            int count = -1;
            foreach(VehicleInGarage vehicle in ListOfVehicle)
            {
                count++;
                if (vehicle.VehicleInTheGarage.LicenseNumber == i_licenceNumer)
                {
                    vehicle.State = VehicleInGarage.eState.UnderRepair;
                    isInTheList = true;
                    break;
                }                               
            }

            if(isInTheList == false)
            {
                count = -1;
            }
            return count;
           
        }

        public bool AddVehicleToGarage(Vehicle i_vehicle, string i_licenceNumber, string i_nameOfOwner, string i_phoneNumOfOwner, string i_modelName)
        {
            bool isDetailsValid = false;
            VehicleInGarage vehicleInTheGarage = new VehicleInGarage(i_vehicle, i_licenceNumber,i_modelName);
            ListOfVehicle.Add(vehicleInTheGarage);
            if (vehicleInTheGarage.ValidateOwnerPhoneNum(i_phoneNumOfOwner) == true)
            {
                vehicleInTheGarage.InsertDetailsOfOwner(i_nameOfOwner, i_phoneNumOfOwner);
                isDetailsValid = true;
            }
            
            return isDetailsValid;
        }
    }
                      
}
