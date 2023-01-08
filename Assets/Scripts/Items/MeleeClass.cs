using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Melee Class", menuName = "Item/Melee")]
public class MeleeClass : ItemClass
{
    [Header("Melee")]
    public MeleeType meleetype;
    public float damage;
    public float animationLength;
    public bool isAttacking = false;

    [Header("Ability")]
    public float abilityCooldown;
    public bool canUseAbility = true;

    public enum MeleeType
    {
        onehanded,
        twohanded,
    }

    public override void Use(PlayerController player)
    {

    }

    public void UseAbility(PlayerController player)
    {
        
    }

    public override MeleeClass getMelee() { return this; }
}
