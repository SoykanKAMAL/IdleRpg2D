using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GenericEnemy", menuName = "Characters/Enemy")]
public class Enemy : CharacterStats
{
    public GameObject prefab;
    
    public RandomNameGenerator nameGenerator;
    public CharacterStats BattleStats { get; private set; }

    private void OnEnable()
    {
        InitStats();
    }

    public void InitStats()
    {
        BattleStats = ScriptableObject.CreateInstance<CharacterStats>();
        AssignRandomName();
        UpdateStats( Mathf.Pow(GameManager.I.DifficultyIncreasePerLevelAsPercentage, (StageManager.I.currentStage - 1) * 10 + (StageManager.I.currentSubStage - 1)));
    }
    
    private void UpdateStats(float multiplier)
    {
        Debug.Log("Updating stats for " + name + " with multiplier " + multiplier);
        BattleStats.maxHealth = (int) (this.maxHealth * multiplier);
        BattleStats.currentHealth = BattleStats.maxHealth;
        BattleStats.armor = (int) (this.armor * multiplier);
        BattleStats.attackDamage = (int) (this.attackDamage * multiplier);
        BattleStats.attackSpeed = this.attackSpeed;
        BattleStats.spellDamage = (int) (this.spellDamage * multiplier);
        BattleStats.spellSpeed = this.spellSpeed;
    }
    
    // Assign random name
    private void AssignRandomName()
    {
        BattleStats.name = nameGenerator.GeneratePrefix() + " " + this.name + " " + nameGenerator.GenerateSuffix();
    }
}
