using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ColisionHandller : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] AudioClip successSFX;
    [SerializeField] AudioClip crashSFX;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;
    bool isControllable = true;

    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            ReloadLevel();
        }
    }
private void OnCollisionEnter(Collision other)
    {
        if (!isControllable)
        {
            return;
        }

        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This is a friendly object");
                break;
            case "Finish":
                StartSuccessSequence();
                break; 
            default: 
                StartCrashSequence();
                DeathCount.instance.AddPoint();
                break;
        }
    }

    void StartSuccessSequence()
    {
        isControllable = false;
        audioSource.Stop();
        successParticles.Play();
        audioSource.PlayOneShot(successSFX);
        GetComponent<Movement>().enabled = false;
        Invoke ("LoadNextLevel", levelLoadDelay);
    }

    void StartCrashSequence()
    {
        isControllable = false;
        audioSource.Stop();
        crashParticles.Play();
        audioSource.PlayOneShot(crashSFX);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
    }

    public void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }


    void LoadNextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;
        if (nextScene == SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }
        SceneManager.LoadScene(nextScene);
    }
}