using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    [SerializeField] private GameObject explosion;

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
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
