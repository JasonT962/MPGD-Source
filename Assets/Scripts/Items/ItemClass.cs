using System.Collections;
using UnityEngine;

public class ItemClass : ScriptableObject
{
    [Header("Item")]
    public string itemName;
    public Sprite icon;
    public GameObject model;
    public bool isStackable;
    public float cooldown;
    public bool canUse = true;

    public virtual void Use(PlayerController player)
    {
        Debug.Log("Used item");
    }
    public virtual ItemClass getItem() { return this; }
    public virtual FoodClass getFood() { return null; }
    public virtual MeleeClass getMelee() { return null; }
    public virtual GunClass getGun() { return null; }

    public virtual GameObject getModel() { return model; }
}
