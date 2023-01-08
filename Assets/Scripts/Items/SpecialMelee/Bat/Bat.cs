using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Bat Class", menuName = "Item/SpecialMelee/Bat")]
public class Bat : MeleeClass
{

    [SerializeField] private GameObject ball;

    public override void Use(PlayerController player)
    {

    }

    public override void UseAbility(PlayerController player)
    {
        Instantiate(ball, player.transform.position + (player.transform.forward * 2) + (Vector3.up*1), player.transform.rotation);
    }

    public override MeleeClass getMelee() { return this; }
}
