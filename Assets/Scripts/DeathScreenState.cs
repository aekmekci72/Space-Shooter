using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenState : IGameState
{
    public void Enter()
    {
        SceneManager.LoadScene("DeathScreen");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameStateManager.Instance.SetState(new GameplayState());
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            GameStateManager.Instance.SetState(new HomeScreenState());
        }
    }

    public void Exit() { }
}