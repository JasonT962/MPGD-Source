using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public Transform playerObj;
    [SerializeField] NavMeshAgent enemyMesh;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player").transform;
        enemyMesh = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //other.gameObject.SetActive(false);
        //if (Vector3.Distance(transform.position, playerObj.transform.position) <= 10)
        if (this.GetComponent<Enemy>().health > 0)
        {
            enemyMesh.SetDestination(playerObj.position);
        }
        else
        {
            animator.SetTrigger("Die");
            transform.GetChild(1).gameObject.SetActive(false);
        }
    }

}
