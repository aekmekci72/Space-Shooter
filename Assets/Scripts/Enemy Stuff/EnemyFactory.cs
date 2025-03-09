using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{

    public GameObject eRedPrefab;
    public GameObject eBluePrefab;

    public Enemy CreateEnemy(EnemyType type, Vector3 position)
    {
        GameObject enemyObj = null;
    

        switch (type)
        {
            case EnemyType.EnemyBlue:
                enemyObj = Instantiate(eBluePrefab, position, Quaternion.identity);
                break;
            case EnemyType.EnemyRed:
                enemyObj = Instantiate(eRedPrefab, position, Quaternion.identity);
                break;
        }

        Enemy enemy = enemyObj.GetComponent<Enemy>();
        // MessageManager.Instance.spawnMessenger.SendMessage(new SpawnMessage(enemy));
        // enemy.Initialize();
        return enemy;
    }
}
