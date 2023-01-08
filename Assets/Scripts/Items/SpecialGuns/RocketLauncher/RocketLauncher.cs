using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "new RocketLauncher Class", menuName = "Item/SpecialGuns/RocketLauncher")]
public class RocketLauncher : GunClass
{
    [SerializeField] private GameObject rocket;
    public override void Use(PlayerController player)
    {
        Instantiate(rocket, player.transform.position + (player.transform.forward * 2) + (new Vector3(0,1.4f,0)), player.transform.rotation);
    }

    public override GunClass getGun() { return this; }
}
