using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSelector : MonoBehaviour
{

    //TIME PANEL VARIABLES

    public bool MilSelected, CentSelected, YearSelected, MonthSelected, DaySelected, HourSelected; //Current state of button logic
    bool Increasement, Decreasement;
    public int Mil, Cent, Year, Month, Day, Hour; //To store value of user input
    public Text milText, centText, yearText, monthText, dayText, hourText;
    public int Date; //OUTPUT
    

    // Start is called before the first frame update
    void Start()
    {
        Date = 0;
    }

    // Update is called once per frame
    void Update()
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
    

    //METHODS


    public void SetMillenium()
    {
        MilSelected = true;
        Debug.Log("Millenium Selected!");

        //Set everything else to false
        CentSelected = false;
        YearSelected = false;
        MonthSelected = false;
        DaySelected = false;
        HourSelected = false;

    }

    public void SetCentury()
    {
        CentSelected = true;
        Debug.Log("Century Selected!");

        //Set everything else to false
        MilSelected = false;
        YearSelected = false;
        MonthSelected = false;
        DaySelected = false;
        HourSelected = false;

    }

    public void SetYear()
    {
        YearSelected = true;
        Debug.Log("Year Selected!");

        //Set everything else to false
        MilSelected = false;
        CentSelected = false;
        MonthSelected = false;
        DaySelected = false;
        HourSelected = false;

        

    }

    public void SetMonth()
    {
        MonthSelected = true;
        Debug.Log("Month Selected!");

        //Set everything else to false
        MilSelected = false;
        CentSelected = false;
        YearSelected = false;
        DaySelected = false;
        HourSelected = false;

    }

    public void SetDay()
    {
        DaySelected = true;
        Debug.Log("Day Selected!");

        //Set everything else to false
        MilSelected = false;
        CentSelected = false;
        YearSelected = false;
        MonthSelected = false;
        HourSelected = false;

    }

    public void SetHour()
    {
        HourSelected = true;
        Debug.Log("Hour Selected!");

        //Set everything else to false
        MilSelected = false;
        YearSelected = false;
        CentSelected = false;
        MonthSelected = false;
        DaySelected = false;
        

    }

    public void Increase()
    {
        Increasement = true;
    }

    public void Decrease()
    {
        Decreasement = true;
    }

    public void Set()
    {
        Date = (Mil * 1000) + (Cent * 100) + (Year * 1);
        Debug.Log(Date);
    }

   
}
