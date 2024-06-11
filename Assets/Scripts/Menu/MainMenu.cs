using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public AudioClip ButtonSFX;

    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject creditsPanel;
    [SerializeField] GameObject controlsPanel;
    [SerializeField] GameObject Back;
    public void PlayButton()
    {
        AudioManager.Instance.PlaySFX(ButtonSFX);
        SceneManager.LoadScene(1);
    }
    public void OpenCredits()
    {
        AudioManager.Instance.PlaySFX(ButtonSFX);
        creditsPanel.SetActive(true);
        Back.SetActive(true);
        mainMenuPanel.SetActive(false);
    }
    public void OpenControls()
    {
        AudioManager.Instance.PlaySFX(ButtonSFX);
        controlsPanel.SetActive(true);
        Back.SetActive(true);
        mainMenuPanel.SetActive(false);
    }
    public void BackButton()
    {
        AudioManager.Instance.PlaySFX(ButtonSFX);
        Back.SetActive(false);
        controlsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
    public void QuitButton()
    {
        AudioManager.Instance.PlaySFX(ButtonSFX);
        Application.Quit();
    }
}
