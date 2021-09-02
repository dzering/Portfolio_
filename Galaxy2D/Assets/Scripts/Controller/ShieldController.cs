using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{
    internal class ShieldController : MonoBehaviour, IDamagable
    {
        [SerializeField] float durability;
        float currentDurabilityl;

        private void Start()
        {
            currentDurabilityl = durability;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var damaging = collision.collider.GetComponent<IDamaging>();
           

            if(damaging != null)
            {
                IInteraction push = new PushCollision(collision, 10);
                push.Interaction();
                TakeDamage(damaging.ForceDamage);

            }
        }

        public void TakeDamage(float damage)
        {
            currentDurabilityl -= damage;
            if(currentDurabilityl <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}