using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public bool isPlayer;
    public Slider slider;
    public TextMeshProUGUI healthText;
    
    private void Update()
    {
        if (isPlayer)
        {
            slider.maxValue = GameManager.I.player.CurrentStats.maxHealth;
            slider.value = GameManager.I.player.CurrentStats.currentHealth;
            healthText.text = GameManager.I.player.CurrentStats.currentHealth + "/" + GameManager.I.player.CurrentStats.maxHealth;
        }
        else
        {
            slider.maxValue = BattleManager.I.currentEnemy.BattleStats.maxHealth;
            slider.value = BattleManager.I.currentEnemy.BattleStats.currentHealth;
            healthText.text = BattleManager.I.currentEnemy.BattleStats.currentHealth + "/" + BattleManager.I.currentEnemy.BattleStats.maxHealth;
        }
    }
}
