using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
