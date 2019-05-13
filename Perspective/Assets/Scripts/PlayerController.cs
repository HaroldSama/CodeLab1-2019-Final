using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 movement;
    private Rigidbody playerRb;
    private Animator anim;
    public float speed = 1;
    
    //public Vector3 mouseWorldPos;
    // Start is called before the first frame update
    void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // simple mouse look
        
        // 1. get mouse input?
        float horizontalMouseSpeed = Input.GetAxis("Mouse X");
        float verticalMouseSpeed = Input.GetAxis("Mouse Y");
        //Debug.Log(horizontalMouseSpeed);

        // 2. use mouse input to rotate camera
        transform.Rotate(0f, horizontalMouseSpeed * 5, 0f);
        Camera.main.transform.Rotate(-verticalMouseSpeed * 5, 0f, 0f);


        // 3. unroll the camera, we need to set it's Z angle to 0f, always.
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0f);
        
        //Movement
        float x = Input.GetAxisRaw("Horizontal") * speed;
        float z = Input.GetAxisRaw("Vertical") * speed;
        //float x = Input.GetAxisRaw("Horizontal" + playerNum) * speed;
        //float z = Input.GetAxisRaw("Vertical" + playerNum) * speed;
        //playerRb.velocity = new Vector3(x, 0, -z);
        
        // Set the movement vector based on the axis input.
        movement = z * transform.forward + x * transform.right;
        
        // Normalise the movement vector and make it proportional to speed per second.
        movement = movement.normalized * speed * Time.deltaTime;
//        print("player is moving =" + movement);


        // Move the player

        playerRb.MovePosition (transform.position + movement);
            
        if (!(x == 0 && z == 0))
        {
            //transform.rotation = Quaternion.LookRotation(movement);
        }
        
        
        _animating(x, z);
    }
    

    private void _animating(float h, float v)
    {
        // Create a boolean that is true if either of the input axes is non-zero.
        bool walking = h != 0f || v != 0f;

        // Tell the animator whether or not the player is walking.
        anim.SetBool ("IsWalking", walking);
    }
}
