using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
public class Ebullet : MonoBehaviour
{
    public float speed = 10f;
    private Vector3 screenBounds;
    private ServiceLocator _serviceLocator;
    // Start is called before the first frame update
    void Start()
    {
        _serviceLocator = GameObject.Find("GameManager").GetComponent<ServiceLocator>();
        _serviceLocator.AudioService.PlayEffect(_serviceLocator.AudioService.EnemyLaser);
        screenBounds= Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        
        if (transform.position.x > screenBounds.x || transform.position.x < -screenBounds.x ||
            transform.position.y > screenBounds.y || transform.position.y < -screenBounds.y)
        {
            Destroy(gameObject);
        }
    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("here");
        PlayerController player = collision.GetComponent<PlayerController>();
        Debug.Log("bullet hit player");
        if (player != null)
        {
            if (player.takingDamage){
                player.health -= (float)1;
                _serviceLocator.AudioService.PlayEffect(_serviceLocator.AudioService.PlayerDamage);
            }
            
            if (player.health<=0)
            {
                Debug.Log("player dead");
                GameStateManager.Instance.SetState(new DeathScreenState());
            }

            Destroy(gameObject);
        }
    }
}
