using System;

namespace ParkingLotApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ParkingLot parkingLot = null;
            while (true)
            {
                Console.Write("Enter a command: ");
                string command = Console.ReadLine();
                string[] tokens = command.Split(' ');

                if (tokens[0] == "create")
                {
                    int capacity = int.Parse(tokens[1]);
                    parkingLot = new ParkingLot(capacity);
                    Console.WriteLine($"Created a parking lot with {capacity} slots");
                }
                else if (parkingLot == null)
                {
                    Console.WriteLine("Please create a parking lot first.");
                }
                else if (tokens[0] == "park")
                {
                    string registrationNumber = tokens[1];
                    VehicleType vehicleType = Enum.Parse<VehicleType>(tokens[3], true);
                    string color = tokens[4];
                    if (parkingLot.ParkVehicle(registrationNumber, vehicleType, color))
                    {
                        Console.WriteLine($"Allocated slot number: {parkingLot.GetAvailableSpace() + 1}");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, parking lot is full");
                    }
                }
                else if (tokens[0] == "leave")
                {
                    int slotNumber = int.Parse(tokens[1]);
                    if (parkingLot.Leave(slotNumber))
                    {
                        Console.WriteLine($"Slot number {slotNumber} is free");
                    }
                    else
                    {
                        Console.WriteLine("Invalid slot number");
                    }
                }
                

                else if (tokens[0] == "exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid command");
                }
            }
        }
    }
}