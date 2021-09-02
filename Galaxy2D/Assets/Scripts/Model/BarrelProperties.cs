using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{
    [System.Serializable]
    internal struct BarrelProperties
    {
        public float Force;
        public float TimeBetweenShot;

        public BarrelProperties(float force, float timeBetweenShot)
        {
            Force = force;
            TimeBetweenShot = timeBetweenShot;
        }

    }
}