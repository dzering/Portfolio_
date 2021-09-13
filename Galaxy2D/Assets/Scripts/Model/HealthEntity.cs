using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{
    public delegate void Collision(float hp);

    internal class HealthEntity : MonoBehaviour
    {
        public event Collision onCollision;

        public Health HP;
       // [SerializeField] HealthBar healthBar;
        float health;

        private void Start()
        {
            HP.Current = HP.Max;
            health = HP.Current;
          //  healthBar.SetMaxHealth(hp);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("Collision");
            var damaging = collision.collider.GetComponent<IDamaging>();
            if (damaging != null)
            {
                TakeDamage(damaging.ForceDamage);
            }
        }

        void TakeDamage(float damage)
        {
            health -= damage;
            //   healthBar.SetHealth(health);

            if (onCollision != null)
            {
                onCollision(health);
            }

            if (health <= 0)
            {
                Die();
            }
        }

        void Die()
        {
            Destroy(gameObject);
        }
    }
}