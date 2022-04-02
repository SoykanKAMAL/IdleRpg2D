using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    [SerializeField]private List<Enemy> SpawnableEnemies = new List<Enemy>();
    
    public Enemy GenerateRandomEnemy()
    {
        return SpawnableEnemies[Random.Range(0, SpawnableEnemies.Count)];
    }
}
