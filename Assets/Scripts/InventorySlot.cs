
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Item item;
    public Image icon;
    public Button removeButton;
    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI itemDescText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null)
        {
            Debug.Log(item.name + " entered");
            itemNameText.text = item.name;
            itemDescText.text = item.desc;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log(" exited");
        itemNameText.text = "";
        itemDescText.text = "";
    }
    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;

        // Item adýný itemNameText'e yazdýr
        itemNameText.text = item.name;
    }
    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;

        // Item adýný itemNameText'e boþ metin atayýn
        itemNameText.text = "";
    }
    public void OnRemoveButton()
    {
        Inventory.instance.RemoveItem(item);
    }
    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }

}
