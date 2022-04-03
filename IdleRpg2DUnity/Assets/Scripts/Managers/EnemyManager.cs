using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : Singleton<EnemyManager>
{
    [SerializeField]private List<Enemy> SpawnableEnemies = new List<Enemy>();
    [SerializeField]private List<string> Prefixes = new List<string>();
    [SerializeField]private List<string> Suffixes = new List<string>();

    public GameObject enemyGO;
    public Attacker enemyAttacker;
    public Attacker playerAttacker;

    public static Action OnPlayerWin;
    public static Action OnPlayerLose;

    public Enemy GenerateRandomEnemy()
    {
        return SpawnableEnemies[Random.Range(0, SpawnableEnemies.Count)];
    }

    public void SetupBattle()
    {
        Debug.Log("Setting up battle");
        
        #region Create Random Enemy Scriptable Object

        Enemy currentEnemy = EnemyManager.I.GenerateRandomEnemy();
        //currentEnemy = CharacterStats.RandomName(currentEnemy, EnemyManager.I.GetPrefix(), EnemyManager.I.GetSuffix());

        #endregion
    
        #region Instantiate Enemy and attach Components

        enemyGO = GameObject.Instantiate(currentEnemy.prefab);
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
            OnPlayerWin?.Invoke();
        }
        else
        {
            Debug.Log("Battle Ended, player lost: " + winner.name);
            OnPlayerLose?.Invoke();
        }
    }
}
