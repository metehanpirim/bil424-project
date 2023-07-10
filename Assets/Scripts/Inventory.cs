using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There are more than one instance of of Inventory!");
            return;
        }
        instance = this;
    }
    #endregion

    public List<Item> items = new List<Item>();
    public int maximumSize = 20;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public bool AddItem(Item item)
    {
        Debug.Log("item adding inventory" + item);
        if (!item.isDefaultItem)
        {
            if(items.Count >= maximumSize)
            {
                Debug.Log("Size limit exceeded!");
                return false;
            }
            Debug.Log("item adding inventory" + item);
            items.Add(item);
         
            //invoke just when onItemChangedCallback is not null
            onItemChangedCallback?.Invoke();
        }
        return true;
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
        
        onItemChangedCallback?.Invoke();
    }

}
