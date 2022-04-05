using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    public static Action<InventorySlot> OnInventorySlotHighlighted;
    public InventorySlot selectedSlot;
    
    public List<InventorySlot> inventorySlots;

    private void OnEnable()
    {
        OnInventorySlotHighlighted += slot => selectedSlot = slot; 
    }
    
    private void OnDisable()
    {
        OnInventorySlotHighlighted -= slot => selectedSlot = slot;
    }
    
    public void FindAnEmptySlot(out InventorySlot suitableSlot)
    {
        foreach (var slot in inventorySlots)
        {
            if (slot.equipmentUi == null)
            {
                suitableSlot = slot;
                return;
            }
        }
        suitableSlot = null;
    }
}
