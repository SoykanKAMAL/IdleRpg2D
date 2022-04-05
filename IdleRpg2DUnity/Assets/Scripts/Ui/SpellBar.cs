using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellBar : MonoBehaviour
{
    public bool isPlayer;
    public Slider slider;

    private void Update()
    {
        if (isPlayer)
        {
            slider.maxValue = GameManager.I.player.CurrentStats.spellSpeed;
            slider.value = GameManager.I.playerGo.GetComponent<Attacker>().spellTimer;
        }
        else
        {
            slider.maxValue = EnemyManager.I.currentEnemy.BattleStats.spellSpeed;
            slider.value = EnemyManager.I.enemyAttacker.spellTimer;
        }
    }
}
