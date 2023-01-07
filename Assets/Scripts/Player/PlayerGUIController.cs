using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerGUIController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Slider healthBar;
    [SerializeField] private TextMeshProUGUI _moneyText;
    public static TextMeshProUGUI moneyText { get; private set; }

    private void Awake()
    {
        moneyText = _moneyText;
    }

    public void Start()
    {
        RefreshMoney();
    }

    private void Update()
    {
        healthBar.value = player.GetComponent<PlayerController>().health;
    }

    public static void RefreshMoney()
    {
        moneyText.text = "$"+PlayerController.money.ToString();
    }
}
