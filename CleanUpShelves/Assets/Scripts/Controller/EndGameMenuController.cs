using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameMenuController
{
    protected UIView pauseMenuView;
    protected Button restart;
    protected Button quit;


    public EndGameMenuController(UIView gameMenuView)
    {
        pauseMenuView = gameMenuView;
        restart = pauseMenuView.Restart;
        quit = pauseMenuView.Quit;
        restart.onClick.AddListener(Restart);
        quit.onClick.AddListener(Quit);
    }

    void Quit()
    {
        SceneManager.LoadScene(0);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }

}
