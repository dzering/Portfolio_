using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sausage
{
    internal class Player : MonoBehaviour
    {
        public PlayerMove playerMove;
        Rigidbody RB;

        [HideInInspector] public Vector3 Pos { get { return transform.position; } }
        void Start()
        {
            RB = GetComponent<Rigidbody>();
            playerMove = new PlayerMove(RB);
        }

    }
}