using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;

    [SerializeField] InputAction rotation;
    [SerializeField] float thrustStrenght = 100f;
    [SerializeField] float rotationStrenght = 100f;

    [SerializeField] AudioClip mainEngine;



    AudioSource rocketThrust;

    Rigidbody rb;

    private void Start()
    {
        rb =  GetComponent<Rigidbody>();
        rocketThrust = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }

    private void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if (thrust.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * thrustStrenght * Time.fixedDeltaTime);
            if (!rocketThrust.isPlaying)
            {
                rocketThrust.PlayOneShot(mainEngine);
            }
            
        }
        else
        {
            rocketThrust.Stop();
        }
    }

    private void ProcessRotation()
    {
        float rotationInput = rotation.ReadValue<float>();
        if(rotationInput < 0)
        {
            AplyRotation(rotationStrenght);
        }
        else  if(rotationInput > 0)
        {
            AplyRotation(-rotationStrenght);
        }
    }

    private void AplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.fixedDeltaTime);
        rb.freezeRotation = false;
    }
}