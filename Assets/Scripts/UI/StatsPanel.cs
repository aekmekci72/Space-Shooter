using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsPanel : MonoBehaviour
{
    public Text EnemiesSpawned;



    // Update is called once per frame
    void Update()
    {
        EnemiesSpawned.text = ""+StatTracker.Instance.EnemiesSpawned;
    }
}
