using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float speed = 1;
    [SerializeField] float jumpStrength = 10;
    private bool doubleJump;
    
    
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform checkGround;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] AnimationStateChanger animationStateChanger;

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
    
    public void moveRB(Vector3 vel)
    {
        vel.y = rb.velocity.y;
        rb.velocity = vel;
        
        if(vel.x > 0 || vel.x < 0)
        {
            animationStateChanger.ChangeAnimationState("Run");
        }
        else
        {
            animationStateChanger.ChangeAnimationState("Idle");
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        Vector3 vel = Vector3.zero;
        if(Input.GetKey(KeyCode.D))
        {
            vel.x = speed;
            transform.localScale = new Vector3(1,1,1);
            
        }

        if(Input.GetKey(KeyCode.A))
        {
            vel.x = -speed;
            transform.localScale = new Vector3(-1,1,1);
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            if(onGround() || doubleJump)
            {
                rb.velocity = new Vector3(0,jumpStrength,0);
                Debug.Log("Jump");
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

        moveRB(vel);
    }

    
}
/*
https://www.youtube.com/watch?v=K1xZ-rycYY8
https://www.youtube.com/watch?v=RdhgngSUco0
A few tutorials I used to help with some of the movement.
*/