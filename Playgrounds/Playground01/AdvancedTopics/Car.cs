using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedTopics
{
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

        public void Start()
        {
            Speed = 10;
        }

        public void Accelerate()
        {
            Speed += 10;

            if (Speed > 80)
            {
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
