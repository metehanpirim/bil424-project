using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{


    public Transform itemsParent;
    public GameObject inventoryUI;
    public GameObject craftingUI;
    public GameObject qlUI;
    public GameObject fireplaceUI;

    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI itemDescText;


    public TextMeshProUGUI alertText;
    public TextMeshProUGUI alertText2;

    public Canvas invCanvas;

    public Transform fireplaceTransform; // Þömine pozisyonu
    public Transform playerTransform; // Oyuncu pozisyonu

    Inventory inventory;
    InventorySlot[] slots;
    void Start()
    {
        inventory = Inventory.instance;
        inventoryUI.SetActive(false);
        craftingUI.SetActive(false);
        qlUI.SetActive(false);
        fireplaceUI.SetActive(false);
        itemNameText.text = "";
        itemDescText.text = "";
        // onItemChangedCallback delegesine UpdateUI metodunu ekliyoruz
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();

        // Her slota item adýný gösteren Text bileþenini atýyoruz
        foreach (InventorySlot slot in slots)
        {
            slot.itemNameText = itemNameText;
            slot.itemDescText = itemDescText;
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            craftingUI.SetActive(false);
            qlUI.SetActive(false);
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            fireplaceUI.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            craftingUI.SetActive(!craftingUI.activeSelf);
            qlUI.SetActive(false);
            inventoryUI.SetActive(false);
            fireplaceUI.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            qlUI.SetActive(!qlUI.activeSelf);
            craftingUI.SetActive(false);
            inventoryUI.SetActive(false);
            fireplaceUI.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            float distance = Vector3.Distance(fireplaceTransform.position, playerTransform.position);
            if (distance <= 10f) // Eðer þömine 10 birim içindeyse
            {
                fireplaceUI.SetActive(!fireplaceUI.activeSelf);
                craftingUI.SetActive(false);
                inventoryUI.SetActive(false);
                qlUI.SetActive(false);
            }
            else
            {
                fireplaceUI.SetActive(false);
                StartCoroutine(ShowCraftedText(alertText, alertText2));
            }
        }

    }
    void UpdateUI()
    {

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

    IEnumerator ShowCraftedText(TextMeshProUGUI text1, TextMeshProUGUI text2)
    {
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
        yield return new WaitForSeconds(1.5f);
        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);
    }
}
