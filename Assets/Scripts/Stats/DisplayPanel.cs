using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPanel : MonoBehaviour {

    public GameObject panel;
    private int canvasCameraCounter;

    // Use this for initialization
    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            canvasCameraCounter++;
            if (canvasCameraCounter % 2 == 1)
            {
                PanelManager panelManager = new PanelManager();
                panel.SetActive(true);
                PanelManager.commitedPoints = true;
                PanelManager.baseStats = true;
                panelManager.PopulatePanel();
            }
            else
            {
                panel.SetActive(false);
                PanelManager.commitedPoints = false;
            }
        }
        
    }
}
