using UnityEngine;
using UnityEngine.UI;

namespace Galaxy
{
    internal sealed class EnemyShip : Enemy, IDamagable
    {
        public override event System.Action OnDeath; 

        [SerializeField] Rigidbody2D projectilePeref;
        [SerializeField] Transform pointProjectile;
        [SerializeField] BarrelProperties barrelProperty;
        [SerializeField] ShipProperties shipProperties;

        IEnemyAI enemyAI;
        IFire barrel;
        public HealthBar healthBar;

        private void Start()
        {
            barrel = new Barrel(projectilePeref, pointProjectile, barrelProperty);
            enemyAI = new EnemyAI(transform, shipProperties, barrel);
            //healthBar.SetMaxHealth(Health);
        }

        private void Update()
        {
            enemyAI.Activate();
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
            if(OnDeath != null)
            {
                OnDeath();
            }
            Destroy(gameObject);
        }



    }
}