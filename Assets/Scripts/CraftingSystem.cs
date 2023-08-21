using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSystem : MonoBehaviour
{
    public TextMeshProUGUI craftedText1, craftedText2;
    public GameObject infotext;
    public void Craft(List<Item> requiredItems, Item craftedItem)
    {
        if (HasRequiredItems(requiredItems))
        {
            RemoveRequiredItems(requiredItems);
            Inventory.instance.AddItem(craftedItem);
            StartCoroutine(ShowCraftedText(craftedText1, craftedText2));
        }
        else
        {
            Debug.Log("Gerekli itemlar eksik!");
        }
    }
    IEnumerator ShowCraftedText(TextMeshProUGUI text1, TextMeshProUGUI text2)
    {
        infotext.SetActive(false);
        Color startColor1 = new Color(text1.color.r, text1.color.g, text1.color.b, 0f);
        Color endColor1 = new Color(text1.color.r, text1.color.g, text1.color.b, 1f);

        Color startColor2 = new Color(text2.color.r, text2.color.g, text2.color.b, 0f);
        Color endColor2 = new Color(text2.color.r, text2.color.g, text2.color.b, 1f);

        text1.color = startColor1;
        text1.gameObject.SetActive(true);

        text2.color = startColor2;
        text2.gameObject.SetActive(true);

        float elapsedTime = 0f;
        float duration = 0.7f; // Efekt süresi

        while (elapsedTime < duration)
        {
            text1.color = Color.Lerp(startColor1, endColor1, elapsedTime / duration);
            text2.color = Color.Lerp(startColor2, endColor2, elapsedTime / duration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        text1.color = endColor1;
        text2.color = endColor2;
        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);
        infotext.SetActive(true);
    }

    public bool HasRequiredItems(List<Item> requiredItems)
    {
        foreach (Item requiredItem in requiredItems)
        {
            if (!Inventory.instance.items.Contains(requiredItem))
            {
                return false;
            }
        }
        return true;
    }

    void RemoveRequiredItems(List<Item> requiredItems)
    {
        foreach (Item requiredItem in requiredItems)
        {
            Inventory.instance.RemoveItem(requiredItem);
        }
    }

}