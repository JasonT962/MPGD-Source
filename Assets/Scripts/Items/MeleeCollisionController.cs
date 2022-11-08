using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCollisionController : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (player.GetComponent<PlayerController>().currentItem.getMelee().isAttacking == true && other.tag == "Enemy")
        {
            GameObject.Destroy(other.gameObject);
        }
    }
}
