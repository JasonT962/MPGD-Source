using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DayCounter : MonoBehaviour
{
    [SerializeField] private GameObject timeController;
    [SerializeField] private TextMeshProUGUI dayCounterText;

    private string currentTime;

    private bool changed = false;

    private int counter;

    void Start()
    {
        counter = 1;
        dayCounterText.text = "Day: " + counter;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = timeController.GetComponent<TimeController>().currentTime.ToString("HH:mm");

        if (currentTime == "00:00" && changed == false)
        {
            counter += 1;
            changed = true;
        }
        else if (currentTime != "00:00")
        {
            changed = false;
        }

        dayCounterText.text = "Day: " + counter;

        if (counter == 10)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(3);
        }
    }
}
