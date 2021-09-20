using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{
    internal static class Utility
    {
        public static float GetRandomFloat()
        {
            System.Random rnd = new System.Random();
            return  ((float)rnd.NextDouble()- 0.5f);
        }
    }
}