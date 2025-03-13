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
    // Start is called before the first frame update
    void Start()
    {
        CalculateScreenBoundaries();
        powerupSpawner = FindObjectOfType<PowerupSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("playerShip1_orange"); 
        Vector3 newPosition = transform.position;

        if (player.transform.position.x > transform.position.x)
        {
            newPosition += new Vector3(-xmoveSpeed * Time.deltaTime, -moveSpeed*Time.deltaTime, 0f);
        }
        else if (player.transform.position.x < transform.position.x)
        {
            newPosition += new Vector3(xmoveSpeed * Time.deltaTime, -moveSpeed*Time.deltaTime, 0f);
        }

        newPosition.x = Mathf.Clamp(newPosition.x, -2f, 2f);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
        transform.position = newPosition;
        CheckShoot();
        if (transform.position.y <= minY)
        {
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
