// // Sylvia Lee
// 
// I designed a test suite for the aspects that correlate to the health of the player.
// This suite ensures that the Player accurate gains health when it obtains a Health powerup.
//
// This suite also ensures that the Player loses health accordingly, when it is hit with an Enemy Bullet
// and displays a death message if the Player were to lose all of their health.
// I used NSubstitute to mock dependencies like a mockPlayer, poweruphandler, etc... which allows me to focus soley on the Player's health

using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;
using System.Collections.Generic;
using NSubstitute;

public class HealthTests
{
    private PlayerController mockPlayer;
    private PowerupHandler powerupHandler;
    private Ebullet enemyBullet;
    private GameObject bulletObject;
    private GameObject playerObject;
    private GameObject powerupObject;

    [SetUp]
    public void Setup()
    {
        powerupObject= new GameObject();
        powerupHandler = gameObject.AddComponent<PowerupHandler>();

        bulletObject = new GameObject();
        enemyBullet = bulletObject.AddComponent<Ebullet>();

        mockPlayer = Substitute.For<PlayerController>();
    }

    [TearDown]
    public void Teardown()
    {
        Object.Destroy(bulletObject);
        Object.Destroy(powerupObject);
    }

    [Test]
    public void BulletHitsPlayer_ReducesHealth()
    {
        // Arrange
        var mockCollider = Substitute.For<Collider2D>();
        mockCollider.GetComponent<PlayerController>().Returns(mockPlayer);
        mockPlayer.health = 5; 
        mockPlayer.takingDamage = true; 

        // Act
        enemyBullet.OnTriggerEnter2D(mockCollider);

        // Assert 
        Assert.AreEqual(4, mockPlayer.health);
    }

    [Test]
    public void HealthPowerUp_IncreasesHealth()
    {
        // Arrange
        var mockPowerup = Substitute.For<Health>();
        powerupHandler.GetComponent<PlayerController>().Returns(mockPlayer);
        mockPlayer.health = 5;

        // Act
        powerupHandler.AddPowerup(mockPowerup);
        

        // Assert
        Assert.AreEqual(10, mockPlayer.health);
    }

    [Test]
    public void PlayerDies_SendsDeathMessage()
    {
        // Arrange
        var mockCollider = Substitute.For<Collider2D>();
        mockCollider.GetComponent<PlayerController>().Returns(mockPlayer);
        mockPlayer.health = 1; 
        mockPlayer.takingDamage = true; 

        // Act
        enemyBullet.OnTriggerEnter2D(mockCollider);

        // Assert
        Assert.AreEqual(0, mockPlayer.health);
    }

}