using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLotApp
{
    public class ParkingLot
    {
        private List<ParkingSpace> spaces;

        public ParkingLot(int capacity)
        {
            spaces = new List<ParkingSpace>(capacity);
            for (int i = 0; i < capacity; i++)
            {
                spaces.Add(new ParkingSpace(i + 1));
            }
        }

        public int GetAvailableSpace()
        {
            return spaces.FindIndex(space => !space.IsOccupied);
        }

        public bool ParkVehicle(string registrationNumber, VehicleType vehicleType, string color)
        {
            int availableSpace = GetAvailableSpace();
            if (availableSpace >= 0)
            {
                spaces[availableSpace].Park(new Vehicle(registrationNumber, vehicleType, color));
                return true;
            }
            return false; 
        }

        public bool Leave(int slotNumber)
        {
            if (slotNumber >= 1 && slotNumber <= spaces.Count)
            {
                return spaces[slotNumber - 1].Leave();
            }
            return false; 
        }

        

        public int GetOccupiedSpaceCount()
        {
            return spaces.Count(space => space.IsOccupied);
        }

        public int GetAvailableSpaceCount()
        {
            return spaces.Count(space => !space.IsOccupied);
        }

        public Dictionary<string, int> GetVehicleCountByOddEvenPlate()
        {
            Dictionary<string, int> countByPlateType = new Dictionary<string, int>
    {
        { "Ganjil", 0 },
        { "Genap", 0 }
    };

            foreach (var space in spaces.Where(space => space.IsOccupied))
            {
                string registrationNumber = space.ParkedVehicle.RegistrationNumber;
                int lastDigit = int.Parse(registrationNumber.Last().ToString());

                if (lastDigit % 2 == 0)
                {
                    countByPlateType["Genap"]++;
                }
                else
                {
                    countByPlateType["Ganjil"]++;
                }
            }

            return countByPlateType;
        }

        public Dictionary<VehicleType, int> GetVehicleCountByType()
        {
            Dictionary<VehicleType, int> countByType = new Dictionary<VehicleType, int>
    {
        { VehicleType.Mobil, 0 },
        { VehicleType.Motor, 0 }
    };

            foreach (var space in spaces.Where(space => space.IsOccupied))
            {
                VehicleType vehicleType = space.ParkedVehicle.Type;
                countByType[vehicleType]++;
            }

            return countByType;
        }

        public Dictionary<string, int> GetVehicleCountByColor()
        {
            Dictionary<string, int> countByColor = new Dictionary<string, int>();

            foreach (var space in spaces.Where(space => space.IsOccupied))
            {
                string color = space.ParkedVehicle.Color;

                if (countByColor.ContainsKey(color))
                {
                    countByColor[color]++;
                }
                else
                {
                    countByColor[color] = 1;
                }
            }

            return countByColor;
        }

    }
}
