using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour, IUpdatable
{
    public AudioClip ButtonSFX;

    [SerializeField] GameObject menuUI;
    bool isPaused = false;

    private void Start()
    {
        menuUI.SetActive(false);
        CustomUpdateManager.Instance.Register(this);
    }
    public void OnUpdate()
    {
        Pause();
    }
    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
    }
    public void ResumeGame()
    {
        menuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void PauseGame()
    {
        menuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void GoToMenu()
    {
        AudioManager.Instance.PlaySFX(ButtonSFX);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        AudioManager.Instance.PlaySFX(ButtonSFX);
        Application.Quit();
    }
}
