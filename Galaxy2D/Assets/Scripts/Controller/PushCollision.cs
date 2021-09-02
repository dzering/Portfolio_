using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{
    internal class PushCollision : IInteraction
    {
        readonly Collision2D collision;
        readonly float force;

        public PushCollision(Collision2D collision, float force)
        {
            this.collision = collision;
            this.force = force;
        }

        public void Interaction()
        {
            ContactPoint2D contact = collision.GetContact(0);
            var rb2d = contact.collider.GetComponent<Rigidbody2D>();
            Vector2 direction = contact.normal;
            rb2d.AddForce(-direction * force, ForceMode2D.Impulse);
        }
    }
}