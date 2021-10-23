using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    bool isPaused;
    [SerializeField]
    public CanvasGroup pauseMenu;

    void Awake()
    {
        UnPaused();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                Paused();
            }
            if (!isPaused)
            {
                UnPaused();
            }
        }
    }

    public void UnPaused()
    {
        isPaused = false;
        Time.timeScale = 1;
        pauseMenu.alpha = 0;
    }

    void Paused()
    {
        isPaused = true;
        Time.timeScale = 0;
        pauseMenu.alpha = 1;
    }
}
