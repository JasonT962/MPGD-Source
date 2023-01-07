using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public InventoryManager inventory;

    // Used for showing items in player hand
    public GameObject itemHandle;
    public ItemClass currentItem = null;
    public ItemClass itemInHandle = null;

    public float maxHealth = 100f;
    public float health = 100f;

    public static int money = 0;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        money = 0;
    }

    // Update is called once per frame
    void Update()
    {
        refreshItemHandle();

        if (inventory.inventoryOpen == false & Cursor.visible == false & Cursor.lockState == CursorLockMode.Locked)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (inventory.selectedItem != null && inventory.selectedItem.canUse == true)
                {
                    UseItem();
                }
            }
        }

        // Update values over time
        if (health > 100)
        {
            health = 100;
        }

        if (health <= 0)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(2);
        }

        // Tab key lets you use the mouse
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (Cursor.visible == false & Cursor.lockState == CursorLockMode.Locked)
            { 
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Enemy") {
            health = health - 5;
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

    public void UseItem()
    {
        inventory.selectedItem.Use(this);
        inventory.selectedItem.canUse = false;
        StartCoroutine(ResetItemCooldown());

        if (inventory.selectedItem is MeleeClass) // For melee hitbox activation
        {
            StartCoroutine(MeleeAttack());
        }
    }

    IEnumerator ResetItemCooldown()
    {
        ItemClass temp = inventory.selectedItem;
        yield return new WaitForSeconds(temp.cooldown);
        temp.canUse = true;
    }

    IEnumerator MeleeAttack()
    {
        MeleeClass temp = inventory.selectedItem as MeleeClass;
        temp.isAttacking = true;
        yield return new WaitForSeconds(temp.animationLength);
        temp.isAttacking = false;
    }
}
