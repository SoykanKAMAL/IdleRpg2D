using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerRpgStats", menuName = "RpgStats")]
public class RpgStats : ScriptableObject
{
    public int CurrentPoints;
    // Increases attack damage
    public int Strength;
    // Increases armor
    public int Dexterity;
    // Increases spell damage
    public int Intelligence;
    // Increases health
    public int Vitality;
    // Reduces spell cooldown
    public int Wisdom;
    // Increases attack speed
    public int Agility;
    // Increases gold earned
    public int Charisma;
    
}
