using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentUi : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler
{
    [SerializeField]private Equipment equipment;
    public Equipment Equipment { get => equipment; set => equipment = value; }
    
    private Image image;

    public InventorySlot lastInventorySlot;
    private bool isSelected = false;
    private Transform canvasTransform;
    private bool isRewarded = false;
    private void Start()
    {
        image = GetComponent<Image>();
        canvasTransform = GameObject.FindGameObjectWithTag("Canvas").transform;
        UpdateEquipment();
    }

    private void Update()
    {
        if(isSelected){
            // Stick to the mouse
            transform.position = Input.mousePosition;
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Unlink from the parent
        transform.SetParent(canvasTransform);
        isSelected = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isSelected = false;
        if(lastInventorySlot != null) lastInventorySlot.SetEquipmentSlot(null);
        if (InventoryManager.I.selectedSlot != null)
        {
            if(InventoryManager.I.selectedSlot.equipmentUi == null) lastInventorySlot = InventoryManager.I.selectedSlot;
            else
            {
                // Check for merge
                var mergeResult = (Equipment)equipment.Merge(InventoryManager.I.selectedSlot.equipmentUi.equipment);
                if (mergeResult != null)
                {
                    InventoryManager.I.selectedSlot.SetEquipmentSlot(null);
                    lastInventorySlot = InventoryManager.I.selectedSlot;
                    this.equipment = mergeResult;
                    UpdateEquipment();
                }
            }
        }
        lastInventorySlot.SetEquipmentSlot(this);
        transform.SetParent(lastInventorySlot.itemPlaceholder.transform);
        transform.localPosition = Vector3.zero;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isRewarded) return;
        InventoryManager.I.FindAnEmptySlot(out InventorySlot slot);
        if (slot == null)
        {
            Debug.Log("No empty slot");
            return;
        }
        lastInventorySlot = slot;
        lastInventorySlot.SetEquipmentSlot(this);
        transform.SetParent(lastInventorySlot.itemPlaceholder.transform);
        transform.localPosition = Vector3.zero;
        isRewarded = true;
        
    }

    private void UpdateEquipment()
    {
        image.sprite = equipment.sprite;
    }
}
