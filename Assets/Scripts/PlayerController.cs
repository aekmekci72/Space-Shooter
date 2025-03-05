using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float boundaryOffset = 0.5f;
    private float minX;
    private float maxX;
    public GameObject bulletPrefab;
    public Transform[] firePoints;
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;
    public bool takingDamage =true;
    private List<Powerup> activePowerups = new List<Powerup>();
    public float health = 1f;

    // Start is called before the first frame update
    void Start()
    {
        CalculateScreenBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        CheckShoot();
    }

    void CalculateScreenBoundaries()
    {
        Camera mainCamera = Camera.main;
        Vector3 screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        
        minX = -screenBounds.x + boundaryOffset;
        maxX = screenBounds.x - boundaryOffset;
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput*moveSpeed*Time.deltaTime, 0f,0f);
        Vector3 newPosition = transform.position + movement;
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        transform.position = newPosition;
    }

    void CheckShoot()
    {
    if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime= Time.time + fireRate;
        }
    }
    void Shoot()
    {
        foreach (Transform firePoint in firePoints)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }   
    }
    public void AddPowerup(Powerup powerup)
    {
        activePowerups.Add(powerup);
        powerup.ApplyEffect(this);
    }
    public void RemovePowerup(Powerup powerup)
    {
        if (activePowerups.Contains(powerup))
        {
            activePowerups.Remove(powerup);
            powerup.RemoveEffect(this);
        }
    }

    private void OnDestroy()
    {
        foreach (Powerup powerup in activePowerups)
        {
            powerup.RemoveEffect(this);
        }
        activePowerups.Clear();
    }
}
