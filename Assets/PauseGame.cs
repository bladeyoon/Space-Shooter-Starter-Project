using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseMenu;
    public LevelController levelController;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isPaused)
            {
                Time.timeScale = 0;
                isPaused = true;
                pauseMenu.SetActive(true);
            }
            else if (isPaused)
            {
                Time.timeScale = 1;
                isPaused = false;
                pauseMenu.SetActive(false);
            }
        }
    }
}
