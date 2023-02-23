using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigPanel : MonoBehaviour
{
    public GameObject configPanel;
    public bool actived;

    // Start is called before the first frame update
    void Start()
    {
        actived = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ConfigurationsPanel()
    {
        if(actived == false)
        {
            configPanel.SetActive(true);
            actived = true;
        }
        else
        {
            configPanel.SetActive(false);   
            actived = false;
        }
    }
}
