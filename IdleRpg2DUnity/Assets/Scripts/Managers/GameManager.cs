using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    GameInit,
    GameStart,
    
}
public class GameManager : Singleton<GameManager>
{
    public StateMachine gameManagerStateMachine;
    
    public GameInitState gameInitState;
    
    public BattleState battleState;

    public TransitionStage transitionState;

    public Player player;

    public GameObject playerGo;
    
    [Header("Game Settings")]
    public float DifficultyIncreasePerLevelAsPercentage = 0.1f;
    
    private void Start()
    {
        playerGo = Instantiate(player.prefab);
        gameManagerStateMachine = new StateMachine();

        gameInitState = new GameInitState(this, gameManagerStateMachine);
        battleState = new BattleState(this, gameManagerStateMachine);
        transitionState = new TransitionStage(this, gameManagerStateMachine);

        // Start the game
        gameManagerStateMachine.Initialize(gameInitState);
    }

    private void Update()
    {
        gameManagerStateMachine.CurrentState.HandleInput();

        gameManagerStateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        gameManagerStateMachine.CurrentState.PhysicsUpdate();
    }
}
