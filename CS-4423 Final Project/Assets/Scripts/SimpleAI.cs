using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAI : MonoBehaviour
{
    EnemyMovement movement;
    EnemyCombat combat;
    Enemy enemy;

    [SerializeField] float viewRadius = 5;
    [SerializeField] float attackRadius = 1;
    [SerializeField] bool activated = false;
    [SerializeField] bool attacking = false;
    [SerializeField] Transform playerTransform;

    void Awake()
    {
        movement = GetComponent<EnemyMovement>();
        combat = GetComponent<EnemyCombat>();
    }


        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,playerTransform.position) < attackRadius)
        {
            if(attacking == false)
            {
                attacking = true;
                AttackPlayer();
            }
            
        }
        else if(Vector3.Distance(transform.position,playerTransform.position) < viewRadius)
        {
            FollowPlayer();
        }
        /*
        else if(activated)
        {
            Patrol();
        }
        */
        else
        {
            Idle();
        }
    }

    IEnumerator attackCoroutine()
    {
        combat.Attack();
        yield return new WaitForSeconds(1.5f);
        attacking = false;
    }

    

    public void FollowPlayer()
    {
        activated = true;
        movement.MoveToward(playerTransform.position);
    }

    public void AttackPlayer()
    {
        StartCoroutine(attackCoroutine());
        
        activated = true;
        //combat.Attack();
        //StopCoroutine(attackCoroutine());
    }

    public void Idle()
    {
        movement.Stop();
    }
}
