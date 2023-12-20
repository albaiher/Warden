using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField]
    private List<Item> inventory = new List<Item>();
    [SerializeField]
    private int MaxInventorySize;
    private PlayerController player;
    private int itemNotFounded = -1;

    private static InventoryController instance = null;
    public static InventoryController Instance
    {
        get { return instance; }
    }

    private void Start()
    {
        player = this.gameObject.GetComponent<PlayerController>();
        EnsureSingleton();
    }

    public void ConsumeItem(ItemType type) 
    {
        if (!IsConsumable(type)) return;

        int firstIndex = inventory.FindIndex(x => x.type == type);

        Debug.Log(firstIndex);
        if(firstIndex != itemNotFounded)  {

            Item item = inventory[firstIndex];
            switch (type) 
            {
                case ItemType.HEALTH_POTION:
                    player.HealPlayer(item.amount);
                    break;

                case ItemType.MANA_POTION:
                    player.RegenMana(item.amount);
                    break;
            }   
            inventory.RemoveAt(firstIndex);
        }
    
    }

    public void AddItem(Item item)
    {
        if (!HasEnoughSpace()) return ;

        inventory.Add(item);
    }

    public bool HasEnoughSpace()
    {
        return inventory.Count < MaxInventorySize;
    }

    private bool IsConsumable(ItemType type) 
    {
        return type.Equals(ItemType.HEALTH_POTION) || type.Equals(ItemType.MANA_POTION);
    }

    private void EnsureSingleton()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

}
