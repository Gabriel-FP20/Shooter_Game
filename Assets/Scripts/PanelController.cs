using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PanelController : MonoBehaviour
{
    public GameObject victoryPanel;
    public GameObject defeatPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VictoryPanel()
    {
        victoryPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void DefeatPanel()
    {
        defeatPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
