using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SampleTests
{
    private PlayerController player;
    [SetUp]
    public void Setup()
    {
        // Create a new instance of PlayerController(whatever class) to test
        player = new GameObject().AddComponent<PlayerController>();
    }
    [Test]
    public void SayHiWhenWorking()
    {
        // Arrange
        player.health = (float)1;
        // Act
        player.health-=(float)0.5;
        // Assert
        Assert.AreEqual("hello", "hello");
    }
}