using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private ItemClass whichItem;
    [SerializeField] private GameObject pickUpMessage;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pickUpMessage.SetActive(false);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= 3)
        {
            pickUpMessage.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.GetComponent<PlayerController>().inventory.Add(whichItem,1);
                Destroy(gameObject);
            }
        }
        else
        {
            pickUpMessage.SetActive(false);
        }
    }
}
