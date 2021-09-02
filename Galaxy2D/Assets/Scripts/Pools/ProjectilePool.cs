using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using System.Linq;

namespace Galaxy
{
    internal sealed class ProjectilePool
    {
        public static ProjectilePool SharedInstance;
        readonly HashSet<Projectile> projectilePool;
        readonly int capacity;

        Transform rootPool;

        public ProjectilePool(int capacity)
        {
            SharedInstance = this;

            this.capacity = capacity;
            this.projectilePool = new HashSet<Projectile>();
            if (!rootPool)
            {
                rootPool = new GameObject(NameManager.POOL_AMMUNITION).transform;
            }
        }

        public Projectile GetProjectile()
        {
            var projectile = projectilePool.FirstOrDefault(a => !a.gameObject.activeSelf);
            if (projectile == null)
            {
                var a = Resources.Load<Projectile>("Ammunition/Projectile");
                for (int i = 0; i < capacity; i++)
                {
                    var instantiate = Object.Instantiate(a);
                    ReturnToPool(instantiate.transform);
                    projectilePool.Add(instantiate);
                }
                GetProjectile();
            }

            //projectile = projectilePool.FirstOrDefault(a => !a.gameObject.activeSelf);
            return projectile;
        }

        private void ReturnToPool(Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.gameObject.SetActive(false);
            transform.SetParent(rootPool);
        }

    }
}