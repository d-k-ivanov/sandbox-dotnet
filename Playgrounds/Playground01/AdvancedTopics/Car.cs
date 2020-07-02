using System;

namespace AdvancedTopics
{
    class CarArgs : EventArgs
    {
        public int CurrentSpeed { get; set; }

        public CarArgs(int currentSpeed)
        {
            CurrentSpeed = currentSpeed;
        }

    }

    class Car
    {
        public int Speed = 0;

        // Delegate
        // public delegate void TooFast(Car car);
        // private TooFast _tooFast;

        // Own custom event
        // public delegate void TooFast(Car car);
        // public event TooFast TooFastDriving;

        // BCL Action event
        public event Action<Car> TooFastDriving;

        // It's possible to use Func BCL Delegate
        // public event Func<Car, string> TooFastDriving;

        // BCL EventHandler: Object + Arguments
        public event EventHandler<CarArgs> TooFastDrivingEh;


        public void Start()
        {
            Speed = 10;
        }

        public void Accelerate()
        {
            Speed += 10;

            if (Speed > 80)
            {
                // Event Handler
                TooFastDrivingEh?.Invoke(this, new CarArgs(Speed));

                // Actions
                TooFastDriving?.Invoke(this);
            }
        }

        public void Stop()
        {
            Speed = 0;
        }

        // public void RegisterOnTooFast(TooFast tooFast)
        // {
        //     // _tooFast = tooFast;
        //     _tooFast += tooFast;
        // }

        // public void UnRegisterOnTooFast(TooFast tooFast)
        // {
        //     _tooFast -= tooFast;
        // }
    }
}
