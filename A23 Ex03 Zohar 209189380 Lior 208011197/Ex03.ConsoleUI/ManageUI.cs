using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Ex03.ConsoleUI
{
    public class ManageUI
    {
        //Data Members
        private Ex03.GarageLogic.ManageGarage m_ManageGarage;
        private Ex03.GarageLogic.Garage Garage = new GarageLogic.Garage();

        //Ctor
        public ManageUI()
        {
            ManageGarage = new Ex03.GarageLogic.ManageGarage();
            ConsoleUI.Print("\n\t\t\t\t Welcome to S.H.GARAGE, the best garage in the city ! :)\n");
           initSystem();
        }

        //Get Set
        public Ex03.GarageLogic.ManageGarage ManageGarage
        {
            get
            {
                return m_ManageGarage;
            }
            set
            {
                m_ManageGarage = value;
            }
        }

        private void initSystem()
        {
                      
           string userChoise =  ConsoleUI.DisplayMenuOfOperationsAndChooseOption();
           navigateToTheDesiredFunction(userChoise);

        }

        private void navigateToTheDesiredFunction(string i_userChoise)
        {
            switch (i_userChoise)
            {
                case "1":
                    addVehicleToGarage();
                    break;
                case "2":
                    printLicenceWithFilter();
                    break;
                case "3":
                    changeStateOfVehicleInTheGarage();
                    break;
                case "4":
                    FillAirPresure();
                    break;
                case "5":
                    fuelingFuelToVehicles();
                    break;
                case "6":
                    rechargeElectricVehicle();
                    break;
                case "7":
                    printClientDetails();
                    break;
            }
        }
 
        private Type[] displayMenu()
        {
            Type[] vehicleTypes = ManageGarage.GetTypesOfVehicle();
            int i = 1;
            foreach (Type vehicleType in vehicleTypes)
            {
                ConsoleUI.Print(String.Format("{0}. {1}" ,i, vehicleType.Name));
                i++;
            }
            return vehicleTypes;
            

        }

        private void printLicenceNumberInUI()
        {           
            foreach (Ex03.GarageLogic.VehicleInGarage vehicleInTheGarage in ManageGarage.MyGarage.ListOfVehicle)
            {
                ConsoleUI.Print(vehicleInTheGarage.VehicleInTheGarage.LicenseNumber);
            }
        }

        public void GetAllDetails(Dictionary<string, string> i_dictionary, Ex03.GarageLogic.Vehicle i_vehicle)
        {
            string answer;

            foreach (KeyValuePair<string, string> kvp in i_dictionary)
            {
                answer = ConsoleUI.PrintAndGetInput(kvp.Value);
                string exMessege = "";
                while (ManageGarage.CheckSpecificValidationOfDetails(kvp.Key, answer, ref exMessege, i_vehicle) == false)
                {

                    answer = ConsoleUI.PrintAndGetInput(exMessege);

                }

            }
        }

        //Question 1
        private void addVehicleToGarage()
            {           
                string licenceNumberOfVehicle = ConsoleUI.PrintAndGetInput("what is the licence number? ");
                bool isExistInTheList = ManageGarage.CheckIfVehicleInGarageAndChangeState(licenceNumberOfVehicle);
                if (isExistInTheList == true)
                {
                    ConsoleUI.Print("Vehicle is already in the Garage");                                 
                }
                else
                {
                    ConsoleUI.Print("Choose the vehicle you want to add to the garage:");
                    Type [] typeOfVehicles = displayMenu();
                    string userChoice = ConsoleUI.AskWhichVehicleTheUserWantDoAdd();
                    string typeOfVehicle = typeOfVehicles[int.Parse(userChoice) - 1].Name;

                    // create the vehicle
                    Ex03.GarageLogic.Vehicle vehicle ; 
                    ManageGarage.CreateVehicle(typeOfVehicle ,out vehicle);
                    string ownerName = ConsoleUI.PrintAndGetInput("Owner's name: ");
                    string modelName = ConsoleUI.PrintAndGetInput("The model of the vehicle: ");
                    string ownerPhoneNum = ConsoleUI.PrintAndGetInput("Owner's phone number: ");                   
                    while (ManageGarage.AddToTheGarage(vehicle, licenceNumberOfVehicle, ownerName, ownerPhoneNum, modelName) ==false)
                    {
                        ConsoleUI.Print("Phone Number Is Invalid");
                        ownerPhoneNum= ConsoleUI.PrintAndGetInput("Owner's phone number:");                       
                    }    

                    // fill the details
                    ConsoleUI.PrintFillNextSections();
                    Dictionary<string, string> dictionary = ManageGarage.GetTheDetails(vehicle);
                    GetAllDetails(dictionary,vehicle);
                ConsoleUI.PrintOperetionDoneSuccessfully();
                }
                initSystem();
            }

        //Question 2 
        private void printLicenceWithFilter()
            {
                bool ifFilter = ConsoleUI.askToFilter();
                string stringState="";
                if (ifFilter == true)
                {
                    stringState = ConsoleUI.AskWhichFilter();                    
                }

                List<Ex03.GarageLogic.VehicleInGarage> listOfVehicles = ManageGarage.GetListFromGarageAndPrintLicenceWithFilter(stringState, ifFilter);
                ConsoleUI.Print("The License List: ");
                ConsoleUI.PrintLicenceOfVehicleFromList(listOfVehicles);
                ConsoleUI.PrintOperetionDoneSuccessfully();
                initSystem();
            }
                                                   
        //Question 3
        private void changeStateOfVehicleInTheGarage()
         {
                string licenceNumber = ConsoleUI.PrintAndGetInput("what is the licence number?" );
                string stringState = ConsoleUI.AskWhichFilter();
                ManageGarage.ChangeStateOfVehicle(stringState, licenceNumber);
                ConsoleUI.PrintOperetionDoneSuccessfully();
                initSystem();
        }

        //Question 4
        private void FillAirPresure()
        {
            string licenceNumber = ConsoleUI.PrintAndGetInput("Enter licence number");
            bool isSucceed =ManageGarage.FillAirPresureToMax(licenceNumber);
            if(isSucceed == true)
            {
                ConsoleUI.PrintOperetionDoneSuccessfully();
            }
            else
            {
                ConsoleUI.Print("The Operation went with no succes :( , There is no such a license like this in system");
            }
            initSystem();

        }

        //Question 5
        private void fuelingFuelToVehicles()
        {
            string licenseNum = ConsoleUI.PrintAndGetInput("Enter License Number: ");
            string TypeOfFuel;
            // if in the garage
            if (ManageGarage.CheckIfVehicleInTheGarage(licenseNum) == false)
            {
                ConsoleUI.Print("The vehicle isn't exist in the garage");
                
            }
            // if the vehicle is fuel vehicle
            else if (ManageGarage.CheckIfFuelVehicle(licenseNum) == false)
            {
                ConsoleUI.Print("The vehicle isn't a fuel vehicle");
                
            }
            else
            {
                TypeOfFuel = ConsoleUI.PrintAndGetInput("Which type of fuel :  \n press 1 to Solar \n press 2 to Octan95 \n press 3 Octan96 \n press 4 Octan98 ");
                string exMessage = "";
                // if inserted bad input
                while(ManageGarage.ValidateRightRange(licenseNum, TypeOfFuel, ref exMessage) == false)
                {
                    ConsoleUI.Print(exMessage);
                    TypeOfFuel = ConsoleUI.PrintAndGetInput("Press 1 to Solar \n press 2 to Octan95 \n press 3 Octan96 \n press 4 Octan98 ");
                }
                // if is the correct typeOfFuel
                if(ManageGarage.IsTheTypeFitTheTypeOfFuel(licenseNum, TypeOfFuel, ref exMessage) == false)
                {
                    ConsoleUI.Print(exMessage);
                    
                }
                else
                {
                    string amountOfFuel = ConsoleUI.PrintAndGetInput("How many liters? ");
                    if(ManageGarage.ValidateAmountOfFuelAndRefuel(licenseNum,ref exMessage,amountOfFuel)==false)
                    {
                        ConsoleUI.Print(exMessage);
                        
                    }
                    else
                    {
                        ConsoleUI.PrintOperetionDoneSuccessfully();
                    }
                    
                }        
            }
            initSystem();
        }

        //Question 6
        private void rechargeElectricVehicle()
        {
            string licenseNum = ConsoleUI.PrintAndGetInput("Enter License Number: ");

            // if in the garage
            if (ManageGarage.CheckIfVehicleInTheGarage(licenseNum) == false)
            {
                ConsoleUI.Print("The vehicle isn't exist in the garage");
                
            }
            // check if the vehicle is electric vehicle
            else if (ManageGarage.CheckIfFuelVehicle(licenseNum) == true)
            {
                ConsoleUI.Print("The vehicle isn't a electric vehicle");
                
            }
            else
            {
                
                string exMessage = "";
                string chargeTime = ConsoleUI.PrintAndGetInput("How much charge time (minutes)? ");

                if (ManageGarage.ValidateChargeTimeAndCharge(licenseNum,ref exMessage,chargeTime)==false)
                {
                    ConsoleUI.Print(exMessage);
                    
                }
                else
                {
                    ConsoleUI.PrintOperetionDoneSuccessfully();
                }
               
            }
            initSystem();

        }

        //Question 7 
        private void printClientDetails()
        {
            string licenseNumber = ConsoleUI.PrintAndGetInput("Enter License Number : ");
            int idxInTheListOfVehicles = ManageGarage.MyGarage.CheckIfExistInTheListAndGetIdx(licenseNumber);
            if (idxInTheListOfVehicles>=0)
            {
                Dictionary<string, string> dictionary = ManageGarage.GetDictionaryOfClientDetails(idxInTheListOfVehicles);

                foreach (KeyValuePair<string, string> kvp in dictionary)
                {
                    ConsoleUI.Print(string.Format("{0} {1} ",kvp.Key, kvp.Value));
                }
                
            }
            else
            {
                ConsoleUI.Print("Vehicle doesn't exist in the garage");
                
            }
            initSystem();
        }        
    }
}
