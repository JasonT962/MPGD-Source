using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(End());
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().health -= 100;
        }
    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
