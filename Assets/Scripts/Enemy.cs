using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Tooltip("FX Prefab on enemy")] [SerializeField] GameObject deathFX;
    private void OnParticleCollision(GameObject other)
    {
        print("particle collision with enemy " + gameObject.name);
        //deathFX.SetActive(true);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
