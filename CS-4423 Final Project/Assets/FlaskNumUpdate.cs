using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlaskNumUpdate : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] int flasks;
    Text FlaskText;

    // Start is called before the first frame update
    void Start()
    {
        FlaskText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        flasks = player.GetComponent<Player>().getNumFlasks();
        FlaskText.text =  "" + flasks.ToString();
    }
}
