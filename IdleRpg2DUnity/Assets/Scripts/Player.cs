using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GenericPlayer", menuName = "Characters/Player")]
public class Player : CharacterStats
{
    public CharacterStats baseStats;
    public RpgStats rpgStats;

    public void InitStats()
    {
        this.name = baseStats.name;
        UpdateStats();
    }
    public void UpdateStats()
    {
        this.maxHealth = baseStats.maxHealth + rpgStats.Vitality * 2;
        this.currentHealth = this.maxHealth;
        this.armor = baseStats.armor + rpgStats.Dexterity * 2;
        this.attackDamage = baseStats.attackDamage + rpgStats.Strength * 2;
        this.attackSpeed = (baseStats.attackSpeed * Mathf.Pow(0.9f, rpgStats.Agility));
        this.spellDamage = baseStats.spellDamage + rpgStats.Intelligence * 2;
        this.spellSpeed = (baseStats.spellSpeed * Mathf.Pow(0.9f, rpgStats.Wisdom));
    }
}
