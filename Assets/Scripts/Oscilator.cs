using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscilator : MonoBehaviour
{
    Vector3 startPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float velocityFactor;
    [SerializeField] float period = 2f;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        Debug.Log(startPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon){ return; }
        float cycles = Time.time / period; // continually growing over time

        const float tau = Mathf.PI * 2; // constant value of 6.283
        float rawSinWave = Mathf.Sin(cycles * tau); // going from -1 to 1

        velocityFactor = (rawSinWave + 1f) / 2f; // recalculated to go from 0 to 1
               
        Vector3 offset = movementVector * velocityFactor;
        transform.position = startPosition + offset;
        
        
    }
}
