using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : Singleton<StageManager>
{
    public int currentStage = 1;
    public int currentSubStage = 1;
    
    public static Action OnPlayerWin;
    public static Action OnPlayerLose;

    private void OnEnable()
    {
        OnPlayerWin += StageManager_OnPlayerWin;
    }
    
    private void OnDisable()
    {
        OnPlayerWin -= StageManager_OnPlayerWin;
    }

    private void StageManager_OnPlayerWin()
    {
        currentSubStage++;
        if (currentSubStage > 10)
        {
            currentStage++;
            currentSubStage = 1;
        }
    }
    
}
