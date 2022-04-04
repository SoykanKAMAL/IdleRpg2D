using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Equipment currentEquipment;
    public Color slotEmptyColor;
    public Color slotFullColor;
    public GameObject highlight;
    
    public Image backgroundImage;
    // Start is called before the first frame update
    void Start()
    {
        UpdateInventorySlot();
    }

    public void UpdateInventorySlot()
    {
        if(currentEquipment == null) backgroundImage.color = slotEmptyColor;
        else backgroundImage.color = slotFullColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        highlight.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        highlight.SetActive(false);
    }
}
