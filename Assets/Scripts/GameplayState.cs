using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameplayState : IGameState
{
    public void Enter()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void Update()
    {
        if (PlayerIsDead())
        {
            GameStateManager.Instance.SetState(new DeathScreenState());
        }
    }

    public void Exit() { }

    private bool PlayerIsDead()
    {
        return false;
    }
}

