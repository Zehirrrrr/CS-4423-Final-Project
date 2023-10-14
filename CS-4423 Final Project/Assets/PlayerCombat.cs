using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange = 0.5f;
    [SerializeField] int attackDamage = 2;
    [SerializeField] LayerMask enemyLayers;
    [SerializeField] float attackCooldown = 2f;
    float nextAttackTime = 0f;

    [SerializeField] AnimationStateChanger animationStateChanger;
    [SerializeField] Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackCooldown;
            }
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            Parry();
        }
        
    }

    void Attack()
    {
        //Play Animation
        animator.SetTrigger("Attack");
        //Detect Enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);



        //Apply DMG
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDmg(attackDamage);
            //Debug.Log("We hit " + enemy.name);
        }
    }

    void Parry()
    {
        animator.SetTrigger("Parry");
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    
}
