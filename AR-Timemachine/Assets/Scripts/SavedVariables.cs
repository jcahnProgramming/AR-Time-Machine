using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedVariables : MonoBehaviour
{
    public GameObject Reminder;

    //Place Selector
    public string buttonPressed = "no_destination";
    public string dateText = "2021";

    //Game Manager Script
    public GameManager gameManagerScript;

    int count; //Time Settings

    // SWITCHES
    public bool switchLeftOn, switchRightOn;


    //AUDIO MANAGER
    AudioSource Source;
    public AudioClip [] sfx; //0 = button pressed, 1 = Ready, 2 = increase, 3 = decrease, 4 = process finished!;

    //UI Elements

    public string durationSpeed = "";
    
    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GetComponent<GameManager>();
        count = 0;
        Source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //PLACE SELECTOR


    public void USButtonPressed()
    {
        buttonPressed = "united_states";
        Reminder.SetActive(true);
        Source.clip = sfx[0];
        Source.Play();
        gameManagerScript.NewDebugMessage("after us button pressed");
    }

    public void AFButtonPressed()
    {
        buttonPressed = "Africa";
        Reminder.SetActive(true);
        Source.clip = sfx[0];
        Source.Play();
        gameManagerScript.NewDebugMessage("after africa button pressed");

    }

    public void JPButtonPressed()
    {
        buttonPressed = "Japan";
        Reminder.SetActive(true);
        Source.clip = sfx[0];
        Source.Play();
        gameManagerScript.NewDebugMessage("after japan button pressed");

    }

    public void CAButtonPressed()
    {
        buttonPressed = "Canada";
        Reminder.SetActive(true);
        Source.clip = sfx[0];
        Source.Play();
        gameManagerScript.NewDebugMessage("after canada button pressed");

    }

    // SWITCHES
    public void ToggleLeftSwitch()
    {
        switchLeftOn = !switchLeftOn;
    }

    public void ToggleRightSwitch()
    {
        switchRightOn = !switchRightOn;
    }

    //TIME PANEL


    public void SetMillenium()
    {
        gameManagerScript.MilSelected = true;
        Debug.Log("Millenium Selected!");
        Source.clip = sfx[0];
        Source.Play();


        //Set everything else to false
        gameManagerScript.CentSelected = false;
        gameManagerScript.YearSelected = false;
        gameManagerScript.MonthSelected = false;
        gameManagerScript.DaySelected = false;
        gameManagerScript.HourSelected = false;

    }

    public void SetCentury()
    {
        gameManagerScript.CentSelected = true;
        Debug.Log("Century Selected!");
        Source.clip = sfx[0];
        Source.Play();


        //Set everything else to false
        gameManagerScript.MilSelected = false;
        gameManagerScript.YearSelected = false;
        gameManagerScript.MonthSelected = false;
        gameManagerScript.DaySelected = false;
        gameManagerScript.HourSelected = false;

    }

    public void SetYear()
    {
        gameManagerScript.YearSelected = true;
        Debug.Log("Year Selected!");
        Source.clip = sfx[0];
        Source.Play();


        //Set everything else to false
        gameManagerScript.MilSelected = false;
        gameManagerScript.CentSelected = false;
        gameManagerScript.MonthSelected = false;
        gameManagerScript.DaySelected = false;
        gameManagerScript.HourSelected = false;



    }

    public void SetMonth()
    {
        gameManagerScript.MonthSelected = true;
        Debug.Log("Month Selected!");
        Source.clip = sfx[0];
        Source.Play();


        //Set everything else to false
        gameManagerScript.MilSelected = false;
        gameManagerScript.CentSelected = false;
        gameManagerScript.YearSelected = false;
        gameManagerScript.DaySelected = false;
        gameManagerScript.HourSelected = false;

    }

    public void SetDay()
    {
        gameManagerScript.DaySelected = true;
        Debug.Log("Day Selected!");
        Source.clip = sfx[0];
        Source.Play();


        //Set everything else to false
        gameManagerScript.MilSelected = false;
        gameManagerScript.CentSelected = false;
        gameManagerScript.YearSelected = false;
        gameManagerScript.MonthSelected = false;
        gameManagerScript.HourSelected = false;

    }

    public void SetHour()
    {
        gameManagerScript.HourSelected = true;
        Debug.Log("Hour Selected!");
        Source.clip = sfx[0];
        Source.Play();


        //Set everything else to false
        gameManagerScript.MilSelected = false;
        gameManagerScript.YearSelected = false;
        gameManagerScript.CentSelected = false;
        gameManagerScript.MonthSelected = false;
        gameManagerScript.DaySelected = false;


    }

    public void Increase()
    {
        gameManagerScript.Increasement = true;
        Source.clip = sfx[2];
        Source.Play();
    }

    public void Decrease()
    {
        gameManagerScript.Decreasement = true;
        Source.clip = sfx[3];
        Source.Play();
    }

    public void Set()
    {
        gameManagerScript.Date = (gameManagerScript.Mil * 1000) + (gameManagerScript.Cent * 100) + (gameManagerScript.Year * 1);
        Debug.Log(gameManagerScript.Date);
        dateText = gameManagerScript.Date.ToString(); //Sends date to year text (Jamie's Func)
        Source.clip = sfx[1];
        Source.Play();
    }

    //TIME SETTINGS

    public void DurationOfTravel()
    {
        Source.clip = sfx[0];
        Source.Play();

        count++;

        if (count != 0)
        {
            gameManagerScript.durationOfTravel = count;

            if (count == 3)
            {
                count = 0;
            }
        }

    }

    public void Save()
    {
        // Everything is ready
        Source.clip = sfx[4];
        Source.Play();

        durationSpeed = gameManagerScript.displayText.text;

        gameManagerScript.LaunchTimeMachine();
        gameManagerScript.NewDebugMessage("after savedvariables script ran Save() function");
    }

   

}
