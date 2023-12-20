using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour
{
    [SerializeField] private Item item;

    private InventoryController inventory;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inventory = InventoryController.Instance;
            if (inventory.HasEnoughSpace())
            {
                AddItemToInventory();
            }
        }
    }

    private void AddItemToInventory()
    {
        inventory.AddItem(item);
        Destroy(this.gameObject);
    }


}
