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
    private PlayerController playerController;
    private Powerup powerup;
    [SetUp]
    public void SetUp()
    {
        playerController = Substitute.For<PlayerController>();
        powerup = new GameObject().AddComponent<SamplePowerup>(); 

        GameObject gameObject = new GameObject();
        powerupHandler = gameObject.AddComponent<PowerupHandler>();
        
        Assert.IsNotNull(powerupHandler);
    }


    [Test]
    public void AddPowerup_ShouldAddToListAndApplyEffect()
    {
        // Arrange
        // Act
        powerupHandler.AddPowerup(powerup);

        // Assert
        Assert.Contains(powerup, powerupHandler.GetActivePowerups());
        
    }

    [Test]
    public void RemovePowerup_ExistingPowerup_ShouldRemoveFromListAndRemoveEffect()
    {
        // Arrange
        powerupHandler.AddPowerup(powerup);

        // Act
        powerupHandler.RemovePowerup(powerup);

        // Assert
        Assert.IsFalse(powerupHandler.GetActivePowerups().Contains(powerup));

    }

    [Test]
    public void RemovePowerup_NonExistingPowerup_ShouldNotRemoveEffect()
    {
        // Arrange
        Powerup anotherPowerup = Substitute.For<Powerup>();
        powerupHandler.AddPowerup(anotherPowerup);

        // Act
        powerupHandler.RemovePowerup(powerup);

        // Assert
        Assert.Contains(anotherPowerup, powerupHandler.GetActivePowerups());

    }

    [Test]
    public void OnDestroy_ShouldRemoveAllPowerupsAndClearList()
    {
        // Arrange
        powerupHandler.AddPowerup(powerup);
        Powerup anotherPowerup = Substitute.For<Powerup>();
        powerupHandler.AddPowerup(anotherPowerup);

        // Act
        powerupHandler.OnDestroy();

        // Assert
        Assert.IsEmpty(powerupHandler.GetActivePowerups());
    }
}