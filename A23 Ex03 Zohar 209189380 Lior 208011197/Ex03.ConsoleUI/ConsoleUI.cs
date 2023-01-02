using Ex03.GarageLogic;
using System;
using System.Collections.Generic;

namespace Ex03.ConsoleUI
{
    public class ConsoleUI
    {       
       public static string PrintAndGetInput(string i_outputToTheUser)
        {
            string answer;
            Console.WriteLine(i_outputToTheUser);
            answer = Console.ReadLine();
            return answer;
        }

       public static void Print(string i_stringToPrint)
        {
            Console.WriteLine(i_stringToPrint);
        }
       
       public static void PrintFillNextSections()
        {
            Console.WriteLine("Please fill the next sections :) ");
        }

       public static void PrintLicenceOfVehicleFromList(List<Ex03.GarageLogic.VehicleInGarage> i_listOfVehicles)
       {          
            foreach(VehicleInGarage vehicle in i_listOfVehicles)
            {
                Console.WriteLine(vehicle.VehicleInTheGarage.LicenseNumber);
            }           
       } 

       public static string DisplayMenuOfOperationsAndChooseOption()
        {
            Console.WriteLine("Choose the option you want to do: \n\n 1. Add new vehicle to the garage \n 2. Display the licence nember of the vihecles in our garage \n 3. Change state of specific vehicle by his licence number \n 4. To inflate the wheels to maximum of a vehicle according to its license number \n 5. Refuel a vehicle that runs on fuel \n 6. Charge an electric vehicle \n 7. Display vehicle data");
            string userChoice = Console.ReadLine();
            while(isValidOptionOfDisplayMenu(userChoice) == false)
            {
                Console.WriteLine("input is invalid, pleace chooce number between 1-7.");
                userChoice = Console.ReadLine();
            }
            return userChoice;
        }

       public static void PrintOperetionDoneSuccessfully()
        {
            Console.WriteLine("Operation done successfully!");
        }

       private static bool isValidOptionOfDisplayMenu(string i_strInput)
        {
            bool isValid = true;
            if(i_strInput.Length!=1)
            {
                isValid = false;
            }
            else
            {
                char inputStr = i_strInput[0];
                if (inputStr < '1' || inputStr > '7')
                {
                    isValid = false;
                }
            }
            return isValid;
        }
    
       public static bool askToFilter()
        {
            bool ifFilter = false;
            Console.WriteLine("press 1 to filter the list of Vehicle by there state \n press 2 to View the entire list of vehicles");
            string userChoice = Console.ReadLine();
            while(isValidForAskToFilter(userChoice) == false)
            {
                Console.WriteLine("Input is invalid, please press 1 to filter the list of Vehicle by there state \n press 2 to View the entire list of vehicles");
                userChoice = Console.ReadLine();
            }
            if(userChoice == "1")
            {
                ifFilter = true;
            }
            return ifFilter;
        } 

       private static bool isValidForAskToFilter(string i_userInput)
        {
            bool isValid = true;
            if(i_userInput != "1" && i_userInput!= "2")
            {
                isValid = false;
            }
            return isValid;
        }
          
       public static string AskWhichFilter()
       {
            Console.WriteLine("by which state do you want to filter the list of Vehicle? \n Fixed - press 1 \n under repair - press 2 \n paid - press 3");
            string userChoice = Console.ReadLine();
            while(isValidChoiseOfState(userChoice)== false)
            {
                Console.WriteLine("Input is invalid, by which state do you want to filter the list of Vehicle? \n Fixed under repair - press 1 \n under repair - press 2 \n paid - press 3");
                userChoice = Console.ReadLine();
            }
            return userChoice;
       } 

       private static bool isValidChoiseOfState(string i_userInput)
        {
            bool isValid = true;
            if (i_userInput != "1" && i_userInput != "2" && i_userInput != "3")
            {
                isValid = false;
            }
            return isValid;
        }

       public static string AskForNewState()
        {
            Console.WriteLine("What state would you like to change the vehicle to? \n \n Fixed - press 1 \n under repair - press 2 \n paid");
            string userInput = Console.ReadLine();
            while(isValidChoiseOfState(userInput) == false)
            {
                Console.WriteLine("The input is invalid.\n What state would you like to change the vehicle to? \n \n Fixed - press 1 \n under repair - press 2 /n paid");
                userInput = Console.ReadLine();
            }
            return userInput;

        } 

       public static string AskWhichVehicleTheUserWantDoAdd()
        {
         
            string userChoice =Console.ReadLine();
            while(isUserChoiseOfVehicleIsValid(userChoice) == false)
            {
                Console.WriteLine("Your input is invalid , please enter number between 1-5.");
                userChoice = Console.ReadLine();
            }
            return userChoice;
        }

       private static bool isUserChoiseOfVehicleIsValid(string i_userChoice)
        {
            bool isValid = true;
            if(i_userChoice.Length != 1)
            {
                isValid = false;
            }
            else
            {
                char userChoice = i_userChoice[0];
                if(userChoice < '1' || userChoice > '5')
                {
                    isValid = false;
                }
            }
            return isValid;
       }

        






    }
}
