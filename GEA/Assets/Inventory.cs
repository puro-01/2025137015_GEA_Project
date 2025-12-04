using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Dictionary<BlockType, int> items = new();
    InventoryUI invenUI;


    public int GetCount(ItemType id)
    {
        items.TryGetValue(id, out var count);
        return count;
    }

    public void Add(BlockType type, int count = 1)
    {
        if (!items.ContainsKey(type)) items[type] = 0;
        items[type] += count;
        Debug.Log($"[Inventory] +{count} {type} (รั {items[type]})");
        invenUI.Updatelnventory(this);
    }

    public bool Consume(BlockType type, int count = 1)
    {
        if (!items.TryGetValue(type, out var have) || have < count) return false;
        items[type] = have - count;
        Debug.Log($"[Inventory] -{count}{type} (รั {items[type]})");
        if (items[type] == 0)
        {
            items.Remove(type);
            invenUI.selectedIndex = -1;
            invenUI.ResetSelection();
        }

        invenUI.Updatelnventory(this);
        return true;
    }
    // Start is called before the first frame update
    void Start()
    {
        invenUI = FindAnyObjectByType<InventoryUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
