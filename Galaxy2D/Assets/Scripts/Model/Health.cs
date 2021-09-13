using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{
    [System.Serializable]
    internal sealed class Health
    {
        //public float Max { get; }
        //public float Current { get; private set; }
        [SerializeField] float max;
        float current;
        public float Max { get { return max; } set { max = value; } }
        public float Current { get { return current; } set { current = value; } }

        public Health(float max, float current)
        {
            Max = max;
            Current = current;
        }

        public void ChangeCurrentHealth(float hp)
        {
            Current = hp;
        }
    }
}