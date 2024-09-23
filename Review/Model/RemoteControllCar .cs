using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace Review.Model
{
    // https://exercism.org/tracks/csharp/exercises/need-for-speed/edit

    class RemoteControlCar
    {
        public int NumberDrive { get; set; } = 0;
        public int BatteryStorage { get; set; } = 100;
        public int Speed { get; set; }
        public int BatteryDrain { get; set; }

        public RemoteControlCar(int speed, int batteryDrain)
        {
            this.Speed = speed;
            this.BatteryDrain = batteryDrain;
        }

        public bool BatteryDrained()
        {
            return BatteryStorage < BatteryDrain;
        }

        public int DistanceDriven()
        {
            return NumberDrive * Speed;
        }

        public void Drive()
        {
            if (BatteryStorage >= BatteryDrain)
            {
                NumberDrive++;
                BatteryStorage = BatteryStorage - BatteryDrain;
            }
        }

        public static RemoteControlCar Nitro()
        {
            return new RemoteControlCar(50, 4);
        }
    }

    class RaceTrack
    {
        public int Distance { get; set; }

        public RaceTrack(int distance)
        {
            this.Distance = distance;
        }

        public bool TryFinishTrack(RemoteControlCar car)
        {
            while (!car.BatteryDrained())
            {
                car.Drive();
            }

            if (Distance <= car.DistanceDriven())
            {
                return true;
            }

            return false;
        }
    }

}
