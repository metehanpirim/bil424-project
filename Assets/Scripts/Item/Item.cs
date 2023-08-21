using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "Nex Item";
    public string desc = "Item description. A normal simple item. Just item.";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public List<Item> requiredItems;
    public virtual void Use ()
	{
		// Use the item
		// Something might happen

		Debug.Log("Using " + name);
	}

    public void RemoveFromInventory()
    {
        Inventory.instance.RemoveItem(this);
    }
}
  