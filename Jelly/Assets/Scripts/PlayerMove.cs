using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sausage
{
    internal class PlayerMove
    {
        readonly Rigidbody RB;
        

        public PlayerMove(Rigidbody RB)
        {
            this.RB = RB;
        }

        public void Push(Vector3 force)
        {
            RB.AddForce(force, ForceMode.Impulse);
        }


    }
}