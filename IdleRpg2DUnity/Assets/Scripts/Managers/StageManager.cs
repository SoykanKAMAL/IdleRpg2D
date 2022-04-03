using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : Singleton<StageManager>
{
    public int currentStage = 1;
    public int currentSubStage = 1;

    private void OnEnable()
    {
        EnemyManager.OnPlayerWin += StageManager_OnPlayerWin;
    }
    
    private void OnDisable()
    {
        EnemyManager.OnPlayerWin -= StageManager_OnPlayerWin;
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
