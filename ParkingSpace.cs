namespace ParkingLotApp
{
    public class ParkingSpace
    {
        public int Number { get; }
        public Vehicle ParkedVehicle { get; private set; }

        public bool IsOccupied => ParkedVehicle != null;

        public ParkingSpace(int number)
        {
            Number = number;
        }

        public void Park(Vehicle vehicle)
        {
            ParkedVehicle = vehicle;
        }

        public bool Leave()
        {
            if (IsOccupied)
            {
                ParkedVehicle = null;
                return true;
            }
            return false;
        }
    }
}
