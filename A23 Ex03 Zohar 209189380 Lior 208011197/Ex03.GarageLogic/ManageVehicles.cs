using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ManageVehicles
    {
        private List<Vehicle> m_ListOfSupportedVehicle;

        //Get Set
        public List<Vehicle> ListOfSupportedVehicle
        {
            get
            {
                return m_ListOfSupportedVehicle;
            }
            set
            {
                m_ListOfSupportedVehicle = value;
            }
        }

        //Ctor
        public ManageVehicles()
        {
            m_ListOfSupportedVehicle = new List<Vehicle>();
        }

        //Methods
        private void updateListOfSupportedVehicle()
        {
            m_ListOfSupportedVehicle.Add(new FuelMotorcycle());
            m_ListOfSupportedVehicle.Add(new ElectricMotorcycle());
            m_ListOfSupportedVehicle.Add(new FuelCar());
            m_ListOfSupportedVehicle.Add(new ElectricCar());
            m_ListOfSupportedVehicle.Add(new Truck());
        }

        public static Vehicle CreateVehicle(string i_typeOfVehicle)
        {
            Vehicle vehicleObject;
            switch (i_typeOfVehicle)
            {
                case "Truck":
                    
                    vehicleObject = new Truck();
                    return vehicleObject;
                    
                case "ElectricCar":
                    
                    vehicleObject = new ElectricCar();
                    return vehicleObject;
                    
                case "ElectricMotorcycle":
                    
                    vehicleObject = new ElectricMotorcycle();
                    return vehicleObject;
                    
                case "FuelCar":
                    
                    vehicleObject = new FuelCar();
                    return vehicleObject;
                    
                case "FuelMotorcycle":
                    
                    vehicleObject = new FuelMotorcycle();
                    return vehicleObject;
                    
                default:
                    
                    vehicleObject = null;
                    return vehicleObject;
            }
            

        }
    } 
}
