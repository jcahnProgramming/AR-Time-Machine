using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedVariables : MonoBehaviour
{
    public GameObject Reminder;


    public string buttonPressed = "no_destination";
    public string yearText = "2021";
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
}
