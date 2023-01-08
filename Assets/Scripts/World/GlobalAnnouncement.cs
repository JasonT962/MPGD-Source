using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlobalAnnouncement : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameText;

    public void Announce(string message)
    {
        gameText.text = message;
    }

    public void Clear()
    {
        gameText.text = "";
    }
}
