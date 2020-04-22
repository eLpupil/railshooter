﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Tooltip("FX Prefab on enemy")] [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    private void OnParticleCollision(GameObject other)
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }


    // Update is called once per frame
    void Update()
    {

    }
}
