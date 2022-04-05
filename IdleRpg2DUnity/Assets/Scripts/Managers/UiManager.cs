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
    public GameObject playerStatsPanel;
    public GameObject enemyStatsPanel;
    public TextMeshProUGUI stageNoText;
    public GameObject mainInfoPanel;
    public static Action<float> OnNavigationButtonClicked;
    public GameObject playerHealthBar;
    public GameObject enemyHealthBar;
    private void OnEnable()
    {
        endStateButton.onClick.AddListener(() => { State.OnStateChanged?.Invoke(); });
        OnNavigationButtonClicked += OnNavigationButtonClickedHandler;
    }

    private void OnDisable()
    {
        endStateButton.onClick.RemoveAllListeners();
        OnNavigationButtonClicked -= OnNavigationButtonClickedHandler;
    }

    private void OnNavigationButtonClickedHandler(float endVal)
    {
        mainInfoPanel.transform.DOScaleY(0, GlobalAnimationTime/2f).SetEase(Ease.Linear).OnComplete(() =>
        {
            mainInfoPanel.transform.DOScaleY(endVal, GlobalAnimationTime).SetEase(Ease.Linear);
        });
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