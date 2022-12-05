using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Vector3 playerInput;
    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private float speed = 5;
    [SerializeField] private float turnSpeed = 360;
    public int count = 0;
    public int life = 0;
    public Transform minePoint;
    Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // keeping the update clean
        PlayerInput();
    }

    void FixedUpdate(){
        // in fixed update rather than update is because we're using rigid body of player in these functions
        Move();
        Look();
    }

    private void Look() {
        if (playerInput != Vector3.zero)
        {
            // moving player forward depending upon the distance between us and the player input force on pressing key
            var relative = (transform.position + playerInput) - transform.position;
            // player rotation along y axis 
            var rot = Quaternion.LookRotation(relative, Vector3.up);
            // to get contineous smooth rotation rather than snapping
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, turnSpeed * Time.deltaTime);
        }
    }

    // getting player input 
    void PlayerInput()
    {
        playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    // moving player forward in direction
    void Move()
    {
        playerRb.MovePosition(transform.position + (transform.forward * playerInput.magnitude) * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Potion"))
        {
            Destroy(other.gameObject);
            life++;
        }

        // while(!haveBomb)
        // {
        if(other.gameObject.tag == ("Mine"))
            {
                other.gameObject.GetComponent<Rigidbody>().useGravity = false;
                other.gameObject.transform.position = minePoint.position;
                other.gameObject.transform.parent = GameObject.Find("Mine_Point").transform;
                // haveBomb = true;
            }
        // }
    }
    // void OnMouseDown()
    // {
    //     other.gameObject.transform.parent = null;
    //     other.gameObject.GetComponent<Rigidbody>().useGravity = true;
    // }
}
