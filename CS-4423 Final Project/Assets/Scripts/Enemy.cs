using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    EnemyMovement movement;

    [SerializeField] int maxHealth = 10;
    public int postureHealth = 2;
    public bool stunned;
    public int currentPosture;
    public int currentHealth;
    [SerializeField] ParticleSystem blood;
    

    void Awake()
    {
        movement = GetComponent<EnemyMovement>();
        currentPosture = postureHealth;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public void TakeDmg(int damage)
    {
        currentHealth -= damage;
        blood.Emit(5);
        if(currentHealth <= 0)
        {
            Die();
            
        }
    }

    public void TakePostureDmg(int postureDamage)
    {
        currentPosture -= postureDamage;

        if(currentPosture <= 0)
        {
            stunned = true;
            Debug.Log("stunned = true");
        }
    }
    
    void Die()
    {
        Debug.Log("Enemy died");
        gameObject.SetActive(false);
    }

    

    
}
