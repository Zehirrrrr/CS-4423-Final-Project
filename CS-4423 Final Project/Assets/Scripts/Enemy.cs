using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int maxHealth = 10;
    [SerializeField] int postureHealth = 2;
    int currentPosture;
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDmg(int damage)
    {
        currentHealth -= damage;

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
            Stun();
        }
    }
    

    //Play animation

    

    void Die()
    {
        Debug.Log("Enemy died");
    }

    void Stun()
    {
        Debug.Log("Enemy stunned");
    }
}
