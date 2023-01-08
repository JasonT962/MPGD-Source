using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject globalAnnouncement;
    private GlobalAnnouncement announcement;

    void Start()
    {
        announcement = globalAnnouncement.GetComponent<GlobalAnnouncement>();
    }

    void Update()
    {
        
    }
}
