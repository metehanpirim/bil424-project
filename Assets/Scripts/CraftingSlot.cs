using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CraftingSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;
    public Image icon;
    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI itemDescText;
    public TextMeshProUGUI itemReqTitleText;
    public TextMeshProUGUI itemReqText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null)
        {
            Debug.Log(item.name + " entered");
            itemNameText.text = item.name;
            itemDescText.text = item.desc;
            itemReqTitleText.enabled = true;
            itemReqText.text = "";
            foreach(Item item in item.requiredItems)
            {
                itemReqText.text += "1x " + item.name + ", ";
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log(" exited");
        itemNameText.text = "";
        itemDescText.text = "";
        itemReqTitleText.enabled = false;
        itemReqText.text = "";
    }

    void Start()
    {
        itemNameText.text = "";
        itemDescText.text = "";
        itemReqTitleText.enabled = false;
        itemReqText.text = "";
    }

}