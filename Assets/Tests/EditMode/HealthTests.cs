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
using Tests;

public class HealthTests
{
    private PlayerController mockPlayer;
    private TestableHealthPowerup mockPowerup;
    private TestableEbullet enemyBullet;
    private GameObject bulletObject;
    private GameObject playerObject;
    private GameObject powerupObject; 

    [SetUp]
    public void Setup()
    {
        GameObject gameStateManagerObject = new GameObject("GameManager");
        GameStateManager gameManager = gameStateManagerObject.AddComponent<GameStateManager>();
 
        DeathScreenState deathScreenState = new DeathScreenState();
        GameObject gameManagerObject = new GameObject("GameManager");
        var serviceLocator = gameManagerObject.AddComponent<ServiceLocator>();
        serviceLocator.AudioService = gameManagerObject.AddComponent<SoundManager>();

        powerupObject= new GameObject();
        mockPowerup = powerupObject.AddComponent<TestableHealthPowerup>();

        bulletObject = new GameObject();
        enemyBullet = bulletObject.AddComponent<TestableEbullet>();

        playerObject = new GameObject();
        mockPlayer = playerObject.AddComponent<PlayerController>();

        //mockPlayer = Substitute.For<PlayerController>();
    }

    [TearDown]
    public void Teardown()
    {
        if (bulletObject != null)
        {
            Object.DestroyImmediate(bulletObject);
        }
        if (powerupObject != null)
        {
            Object.DestroyImmediate(powerupObject);
        }
    }

    [Test]
    public void BulletHitsPlayer_ReducesHealth()
    {
        // Arrange
        mockPlayer.health = 5; 
        mockPlayer.takingDamage = true; 
        var mockCollider = playerObject.AddComponent<BoxCollider2D>();

        // Act
        enemyBullet.TestOnTriggerEnter2D(mockCollider);

        // Assert 
        LogAssert.Expect(LogType.Log, "bullet hit player");
        Assert.AreEqual(4, mockPlayer.health);
    }

    [Test]
    public void HealthPowerUp_IncreasesHealth()
    {
        // Arrange
        mockPlayer.health = 5;

        // Act
        mockPowerup.ApplyEffect(mockPlayer);

        // Assert
        Assert.AreEqual(10, mockPlayer.health);
    }

    [Test]
    public void PlayerDies_SendsDeathMessage()
    {
        // Arrange
        mockPlayer.health = 1; 
        mockPlayer.takingDamage = true; 
        var mockCollider = playerObject.AddComponent<BoxCollider2D>();

        // Act
        enemyBullet.TestOnTriggerEnter2D(mockCollider);

        // Assert
        LogAssert.Expect(LogType.Log, "player dead");
    }

}