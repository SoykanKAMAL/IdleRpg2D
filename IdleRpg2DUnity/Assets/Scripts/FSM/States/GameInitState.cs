using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitState : State
{
    public GameInitState(GameManager gameManager, StateMachine stateMachine) : base(gameManager, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void ChangeState()
    {
        base.ChangeState();
        stateMachine.ChangeState(gameManager.transitionState);
    }
    
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return base.ToString();
    }
}
