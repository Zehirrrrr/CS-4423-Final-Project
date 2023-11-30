using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionOptions : MonoBehaviour
{

    [SerializeField] Dropdown resolutionDropdown;
    [SerializeField] Toggle toggle;
    Resolution[] resolutions;


    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        bool setDefault = false;

        if(PlayerPrefs.GetInt("Set Default Resolution") == 0)
        {
            setDefault = true;
            PlayerPrefs.SetInt("Set Default Resolution", 1);
        }


        for(int i = 0; i < resolutions.Length; i++)
        {
            string resolutionString = resolutions[i].width.ToString() + " x " + resolutions[i].height.ToString();
            resolutionDropdown.options.Add(new Dropdown.OptionData(resolutionString));
            if(setDefault && resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                resolutionDropdown.value = i;
            }
        }

        resolutionDropdown.value = PlayerPrefs.GetInt("Resolution Selection");   
        toggle.isOn = PlayerPrefs.GetInt("Fullscreen") == 0;
    }

    public void ChangeResolution()
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, toggle.isOn);
        PlayerPrefs.SetInt("Resolution Selection", resolutionDropdown.value);
        
       
        
    }

    public void ChangeFullscreen()
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, toggle.isOn);

         if(toggle.isOn)
        {
            PlayerPrefs.SetInt("Fullscreen", 0);
        }
        else
        {
            PlayerPrefs.SetInt("Fullscreen", 1);
        }
    }
}
