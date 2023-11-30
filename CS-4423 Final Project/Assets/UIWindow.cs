using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWindow : MonoBehaviour
{
    public void Show()
    {
        GetComponent<Canvas>().enabled = true;
    }

    public void Hide()
    {
        GetComponent<Canvas>().enabled = false;
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
