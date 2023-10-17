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
    SpriteRenderer enemySprite;

    //[SerializeField] bool stunned;
    //[SerializeField] int postureHealth = 2;
    int currentPosture;
    
    void Awake()
    {
        movement = GetComponent<EnemyMovement>();
        combat = GetComponent<EnemyCombat>();
        enemy = GetComponent<Enemy>();
        enemySprite = GetComponent<SpriteRenderer>();
    }


        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,playerTransform.position) < attackRadius && enemy.stunned == false)
        {
            if(attacking == false)
            {
                attacking = true;
                AttackPlayer();
            }
            
        }
        else if(Vector3.Distance(transform.position,playerTransform.position) < viewRadius && enemy.stunned == false)
        {
            FollowPlayer();
        }
        
        else if(enemy.stunned == true)
        {
            Stun();
            Debug.Log("AI Stun");
        }
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

    IEnumerator stunCoroutine()
    {
        //play stun animation
        movement.Stop();
        enemySprite.color = new Color(1,0,0,1);
        yield return new WaitForSeconds(2f);
        enemySprite.color = new Color(1,1,1,1);
        enemy.stunned = false;
        enemy.currentPosture = 2;
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

    

    public void Stun()
    {
        enemy.stunned = true;
        StartCoroutine(stunCoroutine());
        Debug.Log("Enemy stunned");
    }
    
}
