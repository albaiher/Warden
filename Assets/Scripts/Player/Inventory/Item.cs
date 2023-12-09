using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item", order = 2)]
public class Item : ScriptableObject
{
    public string itemName;
    public ItemType type;
    public int amount;
}
