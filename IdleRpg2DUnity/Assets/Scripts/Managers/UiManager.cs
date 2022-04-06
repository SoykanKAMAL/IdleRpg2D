using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : Singleton<UiManager>
{
    public float GlobalAnimationTime = 0.5f;
    public Button endStateButton;
    public Button startGameButton;
    public GameObject playerStatsPanel;
    public GameObject enemyStatsPanel;
    public TextMeshProUGUI stageNoText;
    public GameObject mainInfoPanel;
    public static Action<float> OnNavigationButtonClicked;
    public GameObject playerHealthBar;
    public GameObject enemyHealthBar;
    public GameObject rpgStatsUi;
    private void OnEnable()
    {
        endStateButton.onClick.AddListener(() => { State.OnStateChanged?.Invoke(); });
        startGameButton.onClick.AddListener(() => { State.OnStateChanged?.Invoke(); });
        OnNavigationButtonClicked += OnNavigationButtonClickedHandler;
    }

    private void OnDisable()
    {
        endStateButton.onClick.RemoveAllListeners();
        startGameButton.onClick.RemoveAllListeners();
        OnNavigationButtonClicked -= OnNavigationButtonClickedHandler;
    }

    private void OnNavigationButtonClickedHandler(float endVal)
    {
        mainInfoPanel.transform.DOScaleY(0, GlobalAnimationTime/2f).SetEase(Ease.Linear).OnComplete(() =>
        {
            mainInfoPanel.transform.DOScaleY(endVal, GlobalAnimationTime).SetEase(Ease.Linear);
        });
    }

    private void Start()
    {
        UpdateRpgStats();
    }

    private void Update()
    {
        ShowPlayerStats();
        //ShowEnemyStats();
        UpdateStageNoUi();
    }

    public void TogglePlayerHealthBar(bool toggle)
    {
        playerHealthBar.transform.DOMoveY(2500, 1f).From().SetEase(Ease.Linear);
        playerHealthBar.SetActive(toggle);
    }
    
    public void ToggleEnemyHealthBar(bool toggle)
    {
        enemyHealthBar.transform.DOMoveY(2500, 1f).From().SetEase(Ease.Linear);
        enemyHealthBar.SetActive(toggle);
    }
    
    private void ShowPlayerStats()
    {
        playerStatsPanel.SetActive(true);
        playerStatsPanel.transform.Find("Title").GetComponent<TextMeshProUGUI>().text =
            "---" + GameManager.I.player.CurrentStats.name.ToString() + "---";
        playerStatsPanel.transform.Find("MaxHealth").GetComponent<TextMeshProUGUI>().text =
            "MaxHealth: " + GameManager.I.player.CurrentStats.maxHealth.ToString();
        playerStatsPanel.transform.Find("Armor").GetComponent<TextMeshProUGUI>().text =
            "Armor: " + GameManager.I.player.CurrentStats.armor.ToString();
        playerStatsPanel.transform.Find("AttackDamage").GetComponent<TextMeshProUGUI>().text =
            "AttackDamage: " + GameManager.I.player.CurrentStats.attackDamage.ToString();
        playerStatsPanel.transform.Find("AttackSpeed").GetComponent<TextMeshProUGUI>().text =
            "AttackSpeed: " + GameManager.I.player.CurrentStats.attackSpeed.ToString("F2");
        playerStatsPanel.transform.Find("SpellDamage").GetComponent<TextMeshProUGUI>().text =
            "SpellDamage: " + GameManager.I.player.CurrentStats.spellDamage.ToString();
        playerStatsPanel.transform.Find("SpellSpeed").GetComponent<TextMeshProUGUI>().text =
            "SpellSpeed: " + GameManager.I.player.CurrentStats.spellSpeed.ToString("F2");
    }
    
    private void ShowEnemyStats()
    {
        if(BattleManager.I.enemyAttacker == null) return;
        enemyStatsPanel.SetActive(true);
        enemyStatsPanel.transform.Find("Title").GetComponent<TextMeshProUGUI>().text =
            "---" + BattleManager.I.enemyAttacker.stats.name.ToString() + "---";
        enemyStatsPanel.transform.Find("MaxHealth").GetComponent<TextMeshProUGUI>().text =
            "MaxHealth: " + BattleManager.I.enemyAttacker.stats.maxHealth.ToString();
        enemyStatsPanel.transform.Find("CurrentHealth").GetComponent<TextMeshProUGUI>().text =
            "CurrentHealth: " + BattleManager.I.enemyAttacker.stats.currentHealth.ToString();
        enemyStatsPanel.transform.Find("Armor").GetComponent<TextMeshProUGUI>().text =
            "Armor: " + BattleManager.I.enemyAttacker.stats.armor.ToString();
        enemyStatsPanel.transform.Find("AttackDamage").GetComponent<TextMeshProUGUI>().text =
            "AttackDamage: " + BattleManager.I.enemyAttacker.stats.attackDamage.ToString();
        // Show only two decimal places
        enemyStatsPanel.transform.Find("AttackSpeed").GetComponent<TextMeshProUGUI>().text =
            "AttackSpeed: " + BattleManager.I.enemyAttacker.stats.attackSpeed.ToString("F2");
        enemyStatsPanel.transform.Find("SpellDamage").GetComponent<TextMeshProUGUI>().text =
            "SpellDamage: " + BattleManager.I.enemyAttacker.stats.spellDamage.ToString();
        enemyStatsPanel.transform.Find("SpellSpeed").GetComponent<TextMeshProUGUI>().text =
            "SpellSpeed: " + BattleManager.I.enemyAttacker.stats.spellSpeed.ToString("F2");
    }

    private void UpdateStageNoUi()
    {
        stageNoText.text = "Stage: " + StageManager.I.currentStage.ToString() + "-" + StageManager.I.currentSubStage.ToString();
    }

    public void UpdateRpgStats()
    {
        rpgStatsUi.transform.Find("Points").GetComponent<TextMeshProUGUI>().text =
            "Points: " + GameManager.I.player.rpgStats.CurrentPoints.ToString();
        rpgStatsUi.transform.Find("STR/Text (TMP)").GetComponent<TextMeshProUGUI>().text =
            "STR: " + GameManager.I.player.rpgStats.Strength.ToString();
        rpgStatsUi.transform.Find("DEX/Text (TMP)").GetComponent<TextMeshProUGUI>().text =
            "DEX: " + GameManager.I.player.rpgStats.Dexterity.ToString();
        rpgStatsUi.transform.Find("INT/Text (TMP)").GetComponent<TextMeshProUGUI>().text =
            "INT: " + GameManager.I.player.rpgStats.Intelligence.ToString();
        rpgStatsUi.transform.Find("VIT/Text (TMP)").GetComponent<TextMeshProUGUI>().text =
            "VIT: " + GameManager.I.player.rpgStats.Vitality.ToString();
        rpgStatsUi.transform.Find("WIS/Text (TMP)").GetComponent<TextMeshProUGUI>().text =
            "WIS: " + GameManager.I.player.rpgStats.Wisdom.ToString();
        rpgStatsUi.transform.Find("AGI/Text (TMP)").GetComponent<TextMeshProUGUI>().text =
            "AGI: " + GameManager.I.player.rpgStats.Agility.ToString();
    }
}