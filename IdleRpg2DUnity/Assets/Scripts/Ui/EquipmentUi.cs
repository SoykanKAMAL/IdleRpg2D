using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EquipmentUi : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler
{
    [SerializeField]private Equipment equipment;
    public Equipment Equipment { get => equipment; set => equipment = value; }
    public InventorySlot lastInventorySlot { get; set; }
    private bool isSelected = false;
    private Transform canvasTransform;
    private bool isRewarded = false;
    public Image image;
    private Tween dropTween;
    private void Start()
    {
        dropTween = transform.DOMoveY(50, 1f).SetLoops(-1, LoopType.Yoyo).SetRelative(true).SetAutoKill(false).Pause();
        // Jump to random location within 20 pixels
        transform.DOLocalJump(new Vector3(Random.Range(-200, 125), Random.Range(0, 25), 0), 200f, 3, 1.5f).SetRelative(true).OnComplete(() =>
        {
            dropTween.Restart();
        });
        canvasTransform = GameObject.FindGameObjectWithTag("Canvas").transform;
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
            if (InventoryManager.I.selectedSlot.isPlayerSlot)
            {
                if (InventoryManager.I.selectedSlot.equipmentUi == null)
                {
                    if (InventoryManager.I.selectedSlot.targetType.GetType() == equipment.GetType())
                    {
                        lastInventorySlot = InventoryManager.I.selectedSlot;
                        // HANDLE EQUIP LOGIC
                        lastInventorySlot.SetEquipmentSlot(this);
                        transform.SetParent(lastInventorySlot.itemPlaceholder.transform);
                        transform.localPosition = Vector3.zero;
                        InventoryManager.OnEquipmentEquipped?.Invoke();
                    }
                }
            }
            else if(InventoryManager.I.selectedSlot.equipmentUi == null) lastInventorySlot = InventoryManager.I.selectedSlot;
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
        if (isRewarded || !InventoryManager.I.inventoryPanel.activeSelf) return;
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
        // Kill all tweens on this object
        transform.DOKill();
    }

    public void UpdateEquipment(Equipment newEquipment = null)
    {
        if (newEquipment != null)
        {
            equipment = newEquipment;
        }
        if (equipment == null)
        {
            image.sprite = null;
            image.color = Color.clear;
            return;
        }
        image.sprite = equipment.sprite;
        image.color = Color.white;
    }
}
