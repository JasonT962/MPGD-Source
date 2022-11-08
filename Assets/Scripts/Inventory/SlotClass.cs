using System.Collections;
using UnityEngine;

[System.Serializable]
public class SlotClass
{
    [SerializeField] private ItemClass item;
    [SerializeField] private int amount;

    public SlotClass()
    {
        item = null;
        amount = 0;
    }

    public SlotClass(SlotClass slotitem)
    {
        item = slotitem.GetItem();
        amount = slotitem.GetAmount();
    }

    public SlotClass(ItemClass item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }

    public ItemClass GetItem() { return item; }
    public void SetItem(ItemClass item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }

    public int GetAmount() { return amount; }

    public void AddAmount(int amount)
    {
        this.amount += amount;
    }
    public void RemoveAmount(int amount)
    {
        this.amount -= amount;
    }

    public void Clear()
    {
        this.item = null;
        this.amount = 0;
    }
}
