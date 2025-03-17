using UnityEngine;
namespace Tests 
{
    public class TestableHealthPowerup : Powerup
    {
        public float healthIncrease = 5f; 

        public override void ApplyEffect(PlayerController player)
        {
            player.health = Mathf.Min(player.health + healthIncrease, 20f);
            DestroyImmediate(gameObject); 
        }

        public override void RemoveEffect(PlayerController player)
        {
            // Health increase is permanent, nothing to remove
        }
        public void TestOnTriggerEnter2D(Collider2D collider) => OnTriggerEnter2D(collider);
    }
}