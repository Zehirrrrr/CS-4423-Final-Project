using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class Checkpoint : MonoBehaviour
{

    
    public GameObject player;
    public int checkpointID;
    //[SerializeField] Text bonfireText;

    

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt(SaveFlags.checkpointString) == checkpointID)
        {
            player.GetComponent<Transform>().position = this.transform.position + (new Vector3 (1,0,0));
        }
    }
/*
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //Time.timeScale = 0;

            if()
            {
                
            }
           
        }
    }
*/
    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(this.transform.position,player.GetComponent<Transform>().position) < 1)
        {
            GetComponentInChildren<Canvas>().enabled = true;
            GetComponentInChildren<TextMeshProUGUI>().transform.position = this.transform.position + (new Vector3 (0,0.5f,0));
        
            if(Input.GetKeyDown(KeyCode.F))
            {
                PlayerPrefs.SetInt(SaveFlags.checkpointString,checkpointID);
                player.GetComponent<Player>().setCurrHealth(player.GetComponent<Player>().getMaxHealth());
                player.GetComponent<Player>().setNumFlasks(3);
                //Debug.Log("checkpoint activated");

                //GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                //foreach(GameObject enemy in enemies)
                //{
                //    enemy.SetActive(true);
                //    Debug.Log("Activate enemy");
            // }
                SceneManager.LoadScene("GameScene");
            }
        }
        else
        {
            GetComponentInChildren<Canvas>().enabled = false;
        }

        

       
    }

    public void SetCheckPointToStart()
    {
        PlayerPrefs.SetInt(SaveFlags.checkpointString, 0);
    }
}
