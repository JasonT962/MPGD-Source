using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public float maxHealth = 100f;
    public float health = 100f;
    public bool isDead = false;

    [SerializeField] private Slider healthBar;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = health;

        if (health <= 0) {
            Die();
        }
    }

    private void Die()
    {
        if (isDead == false)
        {
            isDead = true;
            PlayerController.money += 10;
            PlayerGUIController.RefreshMoney();
            this.GetComponent<CapsuleCollider>().enabled = false;
            StartCoroutine(EnemyDeath());
        }
    }

    IEnumerator EnemyDeath()
    {
        animator.SetTrigger("Die");
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

}
