using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ebullet : MonoBehaviour
{
    public float speed = 10f;
    private Vector3 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
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
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("here");
        PlayerController player = collision.GetComponent<PlayerController>();
        Debug.Log("bullet hit player");
        if (player != null)
        {
            if (player.takingDamage){
                player.health -= (float)1;
            }
            
            if (player.health<=0)
            {
                //GameplayState.PlayerIsDead() = true;
                Debug.Log("player dead");
                GameStateManager.Instance.SetState(new DeathScreenState());
            }

            Destroy(gameObject);
        }
    }
}
