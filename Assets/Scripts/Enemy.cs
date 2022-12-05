using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    public GameObject player;
    private float enemySpeed = 3.0f;
    // [SerializeField] private int enemyRepelForce = 30;
    // Rigidbody playerRb;
    Rigidbody enemyRb;
    // Start is called before the first frame update
    void Start()
    {
    //     playerRb = GetComponent<Rigidbody>();
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // getting offset(distance between player and enemy) and then rotate enemy towards that offset
        Vector3 offset = player.transform.position - transform.position;
        offset.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(offset);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, enemySpeed * Time.deltaTime);
        transform.position += transform.forward * enemySpeed * Time.deltaTime;
    }
}
