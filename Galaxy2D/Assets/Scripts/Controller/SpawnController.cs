using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{
    internal class SpawnController : ISpawnEnemy
    {
        IEnemyFactory enemyFactory;
        float timeBetweenSpawn;
        int maxEnemyCount;
        float nextSpawnTime;
        float currentEnemyCount;
        Health hp;

        public SpawnController(IEnemyFactory enemyFactory, float timeBetweenSpawn, int maxEnemyCount, Health hp)
        {
            this.enemyFactory = enemyFactory;
            this.timeBetweenSpawn = timeBetweenSpawn;
            this.maxEnemyCount = maxEnemyCount;
            this.hp = hp;

        }

        public void NextSpawn()
        {
            if (nextSpawnTime < Time.time && currentEnemyCount < maxEnemyCount)
            {
                nextSpawnTime = Time.time + timeBetweenSpawn;
                currentEnemyCount++;
                Enemy.Factory = enemyFactory;
                var enemy = Enemy.Factory.Create(hp);
                enemy.transform.position = ScreenBounds.GetRandomPosotionOutOfScreen();
                enemy.OnDeath += OnDeathEnemy;
            }
        }

        void OnDeathEnemy()
        {
            currentEnemyCount--;
        }
    }
}