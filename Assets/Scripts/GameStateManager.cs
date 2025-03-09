using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }

    private IGameState currentState;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SetState(new HomeScreenState());
    }

    public void SetState(IGameState newState)
    {
        if (currentState != null)
            currentState.Exit();

        currentState = newState;
        currentState.Enter();
    }

    private void Update()
    {
        if (currentState != null)
            currentState.Update();
    }
}
