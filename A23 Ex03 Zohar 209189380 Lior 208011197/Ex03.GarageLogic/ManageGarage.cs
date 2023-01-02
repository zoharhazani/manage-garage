using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Ex03.GarageLogic
{
    public class ManageGarage
    {
        private Garage m_MyGarage;

        //Get Set
        public Garage MyGarage
        {
            get
            {
                return m_MyGarage;
            }
            set
            {
                m_MyGarage = value;
            }
        }

        //Ctor
        public ManageGarage()
        {
            MyGarage = new Garage();
        }

        //Methods
        public bool CheckIfVehicleInGarageAndChangeState(string i_licenceNumber)
        {
           bool isExist = CheckIfVehicleInTheGarage( i_licenceNumber);
            
           if (isExist == true)
            {
               MyGarage.ChangeStateOfVehicle(i_licenceNumber, VehicleInGarage.eState.UnderRepair);
            }
            return isExist;
        }

        public bool CheckIfVehicleInTheGarage(string i_licenceNumber)
        {
            bool isExist = false;
            int idx = MyGarage.CheckIfExistInTheListAndGetIdx(i_licenceNumber);
            if (idx >= 0)
            {
                isExist = true; 
            }
            return isExist;
        }

        public void CreateVehicle(string i_typeOfVehicle , out Vehicle o_vehicle)
        {            
            o_vehicle = ManageVehicles.CreateVehicle(i_typeOfVehicle);            
        }

        public bool AddToTheGarage(Vehicle i_vehicle, string i_licenceNumber,string i_nameOfOwner, string i_phoneNumOfOwner, string i_modelName)
        {
            bool isDetailsValid =  MyGarage.AddVehicleToGarage(i_vehicle, i_licenceNumber, i_nameOfOwner,  i_phoneNumOfOwner, i_modelName);
            return isDetailsValid;
        }

        public List<VehicleInGarage> GetListFromGarageAndPrintLicenceWithFilter(string i_stringState, bool i_ifFilter)
        {
            List<VehicleInGarage> listOfVehicles;                
            VehicleInGarage.eState state;

            switch (i_stringState)
            {
                case "1":
                    state = VehicleInGarage.eState.UnderRepair;
                    listOfVehicles = MyGarage.FilterLicenceByState(state);
                    break;
                case "2":
                    state = VehicleInGarage.eState.Fixed;
                    listOfVehicles = MyGarage.FilterLicenceByState(state);
                    break;
                case "3":
                    state = VehicleInGarage.eState.Paid;
                    listOfVehicles = MyGarage.FilterLicenceByState(state);
                    break;
                default:
                    listOfVehicles = MyGarage.ListOfVehicle;
                    break;
            }
            return listOfVehicles;
        }

        public Dictionary<string, string> GetTheDetails(Vehicle i_vehicle)
        {
            Dictionary<string, string> dictionary = i_vehicle.GetDetails();
            return dictionary;
        }

        public bool CheckSpecificValidationOfDetails(string i_keyOfDictionary,  string i_answerOfUser,ref string o_ExMessege, Vehicle i_vehicle)
        {
            bool isValid;           
            isValid = i_vehicle.ValidateInputs(i_keyOfDictionary,i_answerOfUser,ref o_ExMessege);            
            return isValid;
        }

        public Type[] GetTypesOfVehicle()
        {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            // Filter the types to get only the ones that inherit from Vehicle and have a name different from "FuelVehicle", "Vehicle", or "ElectricVehicle"
            Type[] vehicleTypes = types.Where(t => t.IsSubclassOf(typeof(Vehicle)) && t.Name != "FuelVehicle" && t.Name != "Vehicle" && t.Name != "ElectricVehicle").ToArray();
            return vehicleTypes;
        }

        public void ChangeStateOfVehicle(string i_userChoiceOfState, string i_licenseNum)
        {
            VehicleInGarage.eState state;
            switch (i_userChoiceOfState)
            {
                case "1":
                    state = Ex03.GarageLogic.VehicleInGarage.eState.UnderRepair;
                    MyGarage.ChangeStateOfVehicle(i_licenseNum, state);

                    break;
                case "2":
                    state = Ex03.GarageLogic.VehicleInGarage.eState.Fixed;
                    MyGarage.ChangeStateOfVehicle(i_licenseNum, state);

                    break;
                case "3":
                    state = Ex03.GarageLogic.VehicleInGarage.eState.Paid;
                    MyGarage.ChangeStateOfVehicle(i_licenseNum, state);
                    break;
            }
        }

        public bool FillAirPresureToMax(string i_licenseNum)
        {
            bool isSucceed = false;
            int idxInTheVehicleList = MyGarage.CheckIfExistInTheListAndGetIdx(i_licenseNum);
            if (idxInTheVehicleList >= 0)
            {
                MyGarage.ListOfVehicle[idxInTheVehicleList].VehicleInTheGarage.FillAirPresureToMax();
                isSucceed = true;
            }
            return isSucceed;
        }

        public bool CheckIfFuelVehicle(string i_licenseNum)
        {
            int idx = MyGarage.CheckIfExistInTheListAndGetIdx(i_licenseNum);
            bool isFuelVehicle = false;
            if (MyGarage.ListOfVehicle[idx].VehicleInTheGarage is FuelVehicle)
            {
                isFuelVehicle = true;
            }
            return isFuelVehicle;
        }

        public bool IsTheTypeFitTheTypeOfFuel(string i_licenseNum, string i_typeOfFuel, ref string io_exMessage)
        {           
            bool isValid = true;
            int idx = MyGarage.CheckIfExistInTheListAndGetIdx(i_licenseNum);
            if((MyGarage.ListOfVehicle[idx].VehicleInTheGarage as FuelVehicle).IsItTheCorrectTypeOfFuel(i_typeOfFuel, ref io_exMessage) == false)
            {
                isValid = false;
            }
            return isValid;
        }

        public bool ValidateRightRange(string i_licenseNumber,string i_inputUser, ref string io_exMessege)
        {
            int idx = MyGarage.CheckIfExistInTheListAndGetIdx(i_licenseNumber);
            return (MyGarage.ListOfVehicle[idx].VehicleInTheGarage.IsInRightRangeInt(4, 1, i_inputUser, ref io_exMessege));

        }

        public bool ValidateAmountOfFuelAndRefuel(string i_licenseNumber, ref string io_exMessage, string i_amountOfFuel)
        {
            int idx = MyGarage.CheckIfExistInTheListAndGetIdx(i_licenseNumber);
            return (MyGarage.ListOfVehicle[idx].VehicleInTheGarage as FuelVehicle).Refuel(i_amountOfFuel, ref io_exMessage);
        }

        public bool ValidateChargeTimeAndCharge(string i_licenseNumber, ref string io_exMessage, string i_chargeTime)
        {
            int idx = MyGarage.CheckIfExistInTheListAndGetIdx(i_licenseNumber);
            return (MyGarage.ListOfVehicle[idx].VehicleInTheGarage as ElectricVehicle).BatteryCharging(i_chargeTime, ref io_exMessage);
        }

        public Dictionary<string, string> GetDictionaryOfClientDetails(int i_indexInThEList)
        {
            return MyGarage.ListOfVehicle[i_indexInThEList].GetSelectedProperties();
        }
    }
}
