using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GenericPlayer", menuName = "Characters/Player")]
public class Player : ScriptableObject
{
    public int level;
    public float experience;
    public CharacterStats baseStats;
    [HideInInspector]public CharacterStats currentStats;
    public RpgStats rpgStats;
    
    [Header("Equipment Slots")] 
    private List<Equipment> EquippedEquipments = new List<Equipment>();
    public Weapon weapon;
    //public Armor armor;
    //public Helmet helmet;
    //public Shield shield;
    //public Accessory accessory;
    

    public void InitStats()
    {
        currentStats = ScriptableObject.CreateInstance<CharacterStats>();
        currentStats.name = baseStats.name;
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
        currentStats.maxHealth = (int)((baseStats.maxHealth * Mathf.Pow(1.1f, rpgStats.Vitality)) + (CalculateBonus(EquipmentEffect.EffectType.IncreaseHealth) * currentStats.maxHealth));
        currentStats.currentHealth = currentStats.maxHealth;
        currentStats.armor = (int)((baseStats.armor * Mathf.Pow(1.1f, rpgStats.Dexterity)) + (CalculateBonus(EquipmentEffect.EffectType.IncreaseArmor) * currentStats.armor));
        currentStats.attackDamage = (int)((baseStats.attackDamage * Mathf.Pow(1.1f, rpgStats.Strength)) + (CalculateBonus(EquipmentEffect.EffectType.IncreaseAttackDamage) * currentStats.attackDamage));
        currentStats.attackSpeed = (baseStats.attackSpeed * Mathf.Pow(0.9f, rpgStats.Agility)) * (1 - CalculateBonus(EquipmentEffect.EffectType.IncreaseAttackSpeed));
        currentStats.spellDamage = (int)((baseStats.spellDamage * Mathf.Pow(1.1f, rpgStats.Intelligence)) + (CalculateBonus(EquipmentEffect.EffectType.IncreaseSpellDamage) * currentStats.spellDamage));
        currentStats.spellSpeed = (baseStats.spellSpeed * Mathf.Pow(0.9f, rpgStats.Wisdom)) * (1 - CalculateBonus(EquipmentEffect.EffectType.IncreaseSpellSpeed));
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
        Debug.Log("DesiredEffect: " + desiredEffect + " Bonus: " + bonus);
        return bonus;
    }
    
}
