using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] int maxHealth;
    [SerializeField] int postureHealth;
    int currentPosture;
    [SerializeField] int currentHealth;
    [SerializeField] ParticleSystem blood;

    [SerializeField] int numFlasks;
    [SerializeField] ParticleSystem heal;
    [SerializeField] ParticleSystem voidParticles;
    [SerializeField] AudioSource healSFX;
    [SerializeField] AudioSource hurtSFX;

    //public UnityEvent onDeathEvent;
    public UnityEvent pauseEvent;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        maxHealth = 100;
        numFlasks = 3;
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

    public void Heal()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(currentHealth != maxHealth && numFlasks > 0)
            {
                    numFlasks = numFlasks - 1;
                    healSFX.Play();
                    heal.Emit(5);
                    currentHealth = maxHealth;
                    Debug.Log("Player Healed, Flasks left =" + numFlasks);
            }
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
    

    void Update()
    {
        //if(this.GetComponent<Transform>.transform.y > 20)
        {
            //Die();
        }


        Heal();
        pauseGame();
        //ExitToMainMenu();
    }
    

    void Die()
    {
        //Debug.Log("Player died");
        //onDeathEvent.Invoke();
        backToCheckpoint();
    }

    public void pauseGame()
    {
        if(Input.GetKeyDown("escape"))
        pauseEvent.Invoke();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void backToCheckpoint()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void enableVoidParticles()
    {
        voidParticles.Play();
    }

    void ExitToMainMenu()
    {
        if(Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Stun()
    {
        Debug.Log("Player stunned");
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

    public int getNumFlasks()
    {
        return numFlasks;
    }

    public void setNumFlasks(int flasks)
    {
        numFlasks = flasks;
    }
}
