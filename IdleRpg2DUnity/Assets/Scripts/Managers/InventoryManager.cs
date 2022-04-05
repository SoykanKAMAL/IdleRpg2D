using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    public static Action<InventorySlot> OnInventorySlotHighlighted;
    public static Action OnEquipmentEquipped;
    public InventorySlot selectedSlot { get; private set; }
    public GameObject inventoryPanel;
    public List<InventorySlot> inventorySlots;

    public InventorySlot weaponSlot;
    public InventorySlot armorSlot;
    public InventorySlot accessorySlot;   
    public InventorySlot shieldSlot;
    public InventorySlot helmetSlot;

    private void OnEnable()
    {
        OnInventorySlotHighlighted += slot => selectedSlot = slot; 
        OnEquipmentEquipped += InventoryManager_OnEquipmentEquipped;
    }
    
    private void OnDisable()
    {
        OnInventorySlotHighlighted -= slot => selectedSlot = slot;
        OnEquipmentEquipped -= InventoryManager_OnEquipmentEquipped;
    }

    private void InventoryManager_OnEquipmentEquipped()
    {
        // Update stats
        if(weaponSlot.equipmentUi != null)GameManager.I.player.weaponEquipped =  (Weapon)weaponSlot.equipmentUi.Equipment;
        if(armorSlot.equipmentUi != null)GameManager.I.player.armorEquipped = (Armor)armorSlot.equipmentUi.Equipment;
        if(accessorySlot.equipmentUi != null)GameManager.I.player.accessoryEquipped = (Accessory)accessorySlot.equipmentUi.Equipment;
        if(shieldSlot.equipmentUi != null)GameManager.I.player.shieldEquipped = (Shield)shieldSlot.equipmentUi.Equipment;
        if(helmetSlot.equipmentUi != null)GameManager.I.player.helmetEquipped = (Helmet)helmetSlot.equipmentUi.Equipment;
        GameManager.I.player.UpdateStats();
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
