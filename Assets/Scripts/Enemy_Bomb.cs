using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bomb : MonoBehaviour
{
    public Transform enemyLaunchPoint;
    public GameObject bomb;
    public float launchVelocity = 10f;
    // Start is called before the first frame update
    void Start()
    {
        var projectilePrefab = Instantiate(bomb, enemyLaunchPoint.position, enemyLaunchPoint.rotation);
            projectilePrefab.GetComponent<Rigidbody>().velocity = enemyLaunchPoint.up * launchVelocity;
    }

    // Update is called once per frame
    void Update()
    {
            
    }
}
