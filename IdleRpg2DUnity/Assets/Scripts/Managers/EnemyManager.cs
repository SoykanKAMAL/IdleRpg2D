using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    [SerializeField]private List<Enemy> SpawnableEnemies = new List<Enemy>();
    [SerializeField]private List<string> Prefixes = new List<string>();
    [SerializeField]private List<string> Suffixes = new List<string>();
    
    public Enemy GenerateRandomEnemy()
    {
        return SpawnableEnemies[Random.Range(0, SpawnableEnemies.Count)];
    }
    
    public string GetPrefix()
    {
        return Prefixes[Random.Range(0, Prefixes.Count)];
    }
    
    public string GetSuffix()
    {
        return Suffixes[Random.Range(0, Suffixes.Count)];
    }
}
