using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopGUIController : MonoBehaviour
{
    private bool shopOpen = false;

    [SerializeField] private InventoryManager inventory;

    [Header("Shop Items")]
    [SerializeField] private ItemClass[] melee;
    [SerializeField] private ItemClass[] ranged;
    [SerializeField] private ItemClass[] food;

    private int price;

    public void ShopButtonClick()
    {
        if (shopOpen == false)
        {
            shopOpen = true;
            OpenShop();
        }
        else if (shopOpen == true)
        {
            shopOpen = false;
            CloseShop();
        }
    }

    public void OpenShop()
    {
        Transform shopButton = transform.Find("ShopButton");
        Text shopButtonText = shopButton.GetChild(0).GetComponent<Text>();
        shopButtonText.text = "Close Shop";

        GameObject shopPanel = transform.Find("ShopPanel").gameObject;
        shopPanel.SetActive(true);
    }

    public void CloseShop()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Transform shopButton = transform.Find("ShopButton");
        Text shopButtonText = shopButton.GetChild(0).GetComponent<Text>();
        shopButtonText.text = "Open Shop";

        GameObject shopPanel = transform.Find("ShopPanel").gameObject;
        shopPanel.SetActive(false);
    }

    public void SetPrice(int price) // Shop item buttons first set the price then call BuyItem() immediately after
    {
        this.price = price;
    }

    public void BuyItem(ItemClass item)
    {
        if (!(PlayerController.money - price < 0)) // If player has enough  money
        {
            if (!(inventory.Contains(item) == null)) // If player already has the item in inventory
            {
                if (item.isStackable) // If the item is stackable then buy the item
                {
                    inventory.Add(item, 1);
                    PlayerController.money -= price;
                    PlayerGUIController.RefreshMoney();
                }
            }
            else
            {
                inventory.Add(item, 1);
                PlayerController.money -= price;
                PlayerGUIController.RefreshMoney();
            }
        }
    }
}
