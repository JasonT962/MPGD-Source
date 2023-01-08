using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject bigZombie;
    [SerializeField] GameObject medZombie;
    [SerializeField] GameObject fastZombie;

    [SerializeField] GameObject ZombieList;

    public void Spawn(string zombieType)
    {
        if (zombieType == "big")
        {
            Instantiate(bigZombie, transform.position, transform.rotation, ZombieList.transform);
        }
        else if (zombieType == "med")
        {
            Instantiate(medZombie, transform.position, transform.rotation, ZombieList.transform);
        }
        else if (zombieType == "fast")
        {
            Instantiate(fastZombie, transform.position, transform.rotation, ZombieList.transform);
        }
        else
        {
            Debug.Log("Error: Mis-typed zombie type. The options are: big, med and fast");
        }
    }
}
