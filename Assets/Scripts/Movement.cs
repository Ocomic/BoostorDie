using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] Vector3 roatation = Vector3.forward;
    [SerializeField] float rotationSpeed = 100f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainThruster1;
    [SerializeField] ParticleSystem mainThruster2;
    [SerializeField] ParticleSystem rightThrust;
    [SerializeField] ParticleSystem leftThrust;

    Rigidbody rbodyRocket;
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        rbodyRocket = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }
    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }

    }       

    void StartThrusting()
    {
        rbodyRocket.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);

        }
        if (!mainThruster1.isPlaying)
        {
            mainThruster1.Play();
            mainThruster2.Play();
        }

        //Debug.Log("Space pressed");
    }
    void StopThrusting()
    {
        audioSource.Stop();
        mainThruster1.Stop();
        mainThruster2.Stop();
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotating();
        }

    }
    private void RotateLeft()
    {
        ApplyRotation(rotationSpeed);
        if (!leftThrust.isPlaying)
        {
            leftThrust.Play();

        }
    }
    private void RotateRight()
    {
        ApplyRotation(-rotationSpeed);
        if (!rightThrust.isPlaying)
        {
            rightThrust.Play();

        }
    }
    private void StopRotating()
    {
        leftThrust.Stop();
        rightThrust.Stop();
    }  
       
    private void ApplyRotation(float rotationThisFrame)
    {
        rbodyRocket.freezeRotation = true; //freez roatation so we can manually rotate
        transform.Rotate(roatation * rotationThisFrame * Time.deltaTime);
        rbodyRocket.freezeRotation = true; //unfreez roatation so physics system can take over
    }
}
