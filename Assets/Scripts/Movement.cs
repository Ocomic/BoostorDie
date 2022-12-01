using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rbodyRocket;
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] Vector3 roatation = Vector3.forward;
    [SerializeField] float rotationSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        rbodyRocket = GetComponent<Rigidbody>();
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
            //Debug.Log("Space pressed");
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
