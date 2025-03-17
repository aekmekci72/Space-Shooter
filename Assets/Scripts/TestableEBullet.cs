using UnityEngine;
namespace Tests 
{
    public class TestableEbullet : Ebullet
    {
        public void TestOnTriggerEnter2D(Collider2D collider) => OnTriggerEnter2D(collider);
    }
}