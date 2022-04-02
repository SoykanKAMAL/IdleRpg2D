using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleState : State
{
    public BattleState(GameManager gameManager, StateMachine stateMachine) : base(gameManager, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        var currentEnemy = EnemyManager.I.GenerateRandomEnemy();
        Debug.Log(currentEnemy.name);
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void ChangeState()
    {
        base.ChangeState();
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

