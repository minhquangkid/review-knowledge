using System.ComponentModel.DataAnnotations;

namespace Review.Model
{
    public class RemoteCar
    {
        private int _totalMeters = 0;

        private int _batterPercentDigit = 100;

        public string BatterPercent 
        {
            get { return $"Battery at {_batterPercentDigit} %" ; }
            set { BatterPercent = value; }
        }

        public static RemoteCar Buy()
        {
            return new RemoteCar();
        }

        public string DistanceDisplay()
        {
            return $"Driven {_totalMeters} meters";
        }
        public string BatteryDisplay()
        {
            return _batterPercentDigit == 0 ? "Battery empty" : BatterPercent;
        }

        public void Drive()
        {
            if (_batterPercentDigit > 0)
            {
                _totalMeters += 20;
                _batterPercentDigit--;
            }
        }

    }
}
