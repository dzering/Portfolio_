using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{
    [RequireComponent(typeof(Rigidbody2D))]
    internal class Asteroid : Enemy, IDamaging, IDamagable
    {
        [SerializeField] float torqueVelocity;

        public override event Action OnDeath;

        public float ForceDamage { get; set ; }

        private void Start()
        {
            ForceDamage = 40;

            Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
            rb2d.gravityScale = 0;

            var enemyRotation = new EnemyRotation(rb2d);
            var enemyImpuls = new EnemyImpulse(rb2d, new Vector3(1,1,0), 50f);
            enemyImpuls.AddImpulse();
            enemyRotation.StartRotation(torqueVelocity);
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            var damaging = collision.collider.GetComponent<IDamaging>();
            if (damaging != null)
            {
                TakeDamage(damaging.ForceDamage);
            }
        }

        public void TakeDamage(float damage)
        {
            Health.ChangeCurrentHealth(Health.Current - damage);

            if (Health.Current <= 0)
            {
                Die();
            }
        }

        void Die()
        {
            if(OnDeath!= null)
            {
                OnDeath();
            }
            Destroy(gameObject);
        }

    }
}