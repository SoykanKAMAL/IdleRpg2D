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
    public Weapon weaponEquipped;
    public Armor armorEquipped;
    public Helmet helmetEquipped;
    public Shield shieldEquipped;
    public Accessory accessoryEquipped;

    private void OnEnable()
    {
        InitStats();
        weaponEquipped = null;
        armorEquipped = null;
        helmetEquipped = null;
        shieldEquipped = null;
        accessoryEquipped = null;
        UpdateEquippedItems();
    }

    private void InitStats()
    {
        CurrentStats = ScriptableObject.CreateInstance<CharacterStats>();
        CurrentStats.name = this.name;
        UpdateStats();
    }

    private void UpdateEquippedItems()
    {
        EquippedEquipments.Clear();
        if(weaponEquipped != null) EquippedEquipments.Add(weaponEquipped);
        if(armorEquipped != null) EquippedEquipments.Add(armorEquipped);
        if(helmetEquipped != null) EquippedEquipments.Add(helmetEquipped);
        if(shieldEquipped != null) EquippedEquipments.Add(shieldEquipped);
        if(accessoryEquipped != null) EquippedEquipments.Add(accessoryEquipped);
    }

    public void UpdateStats()
    {
        UpdateEquippedItems();
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
    
    public void FullyHeal()
    {
        CurrentStats.currentHealth = CurrentStats.maxHealth;
    }
}
