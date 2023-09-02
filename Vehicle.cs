namespace ParkingLotApp
{
    public enum VehicleType
    {
        Mobil,
        Motor
    }

    public class Vehicle
    {
        public string RegistrationNumber { get; set; }
        public VehicleType Type { get; set; }
        public string Color { get; set; }

        public Vehicle(string registrationNumber, VehicleType type, string color)
        {
            RegistrationNumber = registrationNumber;
            Type = type;
            Color = color;
        }
    }
}
