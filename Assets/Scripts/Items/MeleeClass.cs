using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Melee Class", menuName = "Item/Melee")]
public class MeleeClass : ItemClass
{
    [Header("Melee")]
    public MeleeType meleetype;
    public enum MeleeType
    {
        onehanded,
        twohanded,
    }

    public override void Use(PlayerController player)
    {
        player.health -= 10;
    }

    public override MeleeClass getMelee() { return this; }
}
