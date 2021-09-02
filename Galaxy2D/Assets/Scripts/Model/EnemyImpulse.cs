using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{
    internal sealed class EnemyImpulse
    {
        Rigidbody2D rb2d;
        Vector3 directionMove;
        float force;

        public EnemyImpulse(Rigidbody2D rb2d, Vector3 playerPosition, float force)
        {
            this.rb2d = rb2d;
            this.force = force;
            directionMove = playerPosition;
        }

        public void AddImpulse()
        {
            rb2d.AddForce(directionMove * force);
        }

    }
}