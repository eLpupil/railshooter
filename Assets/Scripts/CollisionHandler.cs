using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //ok as long as this is the only script that will load scenes

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("In seconds")][SerializeField] float loadSceneDelay = 1.5f;
    [Tooltip("FX Prefab on player")][SerializeField] GameObject deathFX;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Enemy":
                print("Hit enemy ship");
                StartDeathSequence();
                break;
            default:
                print("Player hit terrain");
                StartDeathSequence();
                break;
        }
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
        deathFX.SetActive(true);
        Invoke("LoadScene1", loadSceneDelay);
    }

    private void LoadScene1() //referenced in a string
    {
        SceneManager.LoadScene(1);
    }
}
