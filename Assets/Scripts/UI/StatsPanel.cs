using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsPanel : MonoBehaviour
{
    public Text EnemiesSpawned;
    public Text PowerupsGained;


    // Update is called once per frame
    void Update()
    {
        EnemiesSpawned.text = ""+StatTracker.Instance.EnemiesSpawned;
        PowerupsGained.text = ""+StatTracker.Instance.PowerupsGained;

    }
}
