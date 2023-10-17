using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
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
    

    void Update()
    {
        ExitToMainMenu();
    }
    

    void Die()
    {
        Debug.Log("Player died");
        SceneManager.LoadScene("MainMenu");
    }

    void ExitToMainMenu()
    {
        if(Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    void Stun()
    {
        Debug.Log("Player stunned");
    }
}
