using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delay = 2f;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip success;

    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem successParticles;
    


    AudioSource audioSource;
    

    bool isTransitioning = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();     
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (isTransitioning){return;}

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("is friendly");
                break;
            case "Finish":
                SuccessSequence();
                //Debug.Log("you finished");
                break;
            case "Fuel":
                Debug.Log("you are fueled");
                break;
            default:
                StartCrashSequence();
                //Debug.Log("you hit something");
                break;
        }

    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        
    }
    
    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        crashParticles.Play();
        //todo add particle effect on crash
        GetComponent<Movement>().enabled = false;
        audioSource.PlayOneShot(crash);
        Invoke("ReloadLevel", delay);
        
    }

    void SuccessSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        successParticles.Play();
        //todo add particle effect on success
        GetComponent<Movement>().enabled = false;
        audioSource.PlayOneShot(success);
        Invoke("LoadNextLevel", delay);
    }
 
}
