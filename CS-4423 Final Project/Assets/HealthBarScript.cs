using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Slider healthBar;
    [SerializeField] int maxHealth;
    [SerializeField] int currentHealth;
    
    

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindWithTag("Player");
        maxHealth = player.GetComponent<Player>().getMaxHealth();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(healthBar.value != player.GetComponent<Player>().getCurrHealth())
        {
            healthBar.value = player.GetComponent<Player>().getCurrHealth();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            currentHealth -= 1;
        }

    }
}
