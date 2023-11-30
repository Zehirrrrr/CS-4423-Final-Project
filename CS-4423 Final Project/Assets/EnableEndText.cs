using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnableEndText : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI endText;

    public void enableEndText()
    {
        endText.enabled = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
