using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float xmoveSpeed = 0.5f;
    public float boundaryOffset = 0.5f;
    private float minY;
    private float maxY;
    public GameObject ebulletPrefab;
    public Transform[] firePoints;
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;
    Vector3 screenBounds;
    private PowerupSpawner powerupSpawner;
    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        CalculateScreenBoundaries();
        powerupSpawner = FindObjectOfType<PowerupSpawner>();
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject p = GameObject.Find("playerShip1_orange"); 
        Vector3 newPosition = transform.position;

        if (p.transform.position.x > transform.position.x)
        {
            newPosition += new Vector3(-xmoveSpeed * Time.deltaTime, -moveSpeed*Time.deltaTime, 0f);
        }
        else if (p.transform.position.x < transform.position.x)
        {
            newPosition += new Vector3(xmoveSpeed * Time.deltaTime, -moveSpeed*Time.deltaTime, 0f);
        }

        newPosition.x = Mathf.Clamp(newPosition.x, -2f, 2f);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
        transform.position = newPosition;
        CheckShoot();
        if (transform.position.y <= minY)
        {
            // deal damage to player
            Debug.Log("player lost health");
            player.health -= (float)1;
            Destroy(gameObject);
        }
    }

    void CalculateScreenBoundaries()
    {
        Camera mainCamera = Camera.main;
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        
        minY = -screenBounds.y - boundaryOffset;
        maxY = screenBounds.y - boundaryOffset;
    }

    void CheckShoot()
    {
    if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime= Time.time + fireRate;
        }
    }
    void Shoot()
    {
        foreach (Transform firePoint in firePoints)
        {
            firePoint.position = transform.position;
            Instantiate(ebulletPrefab, firePoint.position, firePoint.rotation);
        }   
    }
    public void Die()
    {
        {
            Debug.Log("here3");
            if (powerupSpawner != null)
            {
                Debug.Log("here4");
                powerupSpawner.SpawnPowerup(transform.position);
            }
            Destroy(gameObject);
        }
    }
}
