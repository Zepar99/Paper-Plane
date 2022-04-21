using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] AudioSource audioSource;

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        audioSource.Pause();
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        audioSource.UnPause();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
