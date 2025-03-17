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
    private PowerupMessenger mockPowerupMessenger;
    private KillMessenger mockKillMessenger;
    // private Messenger mockMessenger;
    private MessageManager mockMessageManager;
    private Powerup mockPowerup;

    [SetUp]
    public void Setup()
    {
        GameObject gameObject = new GameObject();
        statTracker = gameObject.AddComponent<StatTracker>();
        // mockMessenger = Substitute.For<Messenger>();
        mockMessageManager = Substitute.For<MessageManager>();

        statTracker.Start();
    }

    [Test]
    public void EnemyKilled_ShouldIncrementEnemiesKilled()
    {
        // Arrange
        mockKillMessenger = Substitute.For<KillMessenger>();
        var killMessage = new KillMessage(EnemyType.EnemyBlue);

        // Act
        statTracker.KilledEvent(killMessage);

        // Assert
        Assert.AreEqual(1, statTracker.EnemiesKilled);
    }

    [Test]
    public void PowerupGained_ShouldIncrementPowerupsGained()
    {
        // Arrange
        mockPowerupMessenger = Substitute.For<PowerupMessenger>();
        mockPowerup = Substitute.For<Powerup>();

        // Act
        statTracker.PowerupEvent(new PowerupMessage(mockPowerup));

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
