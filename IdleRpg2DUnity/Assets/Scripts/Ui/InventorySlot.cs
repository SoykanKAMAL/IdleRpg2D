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
    public Transform itemPlaceholder;
    public Image backgroundImage;
    
    private RectTransform rectTransform;
    public bool isHighlighted;
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
