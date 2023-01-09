using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject bigZombie;
    [SerializeField] GameObject medZombie;
    [SerializeField] GameObject fastZombie;
    [SerializeField] GameObject kingZombie;

    [SerializeField] GameObject zombieContainer;

    public void Spawn(string zombieType)
    {
        if (zombieType == "big")
        {
            Instantiate(bigZombie, transform.position, transform.rotation, zombieContainer.transform);
        }
        else if (zombieType == "med")
        {
            Instantiate(medZombie, transform.position, transform.rotation, zombieContainer.transform);
        }
        else if (zombieType == "fast")
        {
            Instantiate(fastZombie, transform.position, transform.rotation, zombieContainer.transform);
        }
        else if (zombieType == "king")
        {
            Instantiate(kingZombie, transform.position, transform.rotation, zombieContainer.transform);
        }
        else
        {
            Debug.Log("Error: Mis-typed zombie type. The options are: big, med and fast");
        }
    }
}
