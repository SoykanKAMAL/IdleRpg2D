using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpManager : Singleton<LevelUpManager>
{
    private Player player;
    private void Start()
    {
        player = GameManager.I.player;
    }

    public void IncreaseStrength()
    {
        if (player.rpgStats.CurrentPoints > 0)
        {
            player.rpgStats.Strength++;
            player.rpgStats.CurrentPoints--;
            player.UpdateStats();
            UiManager.I.UpdateRpgStats();
        }
    }
    
    public void IncreaseDexterity()
    {
        if (player.rpgStats.CurrentPoints > 0)
        {
            player.rpgStats.Dexterity++;
            player.rpgStats.CurrentPoints--;
            player.UpdateStats();
            UiManager.I.UpdateRpgStats();
        }
    }
    
    public void IncreaseIntelligence()
    {
        if (player.rpgStats.CurrentPoints > 0)
        {
            player.rpgStats.Intelligence++;
            player.rpgStats.CurrentPoints--;
            player.UpdateStats();
            UiManager.I.UpdateRpgStats();
        }
    }
    
    public void IncreaseVitality()
    {
        if (player.rpgStats.CurrentPoints > 0)
        {
            player.rpgStats.Vitality++;
            player.rpgStats.CurrentPoints--;
            player.UpdateStats();
            UiManager.I.UpdateRpgStats();
        }
    }
    
    public void IncreaseWisdom()
    {
        if (player.rpgStats.CurrentPoints > 0)
        {
            player.rpgStats.Wisdom++;
            player.rpgStats.CurrentPoints--;
            player.UpdateStats();
            UiManager.I.UpdateRpgStats();
        }
    }
    
    public void IncreaseAgility()
    {
        if (player.rpgStats.CurrentPoints > 0)
        {
            player.rpgStats.Agility++;
            player.rpgStats.CurrentPoints--;
            player.UpdateStats();
            UiManager.I.UpdateRpgStats();
        }
    }
}
