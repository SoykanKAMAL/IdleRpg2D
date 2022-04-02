using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager : Singleton<RewardManager>
{
    [SerializeField] private List<Equipment> Level0Equipment;
    [SerializeField] private List<Equipment> Level1Equipment;
    
    public Equipment GenerateRandomEquipment(int level)
    {
        switch (level)
        {
            case 0:
                return Level0Equipment[Random.Range(0, Level0Equipment.Count)];
            case 1:
                return Level1Equipment[Random.Range(0, Level1Equipment.Count)];
            default:
                return null;
        }
    }
}
