using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CraftGeneral : MonoBehaviour
{
    public CraftingSystem craftingSystem;
    public Item currentItem;
    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(craft);
    }

    private void Update()
    {
        Button button = GetComponent<Button>();
        button.interactable = CanCraft();
    }

    public void craft()
    {
        Debug.Log("CRAFT FUNCTION");
        craftingSystem.Craft(currentItem.requiredItems, currentItem);

    }

    bool CanCraft()
    {
        return craftingSystem.HasRequiredItems(currentItem.requiredItems);
    }
}
