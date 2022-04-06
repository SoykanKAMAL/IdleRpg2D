using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public EquipmentUi equipmentUi { get; private set; }
    public Color slotEmptyColor;
    public Color slotFullColor;
    public GameObject highlight;
    public Image backgroundImage;
    public bool isPlayerSlot;
    public Equipment targetType;
    public Transform itemPlaceholder;
    private RectTransform rectTransform;
    private bool isHighlighted;
    public Image equippedIcon;
    
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        UpdateInventorySlot();
    }

    public void UpdateInventorySlot()
    {
        if(equipmentUi == null) backgroundImage.color = slotEmptyColor;
        else backgroundImage.color = slotFullColor;
    }

    private void Update()
    {
        if (isPlayerSlot)
        {
            if (equipmentUi != null)
            {
                equippedIcon.enabled = true;
                equippedIcon.sprite = equipmentUi.Equipment.sprite;
            }
            else
            {
                equippedIcon.enabled = false;
            }
        }
        
        highlight.SetActive(isHighlighted);
        var mousePos = Input.mousePosition;
        // Check if mouse is over the slot within 100 pixels
        if(mousePos.x > this.transform.position.x - rectTransform.rect.width 
           && mousePos.x < this.transform.position.x + rectTransform.rect.width  
           && mousePos.y > this.transform.position.y - rectTransform.rect.height  
           && mousePos.y < this.transform.position.y + rectTransform.rect.height)
        {
            if(!isHighlighted) InventoryManager.OnInventorySlotHighlighted?.Invoke(this);
            isHighlighted = true;
            return;
        }
        if(isHighlighted) InventoryManager.OnInventorySlotHighlighted?.Invoke(null);
        isHighlighted = false;
    }
    
    public void SetEquipmentSlot(EquipmentUi currentEquipmentUi)
    {
        if (currentEquipmentUi == null)
        {
            // Destroy children of itemPlaceholder
            foreach (Transform child in itemPlaceholder)
            {
                Destroy(child.gameObject);
            }
        }
        equipmentUi = currentEquipmentUi;
        UpdateInventorySlot();
    }
}
