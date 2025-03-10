// // Sylvia Lee
// 
// I designed a test suite for the aspects that correlate to the health of the player.
// This suite ensures that the Player accurate gains health when it obtains a Health powerup.
//
// This suite also ensures that the Player loses health accordingly, when it is hit with an Enemy Bullet
// and displays a death message if the Player were to lose all of their health.
// I used NSubstitute to mock dependencies like a mockPlayer, poweruphandler, etc... to ensure that 

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
        var mockCollider = Substitute.For<Collider2D>();
        powerupHandler.GetComponent<PlayerController>().Returns(mockPlayer);
        mockPlayer.health = 5;

        // Act
        enemyBullet.OnTriggerEnter2D(mockCollider);

        // Assert
        Assert.AreEqual(10, mockPlayer.health);
    }

    [TearDown]
    public void Teardown()
    {
        Object.Destroy(bulletObject);
    }


    // [Test]
    // public void AddPowerup_ShouldAddToListAndApplyEffect()
    // {
    //     // Arrange
    //     var mockPowerup = Substitute.For<Powerup>();

    //     // Act
    //     powerupHandler.AddPowerup(mockPowerup);

    //     // Assert
    //     Assert.That(powerupHandler.GetActivePowerups(), Does.Contain(mockPowerup));
    //     mockPowerup.Received(1).ApplyEffect(mockPlayer);
    // }

    // [Test]
    // public void RemovePowerup_ExistingPowerup_ShouldRemoveFromListAndRemoveEffect()
    // {
    //     // Arrange
    //     var mockPowerup = Substitute.For<Powerup>();
    //     powerupHandler.AddPowerup(mockPowerup);

    //     // Act
    //     powerupHandler.RemovePowerup(mockPowerup);

    //     // Assert
    //     Assert.That(powerupHandler.GetActivePowerups(), Does.Not.Contain(mockPowerup));
    //     mockPowerup.Received(1).RemoveEffect(mockPlayer);
    // }

    // [Test]
    // public void RemovePowerup_NonExistingPowerup_ShouldNotRemoveEffect()
    // {
    //     // Arrange
    //     var mockPowerup = Substitute.For<Powerup>();

    //     // Act
    //     powerupHandler.RemovePowerup(mockPowerup);

    //     // Assert
    //     mockPowerup.DidNotReceive().RemoveEffect(Arg.Any<PlayerController>());
    // }

    // [Test]
    // public void OnDestroy_ShouldRemoveAllPowerupsAndClearList()
    // {
    //     // Arrange
    //     var mockPowerup1 = Substitute.For<Powerup>();
    //     var mockPowerup2 = Substitute.For<Powerup>();
    //     powerupHandler.AddPowerup(mockPowerup1);
    //     powerupHandler.AddPowerup(mockPowerup2);

    //     // Act
    //     powerupHandler.SendMessage("OnDestroy");

    //     // Assert
    //     mockPowerup1.Received(1).RemoveEffect(mockPlayer);
    //     mockPowerup2.Received(1).RemoveEffect(mockPlayer);
    //     Assert.That(powerupHandler.GetActivePowerups(), Is.Empty);
    // }

}