using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{
    internal class GameStarter : MonoBehaviour
    {
        [SerializeField] int NumberProjectileToPool;
        [SerializeField] Sprite sprite;
        private ScreenBounds screenBounds;
        private List<ISpawnEnemy> spawnEnemy;
        ProjectilePool projectilePool;



        void Start()
        {
            //var gameObjectBuilder = new GameObjectBuilder();
            //GameObject station = gameObjectBuilder.Visual().Name("Station").Sprite(sprite).Physics().Rigidbody2D(1000);

            new GameObject().SetName("Station").AddRigidbody(10000).AddSprite(sprite);

            screenBounds = new ScreenBounds();
            spawnEnemy = new List<ISpawnEnemy>();

            IEnemyFactory enemyShipFactory = new EnemyShipFactory();
            IEnemyFactory asteroidFactory = new AsteroidFactory();

            var spawnEnemyShip = new SpawnController(enemyShipFactory, 5, 5, new Health(100,100));
            var spawnAsteroid = new SpawnController(asteroidFactory, 4, 9, new Health(200, 200));
            spawnEnemy.Add(spawnAsteroid);
            spawnEnemy.Add(spawnEnemyShip);

            projectilePool = new ProjectilePool(5);


            // spawn = new Spawn(EnemyShipFactory, 5, 5);

            // Через статический метод
            //Enemy.CreateAsteroidEnemy(new Health(100, 100), ScreenBounds.GetRandomPosition());
            // Enemy.CreateEnemyShip(new Health(50, 50));

            // Через фабрику
            // IEnemyFactory factory = new AsteroidFactory();
            //factory.Create(new Health(100, 100));

            //  Enemy.Factory = factory;
            //  Enemy.Factory.Create(new Health(200, 200));

            //  IEnemyFactory factoryShip = new EnemyShipFactory();
            //  factoryShip.Create(new Health(200, 200));

        }

        private void Update()
        {
            foreach (var item in spawnEnemy)
            {
                item.NextSpawn();
            }
        }


    }
}