using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("is friendly");
                break;
            case "Finish":
                Debug.Log("you finished");
                break;
            case "Fuel":
                Debug.Log("you are fueled");
                break;
            case "Obstacle":
                Debug.Log("you hit something");
                break;
        }
    }
    
 
}
