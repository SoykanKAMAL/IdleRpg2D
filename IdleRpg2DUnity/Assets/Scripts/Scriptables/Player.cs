using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GenericPlayer", menuName = "Characters/Player")]
public class Player : CharacterStats
{
    public int level;
    public float experience;
    
    public GameObject prefab;
    public CharacterStats CurrentStats { get; private set; }
    public RpgStats rpgStats;
    
    [Header("Equipment Slots")] 
    private List<Equipment> EquippedEquipments = new List<Equipment>();
    public Weapon weapon;
    //public Armor armor;
    //public Helmet helmet;
    //public Shield shield;
    //public Accessory accessory;

    private void OnEnable()
    {
        InitStats();
    }

    private void InitStats()
    {
        CurrentStats = ScriptableObject.CreateInstance<CharacterStats>();
        CurrentStats.name = this.name;
        UpdateEquippedItems();
        UpdateStats();
    }

    private void UpdateEquippedItems()
    {
        EquippedEquipments.Clear();
        if(weapon != null) EquippedEquipments.Add(weapon);
        //if(armor != null) EquippedEquipments.Add(armor);
        //if(helmet != null) EquippedEquipments.Add(helmet);
        //if(shield != null) EquippedEquipments.Add(shield);
        //if(accessory != null) EquippedEquipments.Add(accessory);
    }

    public void UpdateStats()
    {
        CurrentStats.maxHealth = (int)((this.maxHealth * Mathf.Pow(1.1f, rpgStats.Vitality)) + (CalculateBonus(EquipmentEffect.EffectType.IncreaseHealth) * CurrentStats.maxHealth));
        CurrentStats.currentHealth = CurrentStats.maxHealth;
        CurrentStats.armor = (int)((this.armor * Mathf.Pow(1.1f, rpgStats.Dexterity)) + (CalculateBonus(EquipmentEffect.EffectType.IncreaseArmor) * CurrentStats.armor));
        CurrentStats.attackDamage = (int)((this.attackDamage * Mathf.Pow(1.1f, rpgStats.Strength)) + (CalculateBonus(EquipmentEffect.EffectType.IncreaseAttackDamage) * CurrentStats.attackDamage));
        CurrentStats.attackSpeed = (this.attackSpeed * Mathf.Pow(0.9f, rpgStats.Agility)) * (1 - CalculateBonus(EquipmentEffect.EffectType.IncreaseAttackSpeed));
        CurrentStats.spellDamage = (int)((this.spellDamage * Mathf.Pow(1.1f, rpgStats.Intelligence)) + (CalculateBonus(EquipmentEffect.EffectType.IncreaseSpellDamage) * CurrentStats.spellDamage));
        CurrentStats.spellSpeed = (this.spellSpeed * Mathf.Pow(0.9f, rpgStats.Wisdom)) * (1 - CalculateBonus(EquipmentEffect.EffectType.IncreaseSpellSpeed));
    }

    private float CalculateBonus(EquipmentEffect.EffectType desiredEffect)
    {
        float bonus = 0;
        foreach (var cEquipment in EquippedEquipments)
        {
            foreach (var cEffect in cEquipment.Effects)
            {
                if(cEffect.effectType == desiredEffect) bonus += cEffect.effectValue;
            }
        }
        return bonus;
    }
    
    public void Heal(int amount)
    {
        CurrentStats.currentHealth += amount;
        if(CurrentStats.currentHealth > CurrentStats.maxHealth) CurrentStats.currentHealth = CurrentStats.maxHealth;
    }
    
}
