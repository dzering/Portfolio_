using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public class PlayerController
    {
        ObjectView view;
        float speed = 5f;
        float horizontal;

        public PlayerController(ObjectView player)
        {
            view = player;
        }

        public void Update()
        {
            horizontal = Input.GetAxis("Horizontal");
            Move();
        }

        void Move()
        {
            view.transform.Translate((Vector3.right * horizontal) * Time.deltaTime * speed);
        }
    }
}

