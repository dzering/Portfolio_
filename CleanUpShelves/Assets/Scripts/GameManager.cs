using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] ShelfView[] shelves;
    [SerializeField] TextView score;
    [SerializeField] UIView endGameMenuView;
    [SerializeField] UIView pauseMenuView;

    ShelfController[] shelvesControllers;
    PlayerController playerController;
    VictoryController victoryController;
    ScoreController scoreController;
    PauseMenuController pauseMenuController;
    EndGameMenuController endGameMenuController;

    IColoring colorGenerator;


    private void Start()
    {
        scoreController = new ScoreController(score);
        colorGenerator = new ColorGenerator(shelves.Length);
        shelvesControllers = new ShelfController[shelves.Length];
        for (int i = 0; i < shelves.Length; i++)
        {
            shelvesControllers[i] = new ShelfController(shelves[i], colorGenerator);
        }

        victoryController = new VictoryController(shelves, endGameMenuView);
        pauseMenuController = new PauseMenuController(pauseMenuView);
        endGameMenuController = new EndGameMenuController(endGameMenuView);
        playerController = new PlayerController();


        playerController.OnSwap += victoryController.Check;
        playerController.OnSwap += scoreController.Update;
        pauseMenuController.onPause += playerController.SetInGame;
    }

    private void Update()
    {
        playerController.Update();
    }
}
