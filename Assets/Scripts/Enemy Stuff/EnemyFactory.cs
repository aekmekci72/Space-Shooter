using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{

    public GameObject eRedPrefab;
    public GameObject eBluePrefab;

    public Enemy CreateEnemy(EnemyType type, Vector3 position)
    {
        Debug.Log("eBluePrefab: " + eBluePrefab);
        Debug.Log("eRedPrefab: " + eRedPrefab);

        GameObject enemyObj = null;

        switch (type)
        {
            case EnemyType.EnemyBlue:
                enemyObj = Instantiate(eBluePrefab, position, Quaternion.identity);
                break;
            case EnemyType.EnemyRed:
                enemyObj = Instantiate(eRedPrefab, position, Quaternion.identity);
                break;
            default:
                Debug.LogError("EnemyFactory: Unknown enemy type: " + type);
                return null;
        }

        if (enemyObj != null)
        {
            Enemy enemy = enemyObj.GetComponent<Enemy>();
            return enemy;
        }
        else
        {
            return null;
        }
    }
}
