using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanelButtons : MonoBehaviour
{
    public GameObject statsPanel;
    UIState state = UIState.none;

    public enum UIState
    {
        none,
        stats
    }
    
    // Start is called before the first frame update
    void Start()
    {
        DisableAll();
    }

    private void DisableAll()
    {
        statsPanel.SetActive(false);
    }

    public void statsButtonPush()
    {
        DisableAll(); 
        if (state == UIState.stats)
        {
            state = UIState.none;
        }
        else
        {
            state = UIState.stats;
            statsPanel.SetActive(true);
        }
    }
}
