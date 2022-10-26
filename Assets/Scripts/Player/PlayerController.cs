using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public InventoryManager inventory;

    // Used for showing items in player hand
    [SerializeField] private GameObject itemHandle;
    private ItemClass currentItem = null;
    private ItemClass itemInHandle = null;

    public float maxHealth = 100f;
    public float health = 100f;
    public float maxHunger = 100f;
    public float hunger = 100f;


    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        refreshItemHandle();

        if (inventory.inventoryOpen == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (inventory.selectedItem != null)
                {
                    inventory.selectedItem.Use(this);
                }
            }
        }

        // Update values over time
        if (hunger >= 50) // If hunger >= 50, increase health by 1 every second
        {
            health += Time.deltaTime * 1f;
        }

        if (hunger > 0)
        {
            hunger -= Time.deltaTime * 0.166f;
        }

        if (hunger > 100)
        {
            hunger = 100;
        }

        if (health > 100)
        {
            health = 100;
        }
    }

    public void refreshItemHandle()
    {
        if (inventory.selectedItem == null || inventory.selectedItem.getModel() == null)
        {
            currentItem = null;
            itemInHandle = null;
            foreach (Transform child in itemHandle.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
        else if (inventory.selectedItem != null)
        {
                currentItem = inventory.selectedItem.getItem();
        }

        if (currentItem != null && currentItem != itemInHandle)
        {
            itemInHandle = currentItem;
            foreach (Transform child in itemHandle.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            GameObject newModel = Instantiate(inventory.selectedItem.model);
            newModel.transform.parent = itemHandle.transform;
            newModel.transform.localPosition = new Vector3(0,0,0);
            newModel.transform.localRotation = new Quaternion(0,0,0,0);

        }
    }
}