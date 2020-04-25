using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Death FX")]
    [Tooltip("FX Prefab on enemy")] [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;

    [Header("Points")]
    [SerializeField] int scorePerHit = 10;
    [SerializeField] int hitPoints = 10;
    ScoreBoard scoreBoard;

    [Header("Sound FX")]
    [SerializeField] AudioClip impactAudio;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        AddBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();

        audioSource = GetComponent<AudioSource>();
    }

    private void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();

        if (hitPoints < 1)
        {
            DestroyEnemy();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("enemy hit terrain");
        DestroyEnemy();
    }

    private void ProcessHit()
    {
        audioSource.PlayOneShot(impactAudio);
        hitPoints = hitPoints - 1;
        scoreBoard.scorePerHit(scorePerHit);
    }

    private void DestroyEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }

}
