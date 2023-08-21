using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FireplaceSystem : MonoBehaviour
{
    public TextMeshProUGUI craftedText1, craftedText2;
    public GameObject infotext;
    public Slider craftSlider;
    public TextMeshProUGUI craftProgressText1, craftProgressText2;
    public void Craft(List<Item> requiredItems, Item craftedItem)
    {
        if (HasRequiredItems(requiredItems))
        {
            StartCoroutine(Crafting(requiredItems, craftedItem));
        }
        else
        {
            Debug.Log("Gerekli itemlar eksik!");
        }
    }

    void Start()
    {
        craftProgressText1.gameObject.SetActive(false);
        craftProgressText2.gameObject.SetActive(false);
        craftSlider.gameObject.SetActive(false);
        craftedText2.gameObject.SetActive(false);
        craftedText1.gameObject.SetActive(false);
    }
    IEnumerator Crafting(List<Item> requiredItems, Item craftedItem)
    {
        infotext.SetActive(false);
        craftProgressText1.gameObject.SetActive(true);
        craftProgressText2.gameObject.SetActive(true);
        craftSlider.gameObject.SetActive(true);
        Debug.Log("cook basladi!");
        float craftDuration = 3f; // Craft süresi (3 saniye)
        float elapsedTime = 0f;

        while (elapsedTime < craftDuration)
        {
            Debug.Log("cook basladi 2!");
            craftSlider.value = elapsedTime / craftDuration;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        craftSlider.value = 1f; // Tamamlanmýþ olarak ayarla
        craftProgressText1.gameObject.SetActive(false);
        craftProgressText2.gameObject.SetActive(false);
        craftSlider.gameObject.SetActive(false);
        RemoveRequiredItems(requiredItems);
        Inventory.instance.AddItem(craftedItem);
        StartCoroutine(ShowCraftedText(craftedText1, craftedText2));
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