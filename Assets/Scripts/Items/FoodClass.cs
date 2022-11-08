using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "new Food Class", menuName = "Item/Food")]
public class FoodClass : ItemClass
{
    [Header("Food")]
    public float healthAdded;
    public float hungerAdded;

    public override void Use(PlayerController player)
    {
        Debug.Log("Ate food");
        player.health += healthAdded;
        player.hunger += hungerAdded;
        player.inventory.Remove(this);
    }

    public override FoodClass getFood() { return this; }
}
