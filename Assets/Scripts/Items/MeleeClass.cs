using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Melee Class", menuName = "Item/Melee")]
public class MeleeClass : ItemClass
{
    [Header("Melee")]
    public MeleeType meleetype;
    public float animationLength;
    public bool isAttacking = false;

    public enum MeleeType
    {
        onehanded,
        twohanded,
    }

    public override void Use(PlayerController player)
    {
        GameObject weaponInHandle = player.itemHandle.transform.GetChild(0).gameObject;
        Animator animation = weaponInHandle.GetComponent<Animator>();
        animation.SetTrigger("Attack");
    }

    public override MeleeClass getMelee() { return this; }
}
