using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{
    internal sealed class AtackPlayerModifier : PlayerModifier
    {
        readonly float barrelForce;
        readonly float timeBetweenShot;

        public AtackPlayerModifier(BarrelProperties properties, float force, float timeBetwen) : base(properties)
        {
            barrelForce = force;
            timeBetweenShot = timeBetwen;
        }

        public override void Handle()
        {
            barrel.Force = barrelForce;
            barrel.TimeBetweenShot = timeBetweenShot;
            base.Handle();
        }

    }
}