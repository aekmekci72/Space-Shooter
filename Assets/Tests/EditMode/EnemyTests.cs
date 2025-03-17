// // Juna Lee
// // Test suite for verifying core behaviors of the spawning and destroying enemies.
// // I chose these three tests because they cover the key functions of enemies in the gameplay loop: spawning, destruction, and wave progression.
// // To prevent a brittle test suite, I used NSubstitute to mock dependencies like the factory and wave manager so I could focus on the EnemySpawner and Enemy classes.


// using NUnit.Framework;
// using UnityEngine;
// using UnityEngine.TestTools;
// using System.Collections;
// using System.Collections.Generic;
// using NSubstitute;

// public class EnemyTests
// {
//     private Enemy enemy;

//     private EnemySpawner enemySpawner;
//     private EnemyFactory mockFactory;
//     private WaveManager mockWaveManager;

//     [SetUp]
//     public void Setup()
//     {
//         GameObject gameObject = new GameObject();
//         enemySpawner = gameObject.AddComponent<EnemySpawner>();

//         mockFactory = Substitute.For<EnemyFactory>();
//         mockWaveManager = Substitute.For<WaveManager>();
//         mockEnemyRedPrefab = new GameObject("EnemyRed");

//         // Assign mock dependencies to spawner
//         enemySpawner.enemyFactory = mockFactory;
//         enemySpawner.waveManager = mockWaveManager;
//         enemyFactory.eRedPrefab = mockEnemyRedPrefab;
//     }

//     [TearDown]
//     public void Teardown()
//     {
//         Object.DestroyImmediate(enemySpawner.gameObject);
//     }

//     [Test]
//     public void StartWave_ShouldTriggerEnemySpawning()
//     {
//         // Arrange
//         LevelMessage testMessage = new LevelMessage(1);

//         // Act
//         enemySpawner.StartWave(testMessage);

//         // Assert
//         mockFactory.Received().CreateEnemy(Arg.Any<EnemyType>(), Arg.Any<Vector3>());
//     }

//     [Test]
//     public void EnemyDies_SendsKillMessage()
//     {
//         // Arrange
//         var killMessage = new KillMessage(EnemyType.EnemyBlue);
//         enemy.enemyType = EnemyType.EnemyBlue;

//         // Act
//         enemy.Die();

//         // Assert
//         mockMessageManager.killMessenger.Received(1).SendMessage(killMessage);
//     }

//     [Test]
//     public void CreateEnemy_CreatesEnemyRed()
//     {
//         // Arrange
//         Vector3 spawnPosition = new Vector3(0, 0, 0);
//         EnemyType enemyType = EnemyType.EnemyRed;

//         // Act
//         Enemy enemy = enemyFactory.CreateEnemy(enemyType, spawnPosition);

//         // Assert
//         Assert.That(enemy, Is.InstanceOf<EnemyRed>());
//         Assert.AreEqual(spawnPosition, enemy.transform.position);
//     }
// }
