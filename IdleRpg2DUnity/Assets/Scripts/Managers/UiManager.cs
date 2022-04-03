using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : Singleton<UiManager>
{
    public enum Alignment
    {
        Left,
        Right
    }

    [SerializeField] private TextMeshProUGUI leftText = null;
    [SerializeField] private TextMeshProUGUI rightText = null;

    public Button endStateButton;
    public GameObject playerStatsPanel;
    public GameObject enemyStatsPanel;
    public TextMeshProUGUI stageNoText;

    public void Display(State enteredState, Alignment alignment)
    {
        var name = enteredState.ToString();

        if (alignment == Alignment.Left)
        {
            leftText.text = name;
        }
        else
        {
            rightText.text = name;
        }
    }

    private void OnEnable()
    {
        endStateButton.onClick.AddListener(() => { State.OnStateChanged?.Invoke(); });
    }

    private void OnDisable()
    {
        endStateButton.onClick.RemoveAllListeners();
    }

    private void Update()
    {
        ShowPlayerStats();
        ShowEnemyStats();
        UpdateStageNoUi();
    }

    private void ShowPlayerStats()
    {
        playerStatsPanel.SetActive(true);
        playerStatsPanel.transform.Find("Title").GetComponent<TextMeshProUGUI>().text =
            "---" + GameManager.I.player.CurrentStats.name.ToString() + "---";
        playerStatsPanel.transform.Find("MaxHealth").GetComponent<TextMeshProUGUI>().text =
            "MaxHealth: " + GameManager.I.player.CurrentStats.maxHealth.ToString();
        playerStatsPanel.transform.Find("CurrentHealth").GetComponent<TextMeshProUGUI>().text =
            "CurrentHealth: " + GameManager.I.player.CurrentStats.currentHealth.ToString();
        playerStatsPanel.transform.Find("Armor").GetComponent<TextMeshProUGUI>().text =
            "Armor: " + GameManager.I.player.CurrentStats.armor.ToString();
        playerStatsPanel.transform.Find("AttackDamage").GetComponent<TextMeshProUGUI>().text =
            "AttackDamage: " + GameManager.I.player.CurrentStats.attackDamage.ToString();
        playerStatsPanel.transform.Find("AttackSpeed").GetComponent<TextMeshProUGUI>().text =
            "AttackSpeed: " + GameManager.I.player.CurrentStats.attackSpeed.ToString();
        playerStatsPanel.transform.Find("SpellDamage").GetComponent<TextMeshProUGUI>().text =
            "SpellDamage: " + GameManager.I.player.CurrentStats.spellDamage.ToString();
        playerStatsPanel.transform.Find("SpellSpeed").GetComponent<TextMeshProUGUI>().text =
            "SpellSpeed: " + GameManager.I.player.CurrentStats.spellSpeed.ToString();
    }
    
    private void ShowEnemyStats()
    {
        if(EnemyManager.I.enemyAttacker == null) return;
        enemyStatsPanel.SetActive(true);
        enemyStatsPanel.transform.Find("Title").GetComponent<TextMeshProUGUI>().text =
            "---" + EnemyManager.I.enemyAttacker.stats.name.ToString() + "---";
        enemyStatsPanel.transform.Find("MaxHealth").GetComponent<TextMeshProUGUI>().text =
            "MaxHealth: " + EnemyManager.I.enemyAttacker.stats.maxHealth.ToString();
        enemyStatsPanel.transform.Find("CurrentHealth").GetComponent<TextMeshProUGUI>().text =
            "CurrentHealth: " + EnemyManager.I.enemyAttacker.stats.currentHealth.ToString();
        enemyStatsPanel.transform.Find("Armor").GetComponent<TextMeshProUGUI>().text =
            "Armor: " + EnemyManager.I.enemyAttacker.stats.armor.ToString();
        enemyStatsPanel.transform.Find("AttackDamage").GetComponent<TextMeshProUGUI>().text =
            "AttackDamage: " + EnemyManager.I.enemyAttacker.stats.attackDamage.ToString();
        enemyStatsPanel.transform.Find("AttackSpeed").GetComponent<TextMeshProUGUI>().text =
            "AttackSpeed: " + EnemyManager.I.enemyAttacker.stats.attackSpeed.ToString();
        enemyStatsPanel.transform.Find("SpellDamage").GetComponent<TextMeshProUGUI>().text =
            "SpellDamage: " + EnemyManager.I.enemyAttacker.stats.spellDamage.ToString();
        enemyStatsPanel.transform.Find("SpellSpeed").GetComponent<TextMeshProUGUI>().text =
            "SpellSpeed: " + EnemyManager.I.enemyAttacker.stats.spellSpeed.ToString();
    }

    private void UpdateStageNoUi()
    {
        stageNoText.text = "Stage: " + StageManager.I.currentStage.ToString() + "-" + StageManager.I.currentSubStage.ToString();
    }
}