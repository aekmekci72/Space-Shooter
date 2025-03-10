using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;
using System.Collections.Generic;
using NSubstitute;

public class HealthTests{
    private 
    private PlayerController mockPlayer;

    [SetUp]
    public void Setup()
    {
        GameObject gameObject = new GameObject();
        powerupHandler = gameObject.AddComponent<PowerupHandler>();

        mockPlayer = Substitute.For<PlayerController>();

        powerupHandler.GetComponent<PlayerController>().Returns(mockPlayer);
    }
}