using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{
    internal abstract class Enemy : MonoBehaviour
    {
        public abstract event System.Action OnDeath;
        public Health Health { get; private set; }
        public static IEnemyFactory Factory;

        //Transform position;

        public static Asteroid CreateAsteroidEnemy(Health hp, Vector2 position)
        {
            var enemy = Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid"));
            enemy.Health = hp;
            enemy.transform.position = position;
            return enemy;
        }

        public static EnemyShip CreateEnemyShip(Health hp)
        {
            var enemy = Instantiate(Resources.Load<EnemyShip>("Enemy/EnemyShip"));
            enemy.Health = hp;
            return enemy;
        }

        public void DependencyInjectHealth(Health hp)
        {
            Health = hp;
        }

    }
}