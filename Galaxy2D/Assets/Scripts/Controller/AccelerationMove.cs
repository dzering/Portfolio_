using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{
    internal sealed class AccelerationMove : ShipMovement
    {
        readonly float acceleration;

        public AccelerationMove(float acceleration, float speed, Transform transform) : base(speed, transform)
        {
            this.acceleration = acceleration;
        }

        public void AddAcceleration(bool accelerationOn)
        {
            if (accelerationOn)
            {
                Speed += acceleration;
            }
         
        }

        public void RemoveAcceleration(bool accelerationOff)
        {
            if (accelerationOff){
                Speed -= acceleration;
            }
            
        }
    }
}