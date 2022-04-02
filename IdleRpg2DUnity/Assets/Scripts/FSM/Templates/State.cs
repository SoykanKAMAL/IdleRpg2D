using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State 
{
    protected GameManager gameManager;
    protected StateMachine stateMachine;

    protected State(GameManager gameManager, StateMachine stateMachine)
    {
        this.gameManager = gameManager;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter()
    {
        DisplayOnUI(UiManager.Alignment.Left);
        
        //Debug
        Debug.Log("Entering state: " + this.GetType().Name);
        
        // Event Subscriptions
        UiManager.OnEndCurrentState += ChangeState;
    }

    public virtual void HandleInput()
    {

    }
    
    public virtual void ChangeState()
    {
        
    }
    
    public virtual void LogicUpdate()
    {
        
    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void Exit()
    {
        //Debug
        Debug.Log("Exiting state: " + this.GetType().Name);
        
        // Event Unsubscriptions
        UiManager.OnEndCurrentState -= ChangeState;
    }

    protected void DisplayOnUI(UiManager.Alignment alignment)
    {
        UiManager.I.Display(this, alignment);
    }
}