using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{
    internal sealed class EnemyShipFactory : IEnemyFactory
    {
        public Enemy Create(Health hp)
        {
            var enemyShip = Object.Instantiate(Resources.Load<EnemyShip>("Enemy/EnemyShip"));
            enemyShip.DependencyInjectHealth(hp);
            return enemyShip;
        }
    }
}