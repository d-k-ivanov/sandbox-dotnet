using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedTopics
{
    class Car
    {
        public int Speed = 0;

        public delegate void TooFast(Car car);

        private TooFast _tooFast;

        public void Start()
        {
            Speed = 10;
        }

        public void Accelerate()
        {
            Speed += 10;

            if (Speed > 80)
            {
                _tooFast(this);
            }
        }

        public void Stop()
        {
            Speed = 0;
        }

        public void RegisterOnTooFast(TooFast tooFast)
        {
            _tooFast = tooFast;
        }
    }
}
