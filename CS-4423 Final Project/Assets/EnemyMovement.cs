using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] float speed = 1;
    [SerializeField] float jumpStrength = 10;
    private bool doubleJump;
    
    
    [SerializeField] private Rigidbody2D rb;
    //[SerializeField] private Transform checkGround;
    //[SerializeField] private LayerMask groundLayer;

    [SerializeField] AnimationStateChanger animationStateChanger;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }
/*
    private bool onGround()
    {
        return Physics2D.OverlapCircle(checkGround.position,0.2f, groundLayer);
    }
*/   
    public void moveRB(Vector3 vel)
    {
        vel.y = rb.velocity.y;
        rb.velocity = vel;

        if(vel.magnitude > 0)
        {
            animationStateChanger.ChangeAnimationState("Run");

            if(vel.x > 0)
            {
                transform.localScale = new Vector3(1,1,1);
            }
            else if(vel.x < 0)
            {
                transform.localScale = new Vector3(-1,1,1);
            }
        }
        else
        {
            animationStateChanger.ChangeAnimationState("Idle");
        }

    }

    
/*
    // Update is called once per frame
    void Update()
    {
        Vector3 vel = Vector3.zero;
        //float horizontalMovement = this.GetAxisRaw("Horizontal");
        
        if(vel > 0)
        {
            vel.x = speed;
            transform.localScale = new Vector3(1,1,1);
            
        }

        if(vel < 0)
        {
            vel.x = -speed;
            transform.localScale = new Vector3(-1,1,1);
        }

        moveRB(vel);
    }

*/
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