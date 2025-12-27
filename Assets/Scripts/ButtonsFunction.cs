using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
public class ButtonsFunction : MonoBehaviour
{
    public static bool GameIsPaused = false;
    
    public AudioMixer audioMixer;
    public GameObject pauseMenuUI;

    public void LoadFirst()
    {
        SceneManager.LoadScene("Ground-0");
    }
    public void LoadSecond()
    {
        SceneManager.LoadScene("Pipeworks");
    }

    public void LoadThird()
    {
        SceneManager.LoadScene("The hook");
    }

    public void LoadFourth()
    {
        SceneManager.LoadScene("The site");
    }
    public void LoadFifth()
    {
        SceneManager.LoadScene("Final push");
    }
    public void LoadSixth()
    {
        SceneManager.LoadScene("Ascent");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Main menu");
        DeathCount.instance.ResetCounter();
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("VolumeSlider", volume);
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        EventSystem.current.SetSelectedGameObject(null);
    }
}
