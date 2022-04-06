using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class BattleManager : Singleton<BattleManager>
{
    [SerializeField]private List<Enemy> SpawnableEnemies = new List<Enemy>();

    public GameObject enemyGO { get; private set; }
    public Enemy currentEnemy {get; private set;}
    public Attacker enemyAttacker { get; private set; }
    public Attacker playerAttacker {get; private set;}

    

    public Enemy GenerateRandomEnemy()
    {
        return SpawnableEnemies[Random.Range(0, SpawnableEnemies.Count)];
    }

    public void SetupBattle()
    {
        Debug.Log("Setting up battle");
        
        #region Create Random Enemy Scriptable Object

        currentEnemy = BattleManager.I.GenerateRandomEnemy();
        //currentEnemy = CharacterStats.RandomName(currentEnemy, EnemyManager.I.GetPrefix(), EnemyManager.I.GetSuffix());

        #endregion
    
        #region Instantiate Enemy and attach Components

        enemyGO = GameObject.Instantiate(currentEnemy.prefab, new Vector3(10f, 0, 0), Quaternion.identity);
        enemyGO.transform.DOMoveX(2.5f, 2.5f);
        enemyAttacker = enemyGO.AddComponent<Attacker>();

        #endregion

        #region Find Player and attach Components

        if(playerAttacker == null)
        {
            playerAttacker = GameManager.I.playerGo.AddComponent<Attacker>();
        }

        #endregion
        
        currentEnemy.InitStats();
        enemyAttacker.Setup(currentEnemy.BattleStats, playerAttacker);
        playerAttacker.Setup(GameManager.I.player.CurrentStats, enemyAttacker);
    }

    private void OnEnable()
    {
        BattleState.OnBattleEnd += OnBattleEnd;
    }
    
    private void OnDisable()
    {
        BattleState.OnBattleEnd -= OnBattleEnd;
    }
    
    void OnBattleEnd(Attacker winner)
    {
        if (winner == playerAttacker)
        {
            Debug.Log("Battle Ended, player won: " + winner.name);
            StageManager.OnPlayerWin?.Invoke();
        }
        else
        {
            Debug.Log("Battle Ended, player lost: " + winner.name);
            StageManager.OnPlayerLose?.Invoke();
        }
    }
}
