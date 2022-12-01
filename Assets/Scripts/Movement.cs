using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] Vector3 roatation = Vector3.forward;
    [SerializeField] float rotationSpeed = 100f;
    [SerializeField] AudioClip mainEngine;

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
            rbodyRocket.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }
           
            //Debug.Log("Space pressed");
        }
        else
        {
            audioSource.Stop();
        }

    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationSpeed);
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rbodyRocket.freezeRotation = true; //freez roatation so we can manually rotate
        transform.Rotate(roatation * rotationThisFrame * Time.deltaTime);
        rbodyRocket.freezeRotation = true; //unfreez roatation so physics system can take over
    }
}
