using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleState : State
{
    private CharacterStats m_CurrentEnemyStats;
    public static Action<Attacker> OnBattleEnd;
    public BattleState(GameManager gameManager, StateMachine stateMachine) : base(gameManager, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        #region Subscribe To Events

        OnBattleEnd += BattleEnd;

        #endregion

        #region Create Random Enemy Scriptable Object

        Enemy currentEnemy = EnemyManager.I.GenerateRandomEnemy();
        // TODO: m_CurrentEnemyStats = (CharacterStats) currentEnemy * CurrentRoundNo * GameManager.I.Difficulty;
        m_CurrentEnemyStats = currentEnemy * 2f;
        m_CurrentEnemyStats = CharacterStats.RandomName(m_CurrentEnemyStats, EnemyManager.I.GetPrefix(), EnemyManager.I.GetSuffix());

        #endregion
        
        #region Instantiate Enemy and attach Components

        GameObject enemyGo = GameObject.Instantiate(currentEnemy.prefab);
        Attacker enemyAttacker = enemyGo.AddComponent<Attacker>();

        #endregion

        #region Find Player and attach Components

        GameObject playerGo = gameManager.playerGo;
        Attacker playerAttacker = playerGo.AddComponent<Attacker>();

        #endregion

        #region StartFight

        enemyAttacker.Setup(m_CurrentEnemyStats, playerAttacker);
        playerAttacker.Setup(gameManager.player, enemyAttacker);

        playerAttacker.StartAttacking();
        enemyAttacker.StartAttacking();

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

        OnBattleEnd -= BattleEnd;

        #endregion
    }

    private void BattleEnd(Attacker obj)
    {
        Debug.Log("Battle End, " + obj.name + " won");
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

