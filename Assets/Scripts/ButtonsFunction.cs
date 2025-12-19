using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
public class ButtonsFunction : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void LoadFirst()
    {
        SceneManager.LoadScene("First");
    }
    public void LoadSecond()
    {
        SceneManager.LoadScene("Second");
    }

    public void LoadThird()
    {
        SceneManager.LoadScene("Last");
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
        SceneManager.LoadScene("Second");
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
}
