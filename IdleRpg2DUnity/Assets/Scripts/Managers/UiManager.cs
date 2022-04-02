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

    public static Action OnEndCurrentState;
    public Button endStateButton;
    public GameObject playerStatsPanel;

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
        endStateButton.onClick.AddListener(() => { OnEndCurrentState?.Invoke(); });
    }

    private void OnDisable()
    {
        endStateButton.onClick.RemoveAllListeners();
    }

    private void Update()
    {
        ShowPlayerStats();
    }

    private void ShowPlayerStats()
    {
        playerStatsPanel.SetActive(true);
        playerStatsPanel.transform.Find("MaxHealth").GetComponent<TextMeshProUGUI>().text =
            "MaxHealth: " + GameManager.I.player.currentStats.maxHealth.ToString();
        playerStatsPanel.transform.Find("CurrentHealth").GetComponent<TextMeshProUGUI>().text =
            "CurrentHealth: " + GameManager.I.player.currentStats.currentHealth.ToString();
        playerStatsPanel.transform.Find("Armor").GetComponent<TextMeshProUGUI>().text =
            "Armor: " + GameManager.I.player.currentStats.armor.ToString();
        playerStatsPanel.transform.Find("AttackDamage").GetComponent<TextMeshProUGUI>().text =
            "AttackDamage: " + GameManager.I.player.currentStats.attackDamage.ToString();
        playerStatsPanel.transform.Find("AttackSpeed").GetComponent<TextMeshProUGUI>().text =
            "AttackSpeed: " + GameManager.I.player.currentStats.attackSpeed.ToString();
        playerStatsPanel.transform.Find("SpellDamage").GetComponent<TextMeshProUGUI>().text =
            "SpellDamage: " + GameManager.I.player.currentStats.spellDamage.ToString();
        playerStatsPanel.transform.Find("SpellSpeed").GetComponent<TextMeshProUGUI>().text =
            "SpellSpeed: " + GameManager.I.player.currentStats.spellSpeed.ToString();
    }
}