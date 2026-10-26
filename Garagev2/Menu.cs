using System;
using System.Collections.Generic;
using System.Text;
using Garagev2.Model;

namespace Garagev2
{
    public class Menu
    {
        bool runMenu = true;
        private Garage? _garage;

        public bool MainMenu()
        {
            Console.Write("Enter number of parking spots that the garage should have: ");
            string parkingSpotsString = Console.ReadLine(); 
            int parkingSpots = int.Parse(parkingSpotsString); 
            _garage = new Garage(parkingSpots);

            while (runMenu)
            {
                Console.WriteLine("What would you like to do: ");                 
                Console.WriteLine("1) Add a vehicle");
                Console.WriteLine("2) Remove a vehicle");
                Console.WriteLine("3) List all parked vehicles");
                Console.WriteLine("4) Search vehicle registration number");
                Console.WriteLine("5) Search vehicle based on features");
                Console.WriteLine("6) Exit");
                string result = Console.ReadLine();

                switch (result)
                {                  

                    case "1":
                        Console.Clear();

                        if(_garage == null)
                        {
                            Console.WriteLine("You have to initialize a garge first!");
                            Console.ReadLine();
                            break;                            
                        }

                        Console.WriteLine("What type of vehicle whould you like to add? ");
                        Console.WriteLine("1. Airplane");
                        Console.WriteLine("2. Boat");
                        Console.WriteLine("3. Bus");
                        Console.WriteLine("4. Car");
                        Console.WriteLine("5. Motorcycle");
                        Console.Write("Please enter the number corresponding to the vehicle of your choice: ");
                        string choice = Console.ReadLine();
                        if(!int.TryParse(choice, out int num) || num < 1 || num > 5)
                        {
                            Console.WriteLine("Please enter a number corresponding to the vehicle of your choice! ");
                            Console.ReadLine();
                            break;
                        }

                        // TODO: Needs a method to parse through the input and check that it's a valid reg num, as well as unique. 
                        Console.Write("Enter the vehicle's registration number to add: ");
                        string parkRegNum = Console.ReadLine();                        
                        Console.Write("Vehicle color: ");
                        string color = Console.ReadLine();
                        Console.Write("Number of wheels: ");
                        string numWheelsString = Console.ReadLine();
                        if (!int.TryParse(numWheelsString, out int numWheelsRange) || numWheelsRange < 1 || numWheelsRange > 12)
                        {
                            Console.WriteLine("Please enter a number! ");
                            Console.ReadLine();
                            break;
                        }


                        int numWheels = int.Parse(numWheelsString);
                        Console.Write("Horse Power: ");
                        string horsePwrString = Console.ReadLine();
                        int horsePwr = int.Parse(horsePwrString);

                        if (choice == "1")
                        {
                            Console.Write("Number of engines: ");
                            string numEnginesString = Console.ReadLine();
                            int numEngines = int.Parse(numEnginesString);
                            Airplane airplane = new Airplane(parkRegNum, color, numWheels, numEngines); // Creating an airplane object
                            _garage.AddVehicle(airplane);
                        }
                        else if (choice == "2")
                        {
                            Console.Write("Length of boat (feet): ");
                            string feetString = Console.ReadLine();
                            int feet = int.Parse(feetString);
                            Console.WriteLine("Knots: ");
                            string knotsString = Console.ReadLine();
                            int knots = int.Parse(knotsString);

                            Boat boat = new Boat(parkRegNum, color, numWheels, feet, knots);
                            _garage.AddVehicle(boat);
                        }
                        else if (choice == "3")
                        {
                            Console.Write("Number of seats: ");
                            string seatsString = Console.ReadLine();
                            int seats = int.Parse(seatsString);
                            Console.Write("Length of bus: ");
                            string lengthString = Console.ReadLine();
                            int length = int.Parse(lengthString);

                            Bus bus = new Bus(parkRegNum, color, numWheels, seats, length);
                            _garage.AddVehicle(bus);

                        }
                        else if (choice == "4")
                        {
                            if (_garage == null)
                            {
                                Console.WriteLine("You have to create a garage first");
                                Console.ReadLine();
                                break;
                            }
                            Console.Write("Enter Fuel type, Gas/Diesel: ");
                            string fuel = Console.ReadLine();

                            Car car = new Car(parkRegNum, color, numWheels, horsePwr, fuel);
                            _garage.AddVehicle(car);
                        }
                        else if (choice == "5")
                        {
                            Console.Write("Enter cylinder volume: ");
                            string volumeString = Console.ReadLine();
                            decimal volume = decimal.Parse(volumeString);

                            Motorcycle motorcycle = new Motorcycle(parkRegNum, color, numWheels, horsePwr, volume);
                            _garage.AddVehicle(motorcycle);
                        }
                        else
                        {
                            Console.WriteLine("Please enter a number between 1-5");
                        }
                        break;

                    case "2":
                        Console.Clear();
                        if (_garage == null)
                        {
                            Console.WriteLine("Cannot remove as the garage is not yet initialized. Please create a garage and add vehicles first");
                            Console.ReadLine();
                            break;
                        }


                        Console.Write("Enter the vehicle's registration number to remove: ");
                        string removeRegNum = Console.ReadLine();
                        bool remove = _garage.RemoveVehicle(removeRegNum);
                        if (remove)
                        {
                            Console.WriteLine($"Vehicle {removeRegNum} was removed successfully!");
                            Console.ReadLine();
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Vehicle {removeRegNum} could not be removed.");
                            Console.ReadLine();
                        }
                        break;

                    case "3":
                        Console.Clear();

                        if (_garage == null)
                        {
                            Console.WriteLine("You have to initialize a garge first!");
                            Console.ReadLine();
                            break;
                        }

                        Console.WriteLine("*** LISTING ALL VEHICLES IN THE GARAGE ***");
                        int planeCount = 0;
                        int boatCount = 0;
                        int busCount = 0;
                        int carCount = 0;
                        int motorcycleCount = 0;
                        List<Vehicle> test = _garage.ListVehicles();
                        foreach (var v in test)
                        {
                            if (v != null)
                            {
                                if (v is Airplane)
                                {
                                    planeCount++;
                                }
                                else if (v is Boat)
                                {
                                    boatCount++;
                                }
                                else if (v is Bus)
                                {
                                    busCount++;
                                }
                                else if (v is Car)
                                {
                                    carCount++;
                                }
                                else if (v is Motorcycle)
                                {
                                    motorcycleCount++;
                                }
                                Console.Write($"    |  {v.RegNum}  ");
                            }


                        }
                        Console.Write("    |");
                        Console.WriteLine($"Airplanes: {planeCount} * Boats: {boatCount} * Busses: {busCount} * Cars: {carCount} * Motorcycles: {motorcycleCount}");
                        Console.ReadLine();

                        break;

                    // TODO: Would be much cooler if the lookup returned the index of where the vehicle is parked. Work on adding that functionality
                    case "4":
                        Console.Clear();
                        if (_garage == null)
                        {
                            Console.WriteLine("Cannot find as the garage is not initialized. Please create a garage and add vehicles first");
                            Console.ReadLine();
                            break;
                        }
                        Console.Write("Enter the vehicle's registration number to search: ");
                        string searchRegNum = Console.ReadLine();
                        Vehicle lookup = _garage.SearchRegNum(searchRegNum);
                        if (lookup == null)
                        {
                            Console.WriteLine("No matching registration number found");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine($"Vehicle found! Registration number: {lookup.RegNum} - Color: {lookup.Color} - Number of Wheels: {lookup.NumWheels}");
                            Console.ReadKey();
                        }

                        break;

                    
                    case "5":
                        Console.Clear();
                                                
                        if (_garage == null)
                        {
                            Console.WriteLine("Cannot search for vehicle features as the garage is not initialized. Please create a garage and add vehicles first");
                            Console.ReadLine();
                            break;
                        }
                        Console.Write("Enter the vehicle's color: ");
                        string lookupVehicleColor = Console.ReadLine();
                        Console.Write("Enter the vehicle's number of wheels: ");
                        string lookupVehicleNumWheelsString = Console.ReadLine();
                        int lookupVehicleNumWheels = int.Parse(lookupVehicleNumWheelsString);
                        Console.Write("Enter the vehicle type: ");
                        string lookupVehicleType = Console.ReadLine();

                        // Take the results and send them to the SearchAttributes method in Garage.cs
                        List<Vehicle> matchingVehicles = _garage.SearchAttributes(lookupVehicleColor, lookupVehicleNumWheels, lookupVehicleType);

                        if (matchingVehicles.Count > 0)
                        {
                            Console.WriteLine("Search results: ");
                            foreach(var v in matchingVehicles)
                            {
                                Console.WriteLine($" Color: {v.Color} - #Wheels: {v.NumWheels} - Type: {v.GetType().Name} - Registration Number: {v.RegNum}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No matching vehicle found");
                        }

                        Console.ReadLine();
                        break;

                    case "6":
                        return false; // End the while-loop --> Exit program
                }

            }
            return runMenu;
        }

    }
}
