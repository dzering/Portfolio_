using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuController : EndGameMenuController
{
    public event System.Action<bool> onPause;

    Button pause;
    Button resume;


    public PauseMenuController(UIView gameMenuView) : base(gameMenuView)
    {
        pause = pauseMenuView.Pause;
        resume = pauseMenuView.Resume;
        pause.onClick.AddListener(Pause);
        resume.onClick.AddListener(Resume);
    }


    void Pause()
    {
        pauseMenuView.gameObject.SetActive(true);
        onPause?.Invoke(false);
    }

    void Resume()
    {
        pauseMenuView.gameObject.SetActive(false);
        onPause?.Invoke(true);
    }
}
