using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    private Vector3 screenBounds;
    private ServiceLocator _serviceLocator;
    // Start is called before the first frame update
    void Start()
    {
        _serviceLocator = GameObject.Find("GameManager").GetComponent<ServiceLocator>();
        _serviceLocator.AudioService.PlayEffect(_serviceLocator.AudioService.PlayerLaser);
        screenBounds= Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        
        if (transform.position.x > screenBounds.x || transform.position.x < -screenBounds.x ||
            transform.position.y > screenBounds.y || transform.position.y < -screenBounds.y)
        {
            Destroy(gameObject);
        }
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Die();
            Destroy(gameObject);
        }
    }
}
