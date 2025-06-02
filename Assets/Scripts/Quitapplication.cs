using UnityEngine;
using UnityEngine.InputSystem;

public class Quitapplication : MonoBehaviour
{
    void Update()
    {
        if(Keyboard.current.escapeKey.isPressed)
        {
            Debug.Log("Escape key pressed, quitting application.");
            Application.Quit();
        }
    }
}
