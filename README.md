# Garagev2

This project builds upon the original Garage-project. The difference is that this is an exercise in using List, whereas the original was using arrays. It's a console project that will run in the terminal.

When running the program, the user has to enter the capacity of the garage before being able to navigate the main menu.


## Functionality
The functionality is the same as the previous version.

There are multiple classes:

* The Garage class where a List is initialized. This list will contain the vehicles. The class contains methods to
  - Add/remove vehicles
  - Search vehicle based on registration number
  - Search vehicle based on features such as color, number of wheels, or vehicle type
  - List all vehicles

* The vehicle class, which is just a record containing registration number, color, and number of wheels
* Subclasses for each vehicle type: Airplane, Boat, Bus, Car, Motorcycle, that inherits from the vehicle class, but all have one unique attribute
* The Menu class, which is the user interface of the program. This class calls methods from the Garage-class.
* The Program class, which is just the Main method to start the program. This class calls the MainMenu-method in the Menu-class.


## Future Work
More error-handling needs to be implemented. There is no way to check if the registration number is either a valid one for example. There is also no way to choose how many parking spots that are already occupied when initializing the garage 

## Feedback from classmates
* Is it too much in the Menu class? Could it be divided somehow
* Where can I implement the registration number check?
* How can I handle errors, using if-statements or try-catch blocks?



