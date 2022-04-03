using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleState : State
{
    public static Action<Attacker> OnBattleEnd;
    public BattleState(GameManager gameManager, StateMachine stateMachine) : base(gameManager, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        #region Subscribe To Events

        EnemyManager.OnPlayerWin += OnPlayerWin;

        #endregion

        #region StartFight

        EnemyManager.I.playerAttacker.StartAttacking();
        EnemyManager.I.enemyAttacker.StartAttacking();

        #endregion
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

        #region Unsubscribe From Events

        EnemyManager.OnPlayerWin -= OnPlayerWin;

        #endregion
    }
    
    private void OnPlayerWin()
    {
        stateMachine.ChangeState(gameManager.transitionState);
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

