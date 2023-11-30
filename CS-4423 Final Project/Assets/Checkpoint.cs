using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Checkpoint : MonoBehaviour
{

    
    public GameObject player;
    public int checkpointID;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt(SaveFlags.checkpointString) == checkpointID)
        {
            player.GetComponent<Transform>().position = this.transform.position + (new Vector3 (3,0,0));
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //Time.timeScale = 0;

            if(Input.GetKeyDown(KeyCode.F))
            {
                PlayerPrefs.SetInt(SaveFlags.checkpointString,checkpointID);
                player.GetComponent<Player>().setCurrHealth(player.GetComponent<Player>().getMaxHealth());
                player.GetComponent<Player>().setNumFlasks(3);
                Debug.Log("checkpoint activated");

                //GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                //foreach(GameObject enemy in enemies)
                //{
                //    enemy.SetActive(true);
                //    Debug.Log("Activate enemy");
            // }
                SceneManager.LoadScene("GameScene");
            }
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
