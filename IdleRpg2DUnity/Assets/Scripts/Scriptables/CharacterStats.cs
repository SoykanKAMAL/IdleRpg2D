using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStats", menuName = "CharacterStats")]
public class CharacterStats : ScriptableObject
{
    public new string name;
    public int maxHealth;
    public int currentHealth;
    public int armor;
    public int attackDamage;
    public float attackSpeed;
    public int spellDamage;
    public float spellSpeed;
    
    // Operator* Overload
    public static CharacterStats operator *(CharacterStats currentStats, float multiplier)
    {
        CharacterStats result = ScriptableObject.CreateInstance<CharacterStats>();
        result.name = currentStats.name;
        result.maxHealth = (int) (currentStats.maxHealth * multiplier);
        result.currentHealth = currentStats.currentHealth;
        result.armor = (int) (currentStats.armor * multiplier);
        result.attackDamage = (int) (currentStats.attackDamage * multiplier);
        result.attackSpeed = currentStats.attackSpeed;
        result.spellDamage = (int) (currentStats.spellDamage * multiplier);
        result.spellSpeed = currentStats.spellSpeed;
        return result;
    }
    
    // Assign random name
    public static CharacterStats RandomName(CharacterStats currentStats, string prefix, string suffix)
    {
        currentStats.name = prefix + " " + currentStats.name + " " + suffix;
        return currentStats;
    }
    
    // Return a copy of the stats
    public CharacterStats Copy()
    {
        CharacterStats result = ScriptableObject.CreateInstance<CharacterStats>();
        result.name = name;
        result.maxHealth = maxHealth;
        result.currentHealth = currentHealth;
        result.armor = armor;
        result.attackDamage = attackDamage;
        result.attackSpeed = attackSpeed;
        result.spellDamage = spellDamage;
        result.spellSpeed = spellSpeed;
        return result;
    }
    
}
