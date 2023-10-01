using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float speed = 5;
    private bool doubleJump;
    
    
    
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform checkGround;
    [SerializeField] private LayerMask groundLayer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private bool onGround()
    {
        return Physics2D.OverlapCircle(checkGround.position,0.2f, groundLayer);
    }
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed*Time.deltaTime,0,0);
            transform.localScale = new Vector3(1,1,1);
            
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(speed*Time.deltaTime,0,0); 
            transform.localScale = new Vector3(-1,1,1);
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            if(onGround() || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + 5f);

                doubleJump = !doubleJump;
            }
        }

        if(onGround() && !Input.GetKey(KeyCode.W))
        {
            doubleJump = false;
        }
        /*
        if(Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0,speed*Time.deltaTime,0);
        }
        */

        
    }

    
}
/*
https://www.youtube.com/watch?v=K1xZ-rycYY8
https://www.youtube.com/watch?v=RdhgngSUco0
A few tutorials I used to help with some of the movement.
*/