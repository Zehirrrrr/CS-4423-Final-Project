using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] float speed = 1;
    [SerializeField] float size;
    
    
    
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

    public void moveRB(Vector3 vel)
    {
        vel.y = rb.velocity.y;
        rb.velocity = vel;

        if(vel.magnitude > 0)
        {
            animationStateChanger.ChangeAnimationState("Run");

            if(vel.x > 0)
            {
                transform.localScale = new Vector3(1,1,0);
            }
            else if(vel.x < 0)
            {
                transform.localScale = new Vector3(-1,1,0);
            }
        }
        else
        {
            animationStateChanger.ChangeAnimationState("Idle");
        }

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
