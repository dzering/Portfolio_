using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{
   
    public class EnemyRotation
    {
        readonly Rigidbody2D rb2d;
        public EnemyRotation(Rigidbody2D rb2d)
        {
            this.rb2d = rb2d;
        }

        public void StartRotation(float force)
        {
            var rnd = Utility.GetRandomFloat();
            rb2d.AddTorque(rnd * force);
        }


    }
}