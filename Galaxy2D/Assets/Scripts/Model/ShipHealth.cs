using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{
    public class ShipHealth : MonoBehaviour
    {
        [SerializeField] float maxHealth;
        private float health;

        private void Start()
        {
            health = maxHealth;
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