// Juna Lee
// Test suite for verifying core behaviors of the spawning and destroying enemies.
// This suite ensures that enemies are spawned correctly using the factory pattern and validates key interactions such as enemy destruction and wave progression.

using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;
using System.Collections.Generic;
using NSubstitute;

public class EnemyTests
{
    private Enemy enemy;

    private Enemy enemy1;
    private Enemy enemy2;
    private Enemy enemy3;
    
    private EnemySpawner enemySpawner;
    private EnemyFactory mockFactory;
    private WaveManager mockWaveManager;

    [SetUp]
    public void Setup()
    {
        GameObject gameObject = new GameObject();
        enemySpawner = gameObject.AddComponent<EnemySpawner>();

        mockFactory = Substitute.For<EnemyFactory>();
        mockWaveManager = Substitute.For<WaveManager>();

        // Assign mock dependencies to spawner
        enemySpawner.enemyFactory = mockFactory;
        enemySpawner.waveManager = mockWaveManager;
    }

    [TearDown]
    public void Teardown()
    {
        Object.DestroyImmediate(enemySpawner.gameObject);
    }

    [Test]
    public void StartWave_ShouldTriggerEnemySpawning()
    {
        // Arrange
        LevelMessage testMessage = new LevelMessage(1);

        // Act
        enemySpawner.StartWave(testMessage);

        // Assert
        mockFactory.Received().CreateEnemy(Arg.Any<EnemyType>(), Arg.Any<Vector3>());
    }

    [Test]
    public void EnemyDies_SendsKillMessage()
    {
        // Arrange
        var killMessage = new KillMessage(EnemyType.EnemyBlue);
        enemy.enemyType = EnemyType.EnemyBlue;

        // Act
        enemy.Die();

        // Assert
        mockMessageManager.killMessenger.Received(1).SendMessage(killMessage);
    }

    [Test]
    public void EndWave_ShouldNotifyWaveManager()
    {
        // Act
        enemySpawner.waveManager.EndWave();

        // Assert
        mockWaveManager.Received(1).EndWave();
    }
}
