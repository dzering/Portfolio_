using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{
    internal class ShipMovement : IMove
    {
        public event System.Action<float> EngineChanged;
        readonly Transform transform;
        Vector3 move;

        public float Speed { get; protected set; }


        public ShipMovement(float speed, Transform transform)
        {
            Speed = speed;
            this.transform = transform;
        }

        public void Move(float horizontal, float vertical)
        {
            var movment = Time.deltaTime * Speed;
            move.Set(movment * horizontal, movment * vertical, 0);
            transform.localPosition += move;
            
            if(vertical != float.MinValue)
            {
                if(EngineChanged != null)
                {
                    EngineChanged(vertical);
                }
               
            }
 


        }

    }
}