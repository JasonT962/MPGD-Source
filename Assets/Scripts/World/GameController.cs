using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject globalAnnouncement;
    [SerializeField] private Spawner spawner1;
    [SerializeField] private Spawner spawner2;
    [SerializeField] private Spawner spawner3;
    [SerializeField] private Spawner spawner4;

    private GlobalAnnouncement announcement;

    void Start()
    {
        announcement = globalAnnouncement.GetComponent<GlobalAnnouncement>();
    }

    void Update()
    {

    }
}
