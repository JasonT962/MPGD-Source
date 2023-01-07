using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public Transform playerObj;
    [SerializeField] NavMeshAgent enemyMesh;
    private Animator animator;

    GameController gamecontroller;
    public Spawner spawn;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player").transform;
        enemyMesh = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();

        gamecontroller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        spawn = gamecontroller.GetComponentInChildren<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        //other.gameObject.SetActive(false);
        //if (Vector3.Distance(transform.position, playerObj.transform.position) <= 10)
        if (this.GetComponent<Enemy>().health > 0 && gameObject.tag=="Enemy") 
        {
            enemyMesh.SetDestination(playerObj.position);
        }
        else
        {
            gameObject.tag = "Untagged";
            animator.SetTrigger("Die");
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            transform.GetChild(1).gameObject.SetActive(false);
            StartCoroutine(EnemyDeath());
        }
    }

    IEnumerator EnemyDeath()
    {

        yield return new WaitForSeconds(5);
        spawn.EnemyKilled();
        gameObject.SetActive(false);
    }

}



