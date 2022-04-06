using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TransitionStage : State
{
    public TransitionStage(GameManager gameManager, StateMachine stateMachine) : base(gameManager, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        this.isAutoTransition = true;
        this.autoTransitionTime = 2f;
        GameManager.I.playerGo.GetComponent<Animator>().SetTrigger("Run");
        
        GameManager.I.player.FullyHeal();
        UiManager.I.TogglePlayerHealthBar(true);

        BattleManager.I.SetupBattle();
        //Debug.Log("Transitioning from " + previousState.ToString());
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
        GameManager.I.playerGo.GetComponent<Animator>().SetTrigger("Idle");
        UiManager.I.ToggleEnemyHealthBar(true);
    }
    
    public override void ChangeState()
    {
        base.ChangeState();
        if (GameManager.I.player.CurrentStats.currentHealth > 0)
        {
            stateMachine.ChangeState(gameManager.battleState);
        }
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

