using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public XRReferenceImageLibrary myLibrary;
    //[SerializeField]
    //ARTrackedImageManager m_TrackedImageManager;

    public GameObject Switches, TimePanelInterface, DestinationSelector, TimeSettings;
    public Text year; //should come from date variable (time panel)
    public SavedVariables sv;


    //TIME PANEL VARIABLES

    public bool MilSelected, CentSelected, YearSelected, MonthSelected, DaySelected, HourSelected; //Current state of button logic
    public bool Increasement, Decreasement;
    public int Mil, Cent, Year, Month, Day, Hour; //To store value of user input
    public Text milText, centText, yearText, monthText, dayText, hourText;
    public int Date; //OUTPUT

    //TIME SETTINGS VARIABLES

    public int durationOfTravel;
    public Text displayText;

    public Text LaunchTimeMachineText;
    public GameObject launchPanel;

    private string destination;

    public Camera arCamera;

    public GameObject debugPanel;

    private bool isDebugOn = false;
    public List<string> debugMessages = new List<string>();
    public Text debugSlot;

    void Awake()
    {
        var manager = gameObject.AddComponent<ARTrackedImageManager>();
        manager.referenceLibrary = myLibrary;
        manager.enabled = true;
        NewDebugMessage("awake completed - GameManager");
    }
    // Start is called before the first frame update
    void Start()
    {
        Date = 0;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaceSelector() //jamie's function
    {
        DestinationSelector.SetActive(true);
        year.text = sv.dateText;

    }

    public void SafetySwitches() //EJ's function
    {
        //TURN ON UI
        Switches.SetActive(true);

        //TURN OTHER PANELS OFF
        TimePanelInterface.SetActive(false);
        DestinationSelector.SetActive(false);
        TimeSettings.SetActive(false);

    }

    public void TimePanel() //Mateo's Function
    {
        //TURN ON UI
        TimePanelInterface.SetActive(true);

        //TURN OTHER PANELS OFF
        Switches.SetActive(false);
        DestinationSelector.SetActive(false);
        TimeSettings.SetActive(false);


        //POST-BUTTON LOGIC

        if (MilSelected == true)
        {
            //Debug.Log("Hasta Aqui");
            if (Increasement == true)
            {
                Mil++;

                Increasement = false;
                milText.text = Mil.ToString();
            }
            else if (Decreasement == true)
            {
                Mil--;

                Decreasement = false;
                milText.text = Mil.ToString();
            }
        }



        if (CentSelected == true)
        {
            //Debug.Log("Hasta Aqui");
            if (Increasement == true)
            {
                Cent++;

                Increasement = false;
                centText.text = Cent.ToString();
            }
            else if (Decreasement == true)
            {
                Cent--;

                Decreasement = false;
                centText.text = Cent.ToString();
            }

        }

        if (YearSelected == true)
        {
            //Debug.Log("Hasta Aqui");
            if (Increasement == true)
            {
                Year++;

                Increasement = false;
                yearText.text = Year.ToString();
            }
            else if (Decreasement == true)
            {
                Year--;

                Decreasement = false;
                yearText.text = Year.ToString();
            }

        }

        if (MonthSelected == true)
        {
            //Debug.Log("Hasta Aqui");
            if (Increasement == true)
            {
                Month++;

                Increasement = false;
                monthText.text = Month.ToString();
            }
            else if (Decreasement == true)
            {
                Month--;

                Decreasement = false;
                yearText.text = Year.ToString();
            }

        }

        if (DaySelected == true)
        {
            //Debug.Log("Hasta Aqui");
            if (Increasement == true)
            {
                Day++;

                Increasement = false;
                dayText.text = Day.ToString();
            }
            else if (Decreasement == true)
            {
                Day--;

                Decreasement = false;
                dayText.text = Day.ToString();
            }

        }

        if (HourSelected == true)
        {
            //Debug.Log("Hasta Aqui");
            if (Increasement == true)
            {
                Hour++;

                Increasement = false;
                hourText.text = Hour.ToString();
            }
            else if (Decreasement == true)
            {
                Hour--;

                Decreasement = false;
                hourText.text = Hour.ToString();
            }

        }

    }

    public void TravelDuration() //Asuquo's Function
    {
        //TURN ON UI
        TimeSettings.SetActive(true);

        //TURN OTHER PANELS OFF
        TimePanelInterface.SetActive(false);
        DestinationSelector.SetActive(false);
        Switches.SetActive(false);


        if (durationOfTravel == 1)
        {
            displayText.text = "Slow";


        }

        if (durationOfTravel == 2)
        {
            displayText.text = "Intermediate";


        }

        if (durationOfTravel == 3)
        {
            displayText.text = "Fast";


        }

    }

    public void DebugMessages()
    {
        if (isDebugOn == true)
        {
            isDebugOn = false;
            debugPanel.SetActive(false);
        }
        else if (isDebugOn == false)
        {
            isDebugOn = true;
            debugPanel.SetActive(true);
        }
    }

    public void LaunchTimeMachine()
    {
        LaunchTimeMachineText.text = "Destination Info:\n Mil: " + Mil.ToString() + "\n Cent: " + Cent.ToString() + "\n Year: " + Year.ToString() + "\n Month: " + Month.ToString() + "\n Day: " + Day.ToString() + "\n Hour: " + Hour.ToString() +
                                     "\n Destination: " + destination + "\n Duration: " + durationOfTravel.ToString();
        //tint the camera here


    }

    public void CloseLaunchWindow()
    {
        launchPanel.SetActive(false);
    }

    public void NewDebugMessage(string msg)
    {
        Debug.Log(msg);

        debugMessages.Add(msg);

        //debugMessageList.AddOptions(debugMessages);

        string fullMessage = "\n" + "DEBUG: " + msg;

        debugSlot.text = debugSlot.text + fullMessage;
    }


}
