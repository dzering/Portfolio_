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
        Transform transform;

        public EnemyImpulse(Rigidbody2D rb2d, Transform transform, float force)
        {
            this.transform = transform;
            this.rb2d = rb2d;
            this.force = force;
            if (!Player.Instance)
            {
                directionMove = Vector3.zero;
            }
            else
            {
                directionMove = Player.Instance.transform.position - transform.position;
            }
        }

        public void AddImpulse()
        {
            rb2d.AddForce(directionMove * force);
        }

    }
}