using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float boundaryOffset = 0.5f;
    private float minX;
    private float maxX;
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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        Debug.Log("shoot");
    }
}
