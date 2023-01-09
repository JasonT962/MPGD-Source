using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GlobalAnnouncement announcement;

    [SerializeField] private Spawner spawner1;
    [SerializeField] private Spawner spawner2;
    [SerializeField] private Spawner spawner3;
    [SerializeField] private Spawner spawner4;

    [SerializeField] private GameObject zombieContainer;

    private bool triggerNext = false;

    private bool wave1 = true;
    private bool wave2 = false;
    private bool wave3 = false;
    private bool wave4 = false;
    private bool wave5 = false;
    private bool wave6 = false;
    private bool wave7 = false;
    private bool wave8 = false;
    private bool wave9 = false;
    private bool wave10 = false;
    private bool win = false;

    private void Start()
    {
        StartCoroutine(Wave1());
    }

    void Update()
    {
        if (triggerNext == true)
        {
            triggerNext = false;
            PlayerController.money += 100;
            PlayerGUIController.RefreshMoney();

            if (wave1 == false)
            {
                wave1 = true;
                StartCoroutine(Wave1());
            }
            else if (wave2 == false)
            {
                wave2 = true;
                StartCoroutine(Wave2());
            }
            else if (wave3 == false)
            {
                wave3 = true;
                StartCoroutine(Wave3());
            }
            else if (wave4 == false)
            {
                wave4 = true;
                StartCoroutine(Wave4());
            }
            else if (wave5 == false)
            {
                wave5 = true;
                StartCoroutine(Wave5());
            }
            else if (wave6 == false)
            {
                wave6 = true;
                StartCoroutine(Wave6());
            }
            else if (wave7 == false)
            {
                wave7 = true;
                StartCoroutine(Wave7());
            }
            else if (wave8 == false)
            {
                wave8 = true;
                StartCoroutine(Wave8());
            }
            else if (wave9 == false)
            {
                wave9 = true;
                StartCoroutine(Wave9());
            }
            else if (wave10 == false)
            {
                wave10 = true;
                StartCoroutine(Wave10());
            }
            else if (win == false)
            {
                win = true;
                StartCoroutine(Win());
            }
        }
    }

    IEnumerator Wave1()
    {
        yield return new WaitForSeconds(3);

        announcement.Announce("[Zombie King]: Hmm? What's this?");

        yield return new WaitForSeconds(5);

        announcement.Announce("[Zombie King]: A mortal wants to challenge my throne?");

        yield return new WaitForSeconds(5);

        announcement.Announce("[Zombie King]: Well, so be it. We'll see how strong you are before my army");

        yield return new WaitForSeconds(6);

        announcement.Announce("[Zombie King]: Let's start with something easy");

        yield return new WaitForSeconds(5);

        int enemiesRemaining = 1;
        spawner1.Spawn("med");
        enemiesRemaining -= 1;
        while (enemiesRemaining + zombieContainer.transform.childCount > 0)
        {
            announcement.Announce("Wave 1 || Enemies Remaining: " + (enemiesRemaining + zombieContainer.transform.childCount));
            yield return new WaitForSeconds(0.1f);
        }

        triggerNext = true;
    }

    IEnumerator Wave2()
    {
        announcement.Announce("[Zombie King]: I see...");
        yield return new WaitForSeconds(5);
        announcement.Announce("[Zombie King]: So you use those kind of weapons to fight");
        yield return new WaitForSeconds(5);
        announcement.Announce("[Zombie King]: Interesting, let's increase the difficulty shall we?");
        yield return new WaitForSeconds(5);

        int enemiesRemaining = 10;
        spawner1.Spawn("med");
        spawner2.Spawn("med");
        spawner3.Spawn("med");
        spawner4.Spawn("med");
        enemiesRemaining -= 4;

        while (enemiesRemaining + zombieContainer.transform.childCount > 0)
        {
            announcement.Announce("Wave 2 || Enemies Remaining: " + (enemiesRemaining + zombieContainer.transform.childCount));
            yield return new WaitForSeconds(0.1f);

            if (zombieContainer.transform.childCount == 0 && enemiesRemaining > 3)
            {
                spawner1.Spawn("med");
                spawner2.Spawn("med");
                spawner3.Spawn("med");
                spawner4.Spawn("med");
                enemiesRemaining -= 4;
            }
            else if (zombieContainer.transform.childCount == 0 && enemiesRemaining == 2)
            {
                spawner1.Spawn("med");
                spawner1.Spawn("med");
                enemiesRemaining -= 2;
            }
        }

        triggerNext = true;
    }

    IEnumerator Wave3()
    {
        announcement.Announce("[Zombie King]: Hmm...");
        yield return new WaitForSeconds(3);
        announcement.Announce("[Zombie King]: You're stronger than I thought");
        yield return new WaitForSeconds(4);
        announcement.Announce("[Zombie King]: But unfortunately for you those were just basic zombies");
        yield return new WaitForSeconds(5);
        announcement.Announce("[Zombie King]: Let's see how you deal with fast ones shall we?");
        yield return new WaitForSeconds(5);

        int enemiesRemaining = 15;
        spawner1.Spawn("fast");
        spawner1.Spawn("fast");
        spawner2.Spawn("fast");
        spawner3.Spawn("fast");
        spawner4.Spawn("fast");
        enemiesRemaining -= 5;

        while (enemiesRemaining + zombieContainer.transform.childCount > 0)
        {
            announcement.Announce("Wave 3 || Enemies Remaining: " + (enemiesRemaining + zombieContainer.transform.childCount));
            yield return new WaitForSeconds(0.1f);

            if (zombieContainer.transform.childCount == 0 && enemiesRemaining == 10)
            {
                for (int i = 0; i < 8; i++)
                {
                    spawner1.Spawn("fast");
                }
                enemiesRemaining -= 8;
            }

            if (zombieContainer.transform.childCount == 0 && enemiesRemaining == 2)
            {
                spawner2.Spawn("fast");
                spawner4.Spawn("fast");
                enemiesRemaining -= 2;
            }
        }

        triggerNext = true;
    }

    IEnumerator Wave4()
    {
        announcement.Announce("[Zombie King]: Wha..t?");
        yield return new WaitForSeconds(3);
        announcement.Announce("[Zombie King]: You actually defeated that?");
        yield return new WaitForSeconds(4);
        announcement.Announce("[Zombie King]: I must say I am most impressed");
        yield return new WaitForSeconds(4);
        announcement.Announce("[Zombie King]: How about we try some tankier zombies?");
        yield return new WaitForSeconds(4);

        int enemiesRemaining = 25;
        for (int i = 0; i < 6; i++)
        {
            spawner1.Spawn("big");
            spawner2.Spawn("big");
            spawner3.Spawn("big");
            spawner4.Spawn("big");
        }
        spawner1.Spawn("big");
        enemiesRemaining -= 25;

        while (enemiesRemaining + zombieContainer.transform.childCount > 0)
        {
            announcement.Announce("Wave 4 || Enemies Remaining: " + (enemiesRemaining + zombieContainer.transform.childCount));
            yield return new WaitForSeconds(0.1f);
        }

        triggerNext = true;
    }

    IEnumerator Wave5()
    {
        announcement.Announce("[Zombie King]: Hmm");
        yield return new WaitForSeconds(3);
        announcement.Announce("[Zombie King]: Whatever, I didn't think that was going to work anyway");
        yield return new WaitForSeconds(5);
        announcement.Announce("[Zombie King]: But it looks like swarming you seems to be very effective");
        yield return new WaitForSeconds(5);
        announcement.Announce("[Zombie King]: This is going to take a chunk out of my army but here goes nothing");
        yield return new WaitForSeconds(6);

        int enemiesRemaining = 30;
        for (int i = 0; i < 2; i++)
        {
            spawner1.Spawn("big");
            spawner2.Spawn("big");
            spawner3.Spawn("big");
            spawner4.Spawn("big");
        }
        for (int i = 0; i < 3; i++)
        {
            spawner1.Spawn("med");
            spawner2.Spawn("med");
            spawner3.Spawn("med");
            spawner4.Spawn("med");
        }
        for (int i = 0; i < 2; i++)
        {
            spawner1.Spawn("fast");
            spawner2.Spawn("fast");
            spawner3.Spawn("fast");
            spawner4.Spawn("fast");
        }

        spawner1.Spawn("big");
        spawner3.Spawn("big");

        enemiesRemaining -= 30;

        while (enemiesRemaining + zombieContainer.transform.childCount > 0)
        {
            announcement.Announce("Wave 5 || Enemies Remaining: " + (enemiesRemaining + zombieContainer.transform.childCount));
            yield return new WaitForSeconds(0.1f);
        }

        triggerNext = true;
    }

    IEnumerator Wave6()
    {
        announcement.Announce("[Zombie King]: THIS IS ABSURD");
        yield return new WaitForSeconds(3);
        announcement.Announce("[Zombie King]: HOW ARE YOU DOING THIS?");
        yield return new WaitForSeconds(5);
        announcement.Announce("[Zombie King]: You must be cheating somehow");
        yield return new WaitForSeconds(5);
        announcement.Announce("[Zombie King]: That's it, I'm going to go all out from here");
        yield return new WaitForSeconds(6);

        int enemiesRemaining = 50;
        for (int i = 0; i < 6; i++)
        {
            spawner1.Spawn("big");
            spawner2.Spawn("big");
            spawner3.Spawn("big");
            spawner4.Spawn("big");
        }

        spawner1.Spawn("big");

        enemiesRemaining -= 25;

        while (enemiesRemaining + zombieContainer.transform.childCount > 0)
        {
            announcement.Announce("Wave 6 || Enemies Remaining: " + (enemiesRemaining + zombieContainer.transform.childCount));
            yield return new WaitForSeconds(0.1f);

            if (zombieContainer.transform.childCount == 0 && enemiesRemaining == 25)
            {
                for (int i = 0; i < 6; i++)
                {
                    spawner1.Spawn("big");
                    spawner2.Spawn("big");
                    spawner3.Spawn("big");
                    spawner4.Spawn("big");
                }

                spawner4.Spawn("big");

                enemiesRemaining -= 25;
            }
        }

        triggerNext = true;
    }

    IEnumerator Wave7()
    {
        announcement.Announce("[Zombie King]: THE BIG ZOMBIES ARE SO USELESS");
        yield return new WaitForSeconds(3);
        announcement.Announce("[Zombie King]: WHY ARE THEY SO SLOW, THEY CAN'T DO ANYTHING");
        yield return new WaitForSeconds(5);
        announcement.Announce("[Zombie King]: Wait...");
        yield return new WaitForSeconds(3);
        announcement.Announce("[Zombie King]: If I send out all of my fast zombies, there's nothing you can do!");
        yield return new WaitForSeconds(6);

        int enemiesRemaining = 50;
        for (int i = 0; i < 6; i++)
        {
            spawner1.Spawn("fast");
            spawner2.Spawn("fast");
            spawner3.Spawn("fast");
            spawner4.Spawn("fast");
        }

        spawner1.Spawn("fast");

        enemiesRemaining -= 25;

        while (enemiesRemaining + zombieContainer.transform.childCount > 0)
        {
            announcement.Announce("Wave 7 || Enemies Remaining: " + (enemiesRemaining + zombieContainer.transform.childCount));
            yield return new WaitForSeconds(0.1f);

            if (zombieContainer.transform.childCount == 0 && enemiesRemaining == 25)
            {
                for (int i = 0; i < 6; i++)
                {
                    spawner1.Spawn("fast");
                    spawner2.Spawn("fast");
                    spawner3.Spawn("fast");
                    spawner4.Spawn("fast");
                }

                spawner4.Spawn("fast");

                enemiesRemaining -= 25;
            }
        }

        triggerNext = true;
    }

    IEnumerator Wave8()
    {
        announcement.Announce("[Zombie King]: CURSE YOU!!!");
        yield return new WaitForSeconds(3);
        announcement.Announce("[Zombie King]: YOU'VE WIPED OUT MOST OF MY ARMY");
        yield return new WaitForSeconds(5);
        announcement.Announce("[Zombie King]: ARGGHH, Fine whatever. I admit you're strong");
        yield return new WaitForSeconds(5);
        announcement.Announce("[Zombie King]: Here's a little souvenir for you while I go prepare to defeat you myself...");
        yield return new WaitForSeconds(6);

        int enemiesRemaining = 100;
        for (int i = 0; i < 25; i++)
        {
            spawner1.Spawn("med");
            spawner2.Spawn("med");
            spawner3.Spawn("med");
            spawner4.Spawn("med");
        }

        enemiesRemaining -= 100;

        while (enemiesRemaining + zombieContainer.transform.childCount > 0)
        {
            announcement.Announce("Wave 8 || Enemies Remaining: " + (enemiesRemaining + zombieContainer.transform.childCount));
            yield return new WaitForSeconds(0.1f);
        }

        triggerNext = true;
    }

    IEnumerator Wave9()
    {

        int enemiesRemaining = 2;
        spawner2.Spawn("med");
        spawner4.Spawn("med");

        enemiesRemaining -= 2;

        while (enemiesRemaining + zombieContainer.transform.childCount > 0)
        {
            announcement.Announce("Wave 9 || Enemies Remaining: " + (enemiesRemaining + zombieContainer.transform.childCount));
            yield return new WaitForSeconds(0.1f);
        }

        triggerNext = true;
    }

    IEnumerator Wave10()
    {
        announcement.Announce("[Zombie King]: I'm back");
        yield return new WaitForSeconds(3);
        announcement.Announce("[Zombie King]: Looks like my whole army couldn't kill you");
        yield return new WaitForSeconds(5);
        announcement.Announce("[Zombie King]: Fine, I'll do it myself");
        yield return new WaitForSeconds(5);

        int enemiesRemaining = 1;

        spawner1.Spawn("king");

        enemiesRemaining -= 1;

        while (enemiesRemaining + zombieContainer.transform.childCount > 0)
        {
            announcement.Announce("Boss Fight: [The King Zombie]");
            yield return new WaitForSeconds(0.1f);
        }

        triggerNext = true;
    }

    IEnumerator Win()
    {
        announcement.Announce("[Zombie King]: ARRGHHH, How could this be???");
        yield return new WaitForSeconds(5);
        announcement.Announce("[Zombie King]: How could I lose to the likes of you...");
        yield return new WaitForSeconds(5);
        announcement.Announce("[System]: Congratulations, you have sucessfully defeated the Zombie King");
        yield return new WaitForSeconds(5);
        announcement.Announce("[System]: You have reached the end of the game, we plan on adding more levels in the future");
        yield return new WaitForSeconds(6);
        announcement.Announce("[System]: Thanks for playing!");
        yield return new WaitForSeconds(4);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(3);
    }
}
