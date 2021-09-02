using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{
    internal interface IEnemyFactory
    {
        Enemy Create(Health hp);
    }
}