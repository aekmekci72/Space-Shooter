using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScreenState : IGameState
{
    public void Enter()
    {
        SceneManager.LoadScene("HomeScreen");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameStateManager.Instance.SetState(new GameplayState());
        }
    }

    public void Exit() { }
}
