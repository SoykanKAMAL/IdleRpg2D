using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EquipmentEffect
{
    public enum EffectType
    {
        IncreaseHealth,
        IncreaseArmor,
        IncreaseAttackDamage,
        IncreaseAttackSpeed,
        IncreaseSpellDamage,
        IncreaseSpellSpeed
    }
    public EffectType effectType;
    public float effectValue;
}


public abstract class Equipment : Mergeable
{
    public new string name;
    public List<EquipmentEffect> Effects = new List<EquipmentEffect>();
    
    
}
