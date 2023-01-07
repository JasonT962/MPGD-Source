using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public float maxHealth = 100f;
    public float health = 100f;

    [SerializeField] private Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = health;

        if (health <= 0) {
            PlayerController.money += 100;
            PlayerGUIController.RefreshMoney();
            Destroy(gameObject);
        }
    }

}
