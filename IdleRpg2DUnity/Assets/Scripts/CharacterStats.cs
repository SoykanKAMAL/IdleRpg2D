using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterStats : ScriptableObject
{
    public float maxHealth;
    public float armor;
    public float attackDamage;
    public float attackSpeed;
    public float spellDamage;
    public float spellSpeed;
}
