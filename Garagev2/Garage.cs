using Garagev2.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garagev2
{
    internal class Garage
    {

        // Private fields/attributes

        private List<Vehicle> _vehicles;
        private int _capacity;

        // Garage Constructor
        public Garage(int capacity)
        {
            _capacity = capacity;
            _vehicles = new List<Vehicle>();
        }

        
        public bool AddVehicle(Vehicle vehicle)
        {
            foreach(var v in _vehicles)
            {
                if (v.RegNum.Equals(vehicle.RegNum))
                {
                    return false; // Vehicle already exists
                }
            }
            _vehicles.Add(vehicle);
            return true; // Vehicle successfully added
        }


        public bool RemoveVehicle(string regNum)
        {
            var vehicleToRemove = SearchRegNum(regNum);
            if (vehicleToRemove != null)
            {
                _vehicles.Remove(vehicleToRemove);
                return true;
            }
            return false;
        }

        public Vehicle SearchRegNum(string regNum)
        {            
            foreach(var v in _vehicles)
            {
                if (v.RegNum.Equals(regNum))
                {
                    return v;
                }
            }
            return null;
        }

        
        public List<Vehicle> SearchAttributes(string color, int numWheels, string vehicleTypeInput)
        {
            List<Vehicle> matchingVehicles = new List<Vehicle>();
            
            foreach (Vehicle v in _vehicles)
            {
                string vehicleType = v.GetType().Name;

                if (vehicleTypeInput == vehicleType || v.Color == color || v.NumWheels == numWheels)
                {
                    matchingVehicles.Add(v);
                }                
            }
            
            return matchingVehicles;
        }

        public List<Vehicle> ListVehicles()
        {
            return _vehicles;
        }

        public Dictionary<string, int> CountVehicleTypes()
        {
            //Dictionary<string, int> counts = new Dictionary<string, int>();
            var counts = new Dictionary<string, int>();

            foreach (Vehicle v in _vehicles) // Vehicle v as opposed to var v
            {
                string vehicleType = v.GetType().Name;
                if (counts.ContainsKey(vehicleType))
                {
                    counts[vehicleType]++;
                }
                else
                {
                    counts[vehicleType] = 1;
                }
                /*if (v is Airplane)
                {
                    if (counts.ContainsKey("Airplane"))
                    {
                        counts["Airplane"]++;
                    }
                    else
                    {
                        counts.Add("Airplane", 1);
                    }
                }

                else if (v is Boat)
                {
                    if (counts.ContainsKey("Boat"))
                    {
                        counts["Boat"]++;
                    }
                    else
                    {
                        counts.Add("Boat", 1);
                    }
                }

                else if (v is Bus)
                {
                    if (counts.ContainsKey("Bus"))
                    {
                        counts["Bus"]++;
                    }
                    else
                    {
                        counts.Add("Bus", 1);
                    }
                }

                else if (v is Car)
                {
                    if (counts.ContainsKey("Car"))
                    {
                        counts["Car"]++;
                    }
                    else
                    {
                        counts.Add("Car", 1);
                    }
                }
                else if (v is Motorcycle)
                {
                    if (counts.ContainsKey("Motorcycle"))
                    {
                        counts["Motorcycle"]++;
                    }
                    else
                    {
                        counts.Add("Motorcycle", 1);
                    }
                }*/

            }
            return counts;

        }
    }
}
