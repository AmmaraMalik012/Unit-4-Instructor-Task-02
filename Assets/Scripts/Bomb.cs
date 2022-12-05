using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float life = 1f;
    public int kill = 0;
    Kill_Count count;
    public ParticleSystem explosionParticle;
    // public int score = 0;

    void Start()
    {
        // count = GameObject.Find("Kill_Count").GetComponent<Kill_Count>();
    }
    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
        else if(other.gameObject.CompareTag("Enemy"))
        {
            kill += 1;
            explosionParticle.Play();
            // count.kills += 1;
            // Debug.Log("Kills: " + count.kills);
            // Debug.Log("Score: " + score);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        // else if(other.gameObject.CompareTag("Player"))
        // {
        //     Destroy(gameObject);
        //     Destroy(other.gameObject);
        // }
    }
}
