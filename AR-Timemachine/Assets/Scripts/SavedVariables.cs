using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedVariables : MonoBehaviour
{
    public GameObject Reminder;


    public string buttonPressed = "no_destination";
    public string yearText = "2021";

    public GameManager gameManagerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GetComponent<GameManager>();
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
    }

    public void AFButtonPressed()
    {
        buttonPressed = "Africa";
        Reminder.SetActive(true);
    }

    public void JPButtonPressed()
    {
        buttonPressed = "Japan";
        Reminder.SetActive(true);
    }

    public void CAButtonPressed()
    {
        buttonPressed = "Canada";
        Reminder.SetActive(true);
    }

    //TIME PANEL


    public void SetMillenium()
    {
        gameManagerScript.MilSelected = true;
        Debug.Log("Millenium Selected!");

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
    }

    public void Decrease()
    {
        gameManagerScript.Decreasement = true;
    }

    public void Set()
    {
        gameManagerScript.Date = (gameManagerScript.Mil * 1000) + (gameManagerScript.Cent * 100) + (gameManagerScript.Year * 1);
        Debug.Log(gameManagerScript.Date);
    }

}
