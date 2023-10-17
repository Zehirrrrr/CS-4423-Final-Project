using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    

    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange = 0.5f;
    [SerializeField] int attackDamage = 2;
    [SerializeField] float attackCooldown = 2f;
    float nextAttackTime = 0f;

    [SerializeField] Transform parryPoint;
    [SerializeField] float parryRange = 0.5f;
    [SerializeField] int parryDamage = 1;
    [SerializeField] float parryCooldown = 3f;
    float nextParryTime = 0f;

    [SerializeField] LayerMask enemyLayers;
    [SerializeField] LayerMask parryLayer;

    [SerializeField] AnimationStateChanger animationStateChanger;
    [SerializeField] Animator animator;

    [SerializeField] AudioSource attackSFX;
    [SerializeField] AudioSource parrySFX;

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

        if(Time.time >= nextParryTime)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                Parry();
                nextParryTime = Time.time + 1f / parryCooldown;
            }
        }
        
    }

    void Attack()
    {
        //Play Animation
        animator.SetTrigger("Attack");
        attackSFX.Play();
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
        
        Collider2D[] parriedEnemies = Physics2D.OverlapCircleAll(parryPoint.position, parryRange, parryLayer);


        foreach(Collider2D enemy in parriedEnemies)
        {
            enemy.transform.parent.GetComponent<Enemy>().TakePostureDmg(parryDamage);
            parrySFX.Play();
        }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

        if(parryPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(parryPoint.position, parryRange);
    }
    
}
