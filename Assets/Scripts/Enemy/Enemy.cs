using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public float maxHealth = 100f;
    public float health = 100f;
    [SerializeField] private Slider healthBar;
    public Animator animator;

    GameController gamecontroller;
    public Spawner spawn;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();

        gamecontroller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        spawn = gamecontroller.GetComponentInChildren<Spawner>();
    }

    // Update is called once per frame


    
    void Update()
    {
        healthBar.value = health;

        if (health <= 0) {
            gameObject.tag = "Untagged";
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            StartCoroutine(EnemyDeath());
        }
    }

    IEnumerator EnemyDeath()
    {
        animator.SetTrigger("Die");
        yield return new WaitForSeconds(5);
        //spawn.EnemyKilled();
        Destroy(gameObject);
    }
    
    

}
