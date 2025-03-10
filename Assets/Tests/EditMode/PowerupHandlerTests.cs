// Anna Ekmekci

// When designing the test suite for the PowerupHandler class, I prioritized balancing completeness and maintainability by focusing more on testing behavior and outcomes rather than the implementation details. I ensured that the tests covered all of the critical functionality such as adding, removing, and clearing powerups while not over-specifying internal workings that could make the tests brittle. Instead of verifying internal state changes directly, I validated observable effects like whether the powerup was applied or removed from the player. This ensures that the tests will remain robust against refactoring or changes to internal implementation/powerup types while still verifying correctness. I also used mocks via NSubstitute to isolate dependencies like PlayerController and Powerup which allowed me to focus solely on PowerupHandler's behavior. However, this tradeoff also means that integration with the current implementations of PowerupHandler are not testing in this test suite, which would require separate integration tests. 


using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;
using System.Collections.Generic;
using NSubstitute;

public class PowerupHandlerTests
{
    private PowerupHandler powerupHandler;
    private PlayerController mockPlayer;

    [SetUp]
    public void Setup()
    {
        GameObject gameObject = new GameObject();
        powerupHandler = gameObject.AddComponent<PowerupHandler>();

        mockPlayer = Substitute.For<PlayerController>();

        powerupHandler.GetComponent<PlayerController>().Returns(mockPlayer);
    }

    [TearDown]
    public void Teardown()
    {
        Object.DestroyImmediate(powerupHandler.gameObject);
    }

    [Test]
    public void AddPowerup_ShouldAddToListAndApplyEffect()
    {
        // Arrange
        var mockPowerup = Substitute.For<Powerup>();

        // Act
        powerupHandler.AddPowerup(mockPowerup);

        // Assert
        Assert.That(powerupHandler.GetActivePowerups(), Does.Contain(mockPowerup));
        mockPowerup.Received(1).ApplyEffect(mockPlayer);
    }

    [Test]
    public void RemovePowerup_ExistingPowerup_ShouldRemoveFromListAndRemoveEffect()
    {
        // Arrange
        var mockPowerup = Substitute.For<Powerup>();
        powerupHandler.AddPowerup(mockPowerup);

        // Act
        powerupHandler.RemovePowerup(mockPowerup);

        // Assert
        Assert.That(powerupHandler.GetActivePowerups(), Does.Not.Contain(mockPowerup));
        mockPowerup.Received(1).RemoveEffect(mockPlayer);
    }

    [Test]
    public void RemovePowerup_NonExistingPowerup_ShouldNotRemoveEffect()
    {
        // Arrange
        var mockPowerup = Substitute.For<Powerup>();

        // Act
        powerupHandler.RemovePowerup(mockPowerup);

        // Assert
        mockPowerup.DidNotReceive().RemoveEffect(Arg.Any<PlayerController>());
    }

    [Test]
    public void OnDestroy_ShouldRemoveAllPowerupsAndClearList()
    {
        // Arrange
        var mockPowerup1 = Substitute.For<Powerup>();
        var mockPowerup2 = Substitute.For<Powerup>();
        powerupHandler.AddPowerup(mockPowerup1);
        powerupHandler.AddPowerup(mockPowerup2);

        // Act
        powerupHandler.SendMessage("OnDestroy");

        // Assert
        mockPowerup1.Received(1).RemoveEffect(mockPlayer);
        mockPowerup2.Received(1).RemoveEffect(mockPlayer);
        Assert.That(powerupHandler.GetActivePowerups(), Is.Empty);
    }

}
