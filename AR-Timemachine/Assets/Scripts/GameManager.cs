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

    public GameObject DestinationSelector;
    public Text year;
    public SavedVariables sv;
    public Text travelDur;
    public Button saveDurationBTN;


    //TIME PANEL VARIABLES

    public bool MilSelected, CentSelected, YearSelected, MonthSelected, DaySelected, HourSelected; //Current state of button logic
    public bool Increasement, Decreasement;
    public int Mil, Cent, Year, Month, Day, Hour; //To store value of user input
    public Text milText, centText, yearText, monthText, dayText, hourText;
    public int Date; //OUTPUT




    void Awake()
    {
        var manager = gameObject.AddComponent<ARTrackedImageManager>();
        manager.referenceLibrary = myLibrary;
        manager.enabled = true;
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

    public void PlaceSelector() //Jamie's function
    {
        DestinationSelector.SetActive(true);
        year.text = sv.yearText;
    }

    public void SafetySwitches() //EJ's function
    {

    }

    public void TimePanel() //Mateo's Function
    {
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
        
    }
}
