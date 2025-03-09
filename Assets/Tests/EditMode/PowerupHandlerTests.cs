using NUnit.Framework;
using UnityEngine;
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
