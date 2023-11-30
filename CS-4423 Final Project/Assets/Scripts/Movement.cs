using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{

    [SerializeField] float speed = 1;
    [SerializeField] float jumpStrength = 10;
    private bool doubleJump;
    
    
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform checkGround;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask deathLayer;

    [SerializeField] AnimationStateChanger animationStateChanger;
    public UnityEvent deathBlockEvent;

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

    private bool onDeath()
    {
        return Physics2D.OverlapCircle(checkGround.position,0.2f, deathLayer);
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
                //Debug.Log("Jump");
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

        if(onDeath())
        {
            deathBlockEvent.Invoke();
        }

        moveRB(vel);
    }


    public void MoveToward(Vector3 targetPosition)
    {
        Vector3 direction = targetPosition - transform.position;
        direction = Vector3.Normalize(direction);
        moveRB(direction);
    }

    public void Stop()
    {
        moveRB(Vector3.zero);
    }
    
}
/*
https://www.youtube.com/watch?v=K1xZ-rycYY8
https://www.youtube.com/watch?v=RdhgngSUco0
A few tutorials I used to help with some of the movement.
*/