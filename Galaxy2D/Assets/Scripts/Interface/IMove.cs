using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{
    interface IMove
    {
        float Speed { get; }
        void Move(float horizontal, float vertical);
    }
}