using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGUIController : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider hungerBar;

    [SerializeField] private GameObject player;

    private void Update()
    {
        healthBar.value = player.GetComponent<PlayerController>().health;
        hungerBar.value = player.GetComponent<PlayerController>().hunger;
    }
}
