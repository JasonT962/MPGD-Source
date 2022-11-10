using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject slotHolder;
    [SerializeField] private GameObject hotbarSlotHolder;

    [SerializeField] private ItemClass itemToAdd;
    [SerializeField] private ItemClass itemToRemove;

    [SerializeField] private GameObject cursorIcon;

    [SerializeField] private SlotClass[] startingItems;
    [SerializeField] private SlotClass[] items;

    private GameObject[] slots;
    private GameObject[] hotbarSlots;

    private SlotClass originalSlot;
    private SlotClass movingSlot;
    private SlotClass tempSlot;
    private bool itemMoving;

    [SerializeField] private GameObject hotbarSelector;
    [SerializeField] private int selectedSlot = 0;
    public ItemClass selectedItem;

    // For enabling and disabling camera / inventory gui
    public bool inventoryOpen = false;
    [SerializeField] private GameObject inventoryPanel;

    private void Start()
    {
        slots = new GameObject[slotHolder.transform.childCount];
        items = new SlotClass[slots.Length];
        hotbarSlots = new GameObject[5];

        // Set all slots
        for (int i = 0; i < items.Length; i++)
        {
            items[i] = new SlotClass();
        }
        for (int i = 0; i < startingItems.Length; i++)
        {
            items[i] = startingItems[i];
        }
        for (int i = 0; i < slotHolder.transform.childCount; i++)
        {
            slots[i] = slotHolder.transform.GetChild(i).gameObject;
        }
        for (int i = 0; i < hotbarSlots.Length; i++)
        {
            hotbarSlots[i] = slotHolder.transform.GetChild(i).gameObject;
        }

        RefreshGUI();
        if (itemToAdd != null)
        {
            Add(itemToAdd,1);
        }
        Remove(itemToRemove);

        CloseInventory();
    }

    private void Update()
    {
        cursorIcon.SetActive(itemMoving);
        if (itemMoving)
        {
            cursorIcon.transform.position = Input.mousePosition;
            cursorIcon.GetComponent<Image>().sprite = movingSlot.GetItem().icon;
        }

        if (Input.GetKeyDown(KeyCode.I)) {
            if (inventoryOpen == false)
            {
                OpenInventory();
            }
            else if (inventoryOpen == true)
            {
                CloseInventory();
            }
        }
        if (Input.GetMouseButtonDown(0) && inventoryOpen == true) // When we click
        {
            if (itemMoving == true)
            {
                EndMove();
            }
            else
            {
                BeginMove();
            }
        }

        // Hotbar slot selected with number keys
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedSlot = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedSlot = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedSlot = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedSlot = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            selectedSlot = 4;
        }
        hotbarSelector.transform.position = hotbarSlots[selectedSlot].transform.position;
        selectedItem = items[selectedSlot].GetItem();
    }

    #region Inventory Utils
    public void RefreshGUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            try
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].GetItem().icon;
                if (items[i].GetItem().isStackable)
                {
                    slots[i].transform.GetChild(1).GetComponent<Text>().text = items[i].GetAmount().ToString();
                }
                else
                {
                    slots[i].transform.GetChild(1).GetComponent<Text>().text = "";
                }
            }
            catch
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
                slots[i].transform.GetChild(1).GetComponent<Text>().text = "";
            }
        }
    }

    public void OpenInventory()
    {
        for (int i = 5; i < slots.Length; i++)
        {
            slots[i].SetActive(true);
        }

        inventoryOpen = true;
        inventoryPanel.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseInventory()
    {
        for (int i = 5; i < slots.Length; i++)
        {
            slots[i].SetActive(false);
        }

        inventoryOpen = false;
        inventoryPanel.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public bool Add(ItemClass item, int amount)
    {
        SlotClass slot = Contains(item);
        if (slot != null)
        {
            if (slot.GetItem().isStackable)
            {
                slot.AddAmount(1);
            }
            else
            {
                return false;
            }
        }
        else
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].GetItem() == null)
                {
                    items[i].SetItem(item, amount);
                    break;
                }
            }
        }

        RefreshGUI();
        return true;
    }

    public bool Remove(ItemClass item)
    {
        SlotClass toRemove = Contains(item);
        if (toRemove != null)
        {
            if (toRemove.GetAmount() > 1)
            {
                toRemove.RemoveAmount(1);
            }
            else
            {
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i].GetItem() == item)
                    {
                        items[i].Clear();
                        break;
                    }
                }
            }
        }
        else
        {
            return false;
        }
        RefreshGUI();
        return true;
    }

    public SlotClass Contains(ItemClass item)
    {
        foreach (SlotClass slot in items)
        {
            if (slot.GetItem() == item)
            {
                return slot;
            }
        }
        return null;
    }
    #endregion Inventory Utils

    #region Moving Utils

    private bool BeginMove()
    {
        originalSlot = FindClosestSlot();
        if (originalSlot == null || originalSlot.GetItem() == null) // no item
        {
            return false;
        }
        movingSlot = new SlotClass(originalSlot);
        originalSlot.Clear();
        itemMoving = true;
        RefreshGUI();
        return true;
    }
    private SlotClass FindClosestSlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (Vector2.Distance(slots[i].transform.position, Input.mousePosition) <= 30)
            {
                return items[i];
            }
        }
        return null;
    }

    private bool EndMove()
    {
        originalSlot = FindClosestSlot();
        if (originalSlot == null)
        {
            Add(movingSlot.GetItem(),movingSlot.GetAmount());
            movingSlot.Clear();
            itemMoving = false;
            return false;
        }
        if (originalSlot.GetItem() != null)
        {
            if (originalSlot.GetItem() == movingSlot.GetItem())
            {
                if (originalSlot.GetItem().isStackable)
                {
                    originalSlot.AddAmount(movingSlot.GetAmount());
                    movingSlot.Clear();
                }
            }
            else // Swap items
            {
                tempSlot = new SlotClass(originalSlot);
                originalSlot.SetItem(movingSlot.GetItem(), movingSlot.GetAmount());
                movingSlot.SetItem(tempSlot.GetItem(), tempSlot.GetAmount());
                RefreshGUI();
                return true;
            }
        }
        else
        {
            originalSlot.SetItem(movingSlot.GetItem(),movingSlot.GetAmount());
            movingSlot.Clear();
        }
        itemMoving = false;
        RefreshGUI();
        return true;
    }

    #endregion Moving Utils
}
