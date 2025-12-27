using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class ColisionHandller : MonoBehaviour
{
    private PlayerControls inputActions;

    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] AudioClip successSFX;
    [SerializeField] AudioClip crashSFX;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;
    bool isControllable = true;

    AudioSource audioSource;

    private void Awake()
    {
        inputActions = new PlayerControls();
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Restart.performed += OnRestartPerformed;
    }

    private void OnDisable()
    {
        inputActions.Player.Restart.performed -= OnRestartPerformed;
        inputActions.Player.Disable();
    }

    private void OnRestartPerformed(InputAction.CallbackContext ctx)
    {
        ReloadLevel();
    }

    void Update()
    {
  
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