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

    [SerializeField]
    private TextMeshProUGUI leftText = null;
    [SerializeField]
    private TextMeshProUGUI rightText = null;
    
    public static Action OnEndCurrentState;
    public Button endStateButton;

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
        endStateButton.onClick.AddListener(() =>
        {
            OnEndCurrentState?.Invoke();
        });
    }
    
    private void OnDisable()
    {
        endStateButton.onClick.RemoveAllListeners();
    }
}