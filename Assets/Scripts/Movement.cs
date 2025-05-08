using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;

    [SerializeField] InputAction rotation;
    [SerializeField] float thrustStrenght = 100f;
    [SerializeField] float rotationStrenght = 100f;

    [SerializeField] ParticleSystem MainBoosterFX;
    [SerializeField] ParticleSystem LeftBoosterFX;
    [SerializeField] ParticleSystem RightBoosterFX;

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
            StartThrusting();

        }
        else
        {
            StopThrusting();
        }
    }

    private void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * thrustStrenght * Time.fixedDeltaTime);
        if (!rocketThrust.isPlaying)
        {
            rocketThrust.PlayOneShot(mainEngine);
        }
        if (!MainBoosterFX.isPlaying)
        {
            MainBoosterFX.Play();
        }
    }
    private void StopThrusting()
    {
        rocketThrust.Stop();
        MainBoosterFX.Stop();
    }

    

    private void ProcessRotation()
    {
        float rotationInput = rotation.ReadValue<float>();
        if(rotationInput < 0)
        {
            StartRightRotation();
        }
        else  if(rotationInput > 0)
        {
            StartLeftRotation();
        }
        else
        {
            StopAllRotation();
        }
    }

    private void StartLeftRotation()
    {
        AplyRotation(-rotationStrenght);
        if (!LeftBoosterFX.isPlaying)
        {
            RightBoosterFX.Stop();
            LeftBoosterFX.Play();
        }
    }
    private void StartRightRotation()
    {
        AplyRotation(rotationStrenght);
        if (!RightBoosterFX.isPlaying)
        {
            LeftBoosterFX.Stop();
            RightBoosterFX.Play();
        }
    }
    private void StopAllRotation()
    {
        LeftBoosterFX.Stop();
        RightBoosterFX.Stop();
    }
    private void AplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.fixedDeltaTime);
        rb.freezeRotation = false;
    }
}