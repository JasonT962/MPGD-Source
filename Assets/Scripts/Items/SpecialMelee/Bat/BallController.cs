using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(End());
    }
    void Update()
    {
        transform.Translate(Vector3.forward * 20 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().health -= 50;
        }
    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
