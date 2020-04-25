using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //ok as long as this is the only script that will load scenes

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("In seconds")][SerializeField] float loadSceneDelay = 1.5f;
    [Tooltip("FX Prefab on player")][SerializeField] GameObject deathFX;
    [SerializeField] GameObject jetParticles;

    bool collisionDisabled = false;


    private void Update()
    {
        ProcessDebugKey();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (collisionDisabled) { return; }

        else
        {
            ProcessTriggerEvent(other);
        }
    }

    private void ProcessTriggerEvent(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Enemy":
                StartDeathSequence();
                break;
            default:
                StartDeathSequence();
                break;
        }
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
        deathFX.SetActive(true);
        jetParticles.SetActive(false);
        Invoke("LoadScene0", loadSceneDelay);
    }

    private void LoadScene0() //referenced in a string
    {
        SceneManager.LoadScene(0);
    }

    private void ProcessDebugKey()
    {
        if (Debug.isDebugBuild)
        {
            RespondToDebugKey();
        }
    }

    private void RespondToDebugKey()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled;
        }
    }
}
