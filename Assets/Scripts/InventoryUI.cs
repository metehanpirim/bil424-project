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

    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI itemDescText;
    public Canvas invCanvas;
    Inventory inventory;
    InventorySlot[] slots;
    void Start()
    {
        inventory = Inventory.instance;
        inventoryUI.SetActive(false);
        craftingUI.SetActive(false);
        qlUI.SetActive(false);
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
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            craftingUI.SetActive(!craftingUI.activeSelf);
            qlUI.SetActive(false);
            inventoryUI.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            qlUI.SetActive(!qlUI.activeSelf);
            craftingUI.SetActive(false);
            inventoryUI.SetActive(false);
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
}
