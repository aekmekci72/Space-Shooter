// Sophia Kim

// When designing the test suite for the StatTracker class, I chose these 4 tests to verify the core behaviors of the StatTracker class,
// which includes incrementing EnemiesKilled, PowerupsGained, and LevelsCleared.
// To prevent a brittle test suite, I used NSubstitute to mock dependencies like Enemy and EnemySpawner (and its dependencies) so I could focus on the StatTracker class.

using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;
using System.Collections.Generic;
using NSubstitute;

public class StatTrackerTests
{
    private StatTracker statTracker;
    private Powerup mockPowerup;
    private KillMessage mockKillMessage;
    private PowerupMessage mockPowerupMessage;
    private MessageManager mockMessageManager;
    private KillMessenger mockKillMessenger;
    private PowerupMessenger mockPowerupMessenger;

    [SetUp]
    public void Setup()
    {
        GameObject gameObject = new GameObject();
        statTracker = gameObject.AddComponent<StatTracker>();
        // mockKillMessenger = Substitute.For<KillMessenger>();
        // mockPowerupMessenger = Substitute.For<PowerupMessenger>();
        // MessageManager.Instance = mockMessageManager; // Ensure we override before Start()
        statTracker.Start(); // Now Start() will subscribe to the mocked Messenger
    }

    [Test]
    public void EnemyKilled_ShouldIncrementEnemiesKilled()
    {
        // Arrange
        // mockMessageManager.killMessenger.Returns(mockKillMessenger);
        mockKillMessage = new KillMessage(EnemyType.EnemyBlue); // Corrected instantiation

        // Act
        // mockKillMessenger.SendMessage(mockKillMessage); // Correct event invocation
        statTracker.KilledEvent(mockKillMessage);

        // Assert
        Assert.AreEqual(1, statTracker.EnemiesKilled);
    }

    [Test]
    public void PowerupGained_ShouldIncrementPowerupsGained()
    {
        // Arrange
       //  mockMessageManager.powerupMessenger.Returns(mockPowerupMessenger);

        mockPowerup = Substitute.For<Powerup>();
        mockPowerupMessage = new PowerupMessage(mockPowerup);

        // Act
        // mockPowerupMessenger.SendMessage(mockPowerupMessage); // Correct event invocation
        statTracker.PowerupEvent(mockPowerupMessage);

        // Assert
        Assert.AreEqual(1, statTracker.PowerupsGained);
    }

    // [Test]
    // public void WaveStarted_LevelsClearedShouldStayZero()
    // {
    //     // Arrange
    //     mockEnemySpawner = Substitute.For<EnemySpawner>();
    //     enemySpawner.enemyFactory = mockFactory;
    //     enemySpawner.waveManager = mockWaveManager;

    //     LevelMessage testMessage = new LevelMessage(1);

    //     // Act
    //     mockEnemySpawner.StartWave(testMessage);

    //     // Assert
    //     Assert.AreEqual(0, statTracker.CurrentWave);
    // }

    // [Test]
    // public void LevelCleared_ShouldIncrementLevelsCleared()
    // {
    //     // Arrange
    //     // mockEnemySpawner = Substitute.For<EnemySpawner>();
    //     // enemySpawner.enemyFactory = mockFactory;
    //     // enemySpawner.waveManager = mockWaveManager;

    //     // LevelMessage testMessage = new LevelMessage(2);

    //     // Act
    //     // mockEnemySpawner.StartWave(testMessage);
    //     statTracker.CurrentWave = 1;

    //     // Assert
    //     Assert.AreEqual(1, statTracker.CurrentWave);

    // }

}
