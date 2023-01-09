using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour
{
    [SerializeField] private GlobalAnnouncement announcement;

    [SerializeField] private Spawner spawner;

    [SerializeField] private GameObject zombieContainer;

    private bool triggerNext = false;

    private void Start()
    {
        StartCoroutine(Introduction());
    }

    void Update()
    {
        if (triggerNext == true)
        {
            triggerNext = false;
        }
    }

    IEnumerator Introduction()
    {
        yield return new WaitForSeconds(3);
        announcement.Announce("[System]: Hi, and welcome to the tutorial");
        yield return new WaitForSeconds(4);
        announcement.Announce("[System]: Let's get started with the basics");
        yield return new WaitForSeconds(4);
        announcement.Announce("[System]: You can use the WASD keys to move around and shift to sprint");
        yield return new WaitForSeconds(10);
        announcement.Announce("[System]: Use your 12345 keys to switch between items in your hotbar");
        yield return new WaitForSeconds(10);
        announcement.Announce("[System]: Press I to open/close your inventory, here you can move around your items");
        yield return new WaitForSeconds(10);
        announcement.Announce("[System]: Clicking while holding any item will use it, food items restore hp upon use");
        yield return new WaitForSeconds(10);
        announcement.Announce("[System]: But don't worry, you slowly regenerate hp over time and you can also buy more too");
        yield return new WaitForSeconds(10);
        announcement.Announce("[System]: Holding right click will zoom in your camera and forces your character to look at that direction");
        yield return new WaitForSeconds(10);
        announcement.Announce("[System]: Ok let's move onto the shop");
        yield return new WaitForSeconds(4);
        PlayerController.money += 10;
        PlayerGUIController.RefreshMoney();
        announcement.Announce("[System]: I have given you 10 money to start with. Next I'll go through how to open the shop");
        yield return new WaitForSeconds(10);
        announcement.Announce("[System]: First, press tab so you can move your mouse freely, then click on the shop to open it");
        yield return new WaitForSeconds(10);
        announcement.Announce("[System]: After you've opened the shop, try and buy an apple");

        while (PlayerController.money != 0)
        {
            yield return new WaitForSeconds(0.5f);
        }

        announcement.Announce("[System]: Well done, you have successfully bought your first item");
        yield return new WaitForSeconds(6);
        announcement.Announce("[System]: Now let's move on to combat");
        yield return new WaitForSeconds(5);
        announcement.Announce("[System]: In this game, zombies spawn in waves and you have to kill all of them to move on to the next wave");
        yield return new WaitForSeconds(10);
        spawner.Spawn("med");
        announcement.Announce("[System]: I have spawned a zombie, but don't worry, this zombie won't chase you, but it will still hurt if you touch it so be careful");
        yield return new WaitForSeconds(10);
        announcement.Announce("[System]: Now, I want you to kill the zombie, in any way you like");
        
        while (zombieContainer.transform.childCount != 0)
        {
            yield return new WaitForSeconds(0.5f);
        }

        announcement.Announce("[System]: Well done, you have defeated your first zombie");
        yield return new WaitForSeconds(7);
        announcement.Announce("[System]: You have reached the end of the tutorial");
        yield return new WaitForSeconds(5);
        announcement.Announce("[System]: Congratulations, and I hope you have a good time playing this game. You will now be transported back to the main menu");
        yield return new WaitForSeconds(10);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(0);
    }
}
