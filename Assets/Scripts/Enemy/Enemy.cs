using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public float maxHealth = 100f;
    public float health = 100f;
    public bool isDead = false;

    GameController gamecontroller;
    public Spawner spawn;

    [SerializeField] private Slider healthBar;
    public Animator animator;

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

        if (health <= 0)
        {
            gameObject.tag = "Untagged";
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            StartCoroutine(EnemyDeath());
        }
    }

    private void Die()
    {
        if (isDead == false)
        {
            isDead = true;
            PlayerController.money += 100;
            PlayerGUIController.RefreshMoney();
            this.GetComponent<CapsuleCollider>().enabled = false;
            //StartCoroutine(EnemyDeath());
        }
    }

    IEnumerator EnemyDeath()
    {
        animator.SetTrigger("Die");
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
        yield return new WaitForSeconds(5);
        //spawn.EnemyKilled();
        Destroy(gameObject);
    }

}