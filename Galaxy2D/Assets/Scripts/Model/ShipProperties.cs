using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{
    [System.Serializable]
    internal struct ShipProperties
    {
        public float Speed;
        public float RotationSpeed;

        public ShipProperties(float speed, float rotationSpeed)
        {
            Speed = speed;
            RotationSpeed = rotationSpeed;
        }

    }
}