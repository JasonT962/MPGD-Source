using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCollisionController : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private List<GameObject> hitList = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (player.GetComponent<PlayerController>().currentItem.getMelee() != null) // Makes sure player is equipping the weapon and collision is not from pickup
        {
            if (player.GetComponent<PlayerController>().currentItem.getMelee().isAttacking == true && other.tag == "Enemy")
            {
                if (!hitList.Contains(other.gameObject))
                {
                    hitList.Add(other.gameObject);
                    other.gameObject.GetComponent<Enemy>().health -= player.GetComponent<PlayerController>().currentItem.getMelee().damage;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (player.GetComponent<PlayerController>().currentItem.getMelee() != null) // Makes sure player is equipping the weapon and collision is not from pickup
        {
            if (player.GetComponent<PlayerController>().currentItem.getMelee().isAttacking == false)
            {
                hitList.Clear();
            }
        }
    }
}
