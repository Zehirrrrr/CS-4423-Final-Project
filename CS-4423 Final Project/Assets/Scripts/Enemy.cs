using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    EnemyMovement movement;

    [SerializeField] int maxHealth = 10;
    public int postureHealth = 2;
    public bool stunned;
    public int currentPosture;
    public int currentHealth;
    [SerializeField] ParticleSystem blood;
    public UnityEvent bossDeath;
    [SerializeField] AudioSource hurtSFX;
    
    

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
        hurtSFX.Play();
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
        //Debug.Log("Enemy died");

        if(this.tag == "Boss")
        {
            gameObject.SetActive(false);
            bossDeath.Invoke();
        }
        else
        {
            gameObject.SetActive(false);
        }
        
    }

    public void bossDie()
    {
        //yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
        
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void loadMenuAfterDelay()
    {
        Invoke("LoadMenu",10);
    }

    public int getCurrHealth()
    {
        return currentHealth;
    }

    public void setCurrHealth(int health)
    {
        currentHealth = health;
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }

    
}
