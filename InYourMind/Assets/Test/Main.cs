using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public class Main : MonoBehaviour
    {
        PlayerController playerController;
        [SerializeField] ObjectView player;

        private void Start()
        {
            playerController = new PlayerController(player);
        }

        private void Update()
        {
            playerController.Update();
        }


    }
}