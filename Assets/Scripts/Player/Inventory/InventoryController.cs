using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField]
    private List<Item> inventory = new List<Item>();
    [SerializeField]
    private int MaxInventorySize;
    [SerializeField]
    private PlayerController player;
    private int itemNotFounded = -1;


    public void ConsumeItem(ItemType type) 
    {
        if (IsNotConsumable(type)) return;

        int firstIndex = inventory.FindIndex(x => x.type == type);

        if(firstIndex != itemNotFounded)  {

            Item item = inventory[firstIndex];
            switch (type) 
            {
                case ItemType.HEALTH_POTION:
                    player.HealPotion(item.amount);
                    break;

                case ItemType.MANA_POTION:
                    player.ManaPotion(item.amount);
                    break;
            }   
            inventory.RemoveAt(firstIndex);
        }
    
    }

    public void AddItem(Item item) 
    {
        if (inventory.Count < MaxInventorySize) 
        {
            inventory.Add(item);
        }
    }

    private bool IsNotConsumable(ItemType type) 
    {
        return type.Equals(ItemType.HEALTH_POTION) || type.Equals(ItemType.MANA_POTION);
    }
}
