using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{
    internal sealed class PlayerShip : IMove, IRotation
    {
        readonly IMove moveImplementation;
        readonly IRotation rotationImplementation;

        public float Speed => moveImplementation.Speed;

        public PlayerShip(IMove moveImplementation, IRotation rotationImplementation)
        {
            this.moveImplementation = moveImplementation;
            this.rotationImplementation = rotationImplementation;
        }

        public void Move(float horizontal, float vertical)
        {
            moveImplementation.Move(horizontal, vertical);
        }

        public void Rotation(Vector3 direction)
        {
            rotationImplementation.Rotation(direction);
        }

        public void AddAcceleration(bool accelerationOn)
        {
            if(moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.AddAcceleration(accelerationOn);
            }
        }

        public void RemoveAcceleration(bool accelerationOff)
        {
            if(moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.RemoveAcceleration(accelerationOff);
            }
        }
    }
}