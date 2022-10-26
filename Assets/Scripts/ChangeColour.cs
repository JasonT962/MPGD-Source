using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour
{
    [SerializeField] GameObject obj;
    void Start()
    {
        obj.GetComponent<Renderer>().material.color = Color.gray;
    }
}
