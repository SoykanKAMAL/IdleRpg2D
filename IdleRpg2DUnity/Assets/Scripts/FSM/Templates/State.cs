using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected GameManager gameManager;
    protected StateMachine stateMachine;

    public static Action OnStateChanged;
    
    public bool isAutoTransition = false;
    public float autoTransitionTime = 0;
    private float autoTransitionTimer = 0;

    protected State(GameManager gameManager, StateMachine stateMachine)
    {
        this.gameManager = gameManager;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter()
    {
        DisplayOnUI(UiManager.Alignment.Left);
        
        //Debug
        Debug.Log("------------------");
        Debug.Log("Entering state: " + this.GetType().Name);
        
        // Event Subscriptions
        OnStateChanged += ChangeState;
    }

    public virtual void HandleInput()
    {

    }
    
    public virtual void ChangeState()
    {
        
    }
    
    public virtual void LogicUpdate()
    {
        if(isAutoTransition)
        {
            autoTransitionTimer += Time.deltaTime;
            if(autoTransitionTimer >= autoTransitionTime)
            {
                autoTransitionTimer = 0;
                ChangeState();
            }
        }
    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void Exit()
    {
        //Debug
        Debug.Log("Exiting state: " + this.GetType().Name);
        
        // Event Unsubscriptions
        OnStateChanged -= ChangeState;
    }

    protected void DisplayOnUI(UiManager.Alignment alignment)
    {
        UiManager.I.Display(this, alignment);
    }
    
    // ToString override
    public override string ToString()
    {
        return this.GetType().Name;
    }
}