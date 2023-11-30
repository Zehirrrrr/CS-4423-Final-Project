using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCombat : MonoBehaviour
{

    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange = 0.5f;
    [SerializeField] int attackDamage = 2;
    [SerializeField] float attackCooldown = 2f;
    float nextAttackTime = 0f;
    [SerializeField] GameObject atkPoint;


    [SerializeField] LayerMask playerLayers;

    [SerializeField] AnimationStateChanger animationStateChanger;
    [SerializeField] Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Time.time >= nextAttackTime)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackCooldown;
            }
        }

        if(Time.time >= nextParryTime)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                Parry();
                nextParryTime = Time.time + 1f / parryCooldown;
            }
        }
        */
    }

    public void Attack()
    {
        //Play Animation
        animator.SetTrigger("Attack");
        //Detect Enemies
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);



        //Apply DMG
        foreach(Collider2D player in hitPlayer)
        {
           player.GetComponent<Player>().TakeDmg(attackDamage);
            Debug.Log("We hit " + player.name);
        }
    }
/*
    void Parry()
    {
        animator.SetTrigger("Parry");

        Collider2D[] parriedEnemies = Physics2D.OverlapCircleAll(parryPoint.position, parryRange, enemyLayers);


        foreach(Colldier2D enemy in parriedEnemies)
        {
            enemy.GetComponent<Enemy>().TakePostureDmg(parryDamage);
        }
    }
*/
    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void disableAttackHitbox()
    {
        atkPoint.SetActive(false);
    }

    public void enableAttackHitbox()
    {
        atkPoint.SetActive(true);
    }
/*
        if(parryPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(parryPoint.position, parryRange);
    }
*/ 
}
