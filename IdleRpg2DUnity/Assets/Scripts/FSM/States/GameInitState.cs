using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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
        GameManager.I.playerGo.GetComponent<Animator>().SetTrigger("Run");
        GameManager.I.playerGo.transform.DOMoveX(-2.5f, 1f);
        Camera.main.transform.DOMoveX(0, 1f);
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
