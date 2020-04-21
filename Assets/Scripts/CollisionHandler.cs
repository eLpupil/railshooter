using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
    }
}
