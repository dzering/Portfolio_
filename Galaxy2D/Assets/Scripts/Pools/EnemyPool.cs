using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Galaxy
{
    internal sealed class EnemyPool
    {
        readonly Dictionary<string, HashSet<Enemy>> enemyPool;
        readonly int capacity;
        Transform rootPool;

        public EnemyPool(int capacity)
        {
            this.capacity = capacity;
            enemyPool = new Dictionary<string, HashSet<Enemy>>();
            if (!rootPool)
            {
                rootPool = new GameObject(NameManager.POOL_ENEMY).transform;
            }
        }

        public Enemy GetEnemy(string type)
        {
            Enemy result;
            switch (type)
            {
                case "Asteroid":
                    result = GetAsteroid(GetListEnemy(type));
                    break;
                case "EnemyShip":
                    result = GetEnemyShip(GetListEnemy(type));
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, "Not provided in the program");
            }

            return result;
        }

        private HashSet<Enemy> GetListEnemy(string type)
        {
            return enemyPool.ContainsKey(type) ? enemyPool[type] : enemyPool[type] = new HashSet<Enemy>();
        }
        private Enemy GetEnemyShip(HashSet<Enemy> enemies)
        {
            var enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
            if(enemy == null)
            {
                var a = Resources.Load<EnemyShip>("Enemy/EnemyShip");
                for (int i = 0; i < capacity; i++)
                {
                    var instantiate = Object.Instantiate(a);
                    ReturnToPool(instantiate.transform);
                    enemies.Add(instantiate);
                }
                GetEnemyShip(enemies);
            }
            enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
            return enemy;
        }

        private Enemy GetAsteroid(HashSet<Enemy> enemies)
        {
            var enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
            if(enemy == null)
            {
                var a = Resources.Load<Asteroid>("Enemy/Asteroid");
                for (int i = 0; i < capacity; i++)
                {
                    var instantiate = Object.Instantiate(a);
                    ReturnToPool(instantiate.transform);
                    enemies.Add(instantiate);
                }
                GetAsteroid(enemies);
            }
            enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
            return enemy;
        }

        private void ReturnToPool(Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.gameObject.SetActive(false);
            transform.parent = rootPool;
        }

        public void RemovePool()
        {
            Object.Destroy(rootPool.gameObject);
        }
    }
}