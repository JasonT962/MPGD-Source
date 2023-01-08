using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public InventoryManager inventory;
    private Animator animator;

    // Used for showing items in player hand
    public GameObject itemHandle;
    public ItemClass currentItem = null;
    public ItemClass itemInHandle = null;

    public float maxHealth = 100f;
    public float health = 100f;
    
    public static int money = 0;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


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

        if (inventory.inventoryOpen == false & Cursor.visible == false & Cursor.lockState == CursorLockMode.Locked) // If player does not have any GUI open
        {
            if (inventory.selectedItem != null && inventory.selectedItem.canUse == true)
            {
                if (inventory.selectedItem.getGun() != null) // If selected weapon is a gun
                {
                    GunClass gunWeapon = inventory.selectedItem as GunClass;
                    if (gunWeapon.fullAuto == true)
                    {
                        if (Input.GetMouseButton(0))
                        {
                            UseItem();
                        }
                    }
                    else
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            UseItem();
                        }
                    }
                }
                else
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                            UseItem();
                    }
                }

            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (inventory.selectedItem != null && inventory.selectedItem.getMelee() != null)
                {
                    MeleeClass meleeWeapon = inventory.selectedItem as MeleeClass;
                    if (meleeWeapon.canUseAbility == true)
                    {
                        UseAbility();
                    }
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

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            TakeDamage(5);
        }
    }

    void TakeDamage(int damage)
    {
        health = health - damage;
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
            newModel.transform.localPosition = inventory.selectedItem.model.transform.localPosition;
            newModel.transform.localRotation = inventory.selectedItem.model.transform.localRotation;

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
            animator.SetTrigger("MeleeAttack");
        }
    }

    IEnumerator ResetItemCooldown()
    {
        ItemClass temp = inventory.selectedItem;
        yield return new WaitForSeconds(temp.cooldown);
        temp.canUse = true;
    }

    public void UseAbility() // For melee weapons only
    {
        MeleeClass temp = inventory.selectedItem as MeleeClass;
        temp.UseAbility(this);
        temp.canUseAbility = false;
        StartCoroutine(ResetAbilityCooldown());
    }

    IEnumerator ResetAbilityCooldown() // For melee weapons only
    {
        MeleeClass temp = inventory.selectedItem as MeleeClass;
        yield return new WaitForSeconds(temp.abilityCooldown);
        temp.canUseAbility = true;
    }

    IEnumerator MeleeAttack()
    {
        MeleeClass temp = inventory.selectedItem as MeleeClass;
        temp.isAttacking = true;
        yield return new WaitForSeconds(temp.animationLength);
        temp.isAttacking = false;
    }
}
