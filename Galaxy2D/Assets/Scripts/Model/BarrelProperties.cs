using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{
    [System.Serializable]
    internal class BarrelProperties
    {
        public float Force;
        public float TimeBetweenShot;
        public Rigidbody2D Projectile;

        public BarrelProperties(float force, float timeBetweenShot, Rigidbody2D projectile)
        {
            Force = force;
            TimeBetweenShot = timeBetweenShot;
            Projectile = projectile;
        }

    }
}