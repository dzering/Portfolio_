using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{
    public class ChainOfResponsibilityTest : MonoBehaviour
    {
        [SerializeField] List<GameHandler> gameHandlers;

        private void Start()
        {
            gameHandlers[0].Handle();
            for (int i = 1; i < gameHandlers.Count; i++)
            {
                gameHandlers[i - 1].SetNext(gameHandlers[i]);
            }
        }
    }
}