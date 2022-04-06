using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RewardManager : Singleton<RewardManager>
{
    [SerializeField] private List<Equipment> rewardableEquipments;
    
    public GameObject rewardPrefab;
    
    public int CurrentGold { get; private set; }

    private GameObject canvas;
    private Camera mainCamera;
    
    private void Start()
    {
        canvas = GameObject.Find("Canvas");
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        StageManager.OnPlayerWin += RewardManager_OnPlayerWin;
    }
    
    private void OnDisable()
    {
        StageManager.OnPlayerWin -= RewardManager_OnPlayerWin;
    }
    
    private void RewardManager_OnPlayerWin()
    {
        GenerateRandomEquipment(StageManager.I.currentStage);
    }
    
    private void GenerateRandomEquipment(int count)
    {
        for(int i =0; i < count; i++)
        {
            GameObject rewardedEquipment = Instantiate(rewardPrefab, mainCamera.WorldToScreenPoint(BattleManager.I.enemyGO.transform.position), Quaternion.identity, canvas.transform);
            rewardedEquipment.GetComponent<EquipmentUi>().UpdateEquipment(rewardableEquipments[Random.Range(0, rewardableEquipments.Count)]);
        }
    }
}
