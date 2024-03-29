 using UnityEngine;

public class ItemPickup : Interactable
{

    public Item item;

    public override void Interact()
    {
        base.Interact();

        PickUp(); 
    }

    void PickUp(){
        Debug.Log("Picking up " + item.name + " .");
        bool pickupResult = Inventory.instance.AddItem(item);
        Debug.Log(pickupResult + " pickup result");
        if (pickupResult)
            Destroy(gameObject);
    }
}
