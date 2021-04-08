using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class ImageTracking : MonoBehaviour
{
    public ARTrackedImageManager ARmanager;
    public XRReferenceImageLibrary myLibrary;
    public XRImageTrackingSubsystem subsystem;
    public bool startScanning = true;
    public Button startBtn;
    public Button NextBtn;
    public Button PreviousBtn;
    public GameObject Steps;
    public Image Correct;
    public Image Incorrect;
    public Image CannotFindImage;
    private int _steps = 0;
    public GameManager manager;
    public Animator anim;
    public GameObject ball;
    public GameObject logoPanel, switchPanel, timePanel, spacePanel, durationPanel;
    public GameObject Reminder;
    public GameObject ARScanImage;

    public GameObject[] indicatorSteps;


    void Awake()
    {
        //TODO: FIX THIS SECTION - JC
        subsystem.imageLibrary = myLibrary;
        subsystem.Start();
    }
    // Start is called before the first frame update
    void Start()
    {
        ARmanager.trackedImagesChanged += ARmanager_trackedImagesChanged;
    }

    private void ARmanager_trackedImagesChanged(ARTrackedImagesChangedEventArgs obj)
    {
        if (startScanning)
        {
            foreach (ARTrackedImage image in obj.added)
            {
                PanelChosen(image.referenceImage.name, image.gameObject.transform);
            }
        }

        if (startScanning)
        {
            foreach (ARTrackedImage image in obj.updated)
            {
                PanelChosen(image.referenceImage.name, image.gameObject.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PanelChosen(string imageName, Transform imagePlace)
    {
        switch (imageName)
        {
            case "logo":
                if (_steps == 0)
                {
                    logoPanel.gameObject.transform.position = imagePlace.position;
                    startScanning = false;
                    logoPanel.SetActive(true);
                    FirstTimeScan();
                }
                break;
            case "switches":
                if (_steps == 1)
                {
                    switchPanel.gameObject.transform.position = imagePlace.position;
                    startScanning = false;
                    StepOne();
                }
                break;
            case "TimePanel":
                if (_steps == 2)
                {
                    timePanel.gameObject.transform.position = imagePlace.position;
                    startScanning = false;
                    StepTwo();
                }
                break;
            case "SpacePanel":
                if (_steps == 3)
                {
                    spacePanel.gameObject.transform.position = imagePlace.position;
                    startScanning = false;
                    StepThree();
                }
                break;
            case "TimeDuration":
                if (_steps == 4)
                {
                    durationPanel.gameObject.transform.position = imagePlace.position;
                    startScanning = false;
                    StepFour();
                }
                break;


            default:
                CannotFindImage.gameObject.SetActive(true);
                break;
        }
    }

    public void CanScan()
    {
        startScanning = true;
    }

    public void NextButton()
    {
        CanScan();
        TurnOffReminders();
        if (_steps >= 5)
        {
            _steps = 5;
        }
        else
        {
            _steps++;
        }
    }

    public void BackButton()
    {
        CanScan();
        TurnOffReminders();
        if (_steps <= 0)
        {
            _steps = 1;
        }
        else
        {
            _steps--;
        }
    }

    public void StartScanning()
    {
        startScanning = true;
        ARScanImage.SetActive(true);
    }

    public void StopScanning()
    {
        startScanning = false;
        ARScanImage.SetActive(false);
    }
    public void FirstTimeScan()
    {
        PreviousBtn.gameObject.SetActive(true);
        NextBtn.gameObject.SetActive(true);
        Steps.SetActive(true);
        startBtn.gameObject.SetActive(false);
    }

    void TurnOffReminders()
    {
        CannotFindImage.gameObject.SetActive(false);
        Incorrect.gameObject.SetActive(false);
        Correct.gameObject.SetActive(false);
        Reminder.gameObject.SetActive(false);
    }

    void StepOne() //EJ's Function
    {
        ball.transform.position = indicatorSteps[_steps].transform.position;
        anim.SetBool("moveBall", true);
        CannotFindImage.gameObject.SetActive(false); //1st step
        Incorrect.gameObject.SetActive(false); //3rd step
        Correct.gameObject.SetActive(true); //2nd step
        manager.SafetySwitches(); //runs EJ's function
        Reminder.SetActive(true);
    }

    void StepTwo() //Mateo's Function
    {
        ball.transform.position = indicatorSteps[_steps].transform.position;
        anim.SetBool("moveBall", true);
        CannotFindImage.gameObject.SetActive(false); //1st step
        Incorrect.gameObject.SetActive(false); //3rd step
        Correct.gameObject.SetActive(true); //2nd step
        manager.TimePanel(); //runs Mateo's function
        Reminder.SetActive(true);
    }

    void StepThree() //Jamie's Function
    {
        ball.transform.position = indicatorSteps[_steps].transform.position;
        anim.SetBool("moveBall", true);
        CannotFindImage.gameObject.SetActive(false); //1st step
        Incorrect.gameObject.SetActive(false); //3rd step
        Correct.gameObject.SetActive(true); //2nd step
        manager.PlaceSelector(); //runs Jamie's function
        Reminder.SetActive(true);
    }

    void StepFour() //Mateo's Function
    {
        ball.transform.position = indicatorSteps[_steps].transform.position;
        anim.SetBool("moveBall", true);
        CannotFindImage.gameObject.SetActive(false); //1st step
        Incorrect.gameObject.SetActive(false); //3rd step
        Correct.gameObject.SetActive(true); //2nd step
        manager.TravelDuration(); //runs Mateo's function
        Reminder.SetActive(true);
    }



    //public void NextButton()
    //{
    //    Reminder.SetActive(false);
    //    for (int i = 0; i < myLibrary.count; i++)
    //    {
    //        if (myLibrary[i].texture == myLibrary[1].texture)
    //        {
    //            if (_steps == 1)
    //            {
    //                ball.transform.position = new Vector2(-395f, 132f);
    //                anim.SetBool("moveBall", true);
    //                CannotFindImage.gameObject.SetActive(false); //1st step
    //                Incorrect.gameObject.SetActive(false); //3rd step
    //                Correct.gameObject.SetActive(true); //2nd step
    //                _steps++;
    //                StopScanning();
    //                manager.SafetySwitches(); //runs EJ's function
    //                Reminder.SetActive(true);
    //            }
    //            else
    //            {
    //                Correct.gameObject.SetActive(false);
    //                CannotFindImage.gameObject.SetActive(false);
    //                Incorrect.gameObject.SetActive(true);
    //            }
    //        }
    //        else if (myLibrary[i].texture == myLibrary[2].texture)
    //        {
    //            if (_steps == 2)
    //            {
    //                ball.transform.position = new Vector2(-395f, 83f);
    //                anim.SetBool("moveBall", true);
    //                CannotFindImage.gameObject.SetActive(false); //1st step
    //                Incorrect.gameObject.SetActive(false); //3rd step
    //                Correct.gameObject.SetActive(true); //2nd step
    //                _steps++;
    //                StopScanning();
    //                manager.TimePanel(); //runs Mateo's function
    //                Reminder.SetActive(true);
    //            }
    //            else
    //            {
    //                Correct.gameObject.SetActive(false);
    //                CannotFindImage.gameObject.SetActive(false);
    //                Incorrect.gameObject.SetActive(true);
    //            }
    //        }
    //        else if (myLibrary[i].texture == myLibrary[3].texture)
    //        {
    //            if (_steps == 3)
    //            {
    //                ball.transform.position = new Vector2(-395f, 29f);
    //                anim.SetBool("moveBall", true);
    //                CannotFindImage.gameObject.SetActive(false); //1st step
    //                Incorrect.gameObject.SetActive(false); //3rd step
    //                Correct.gameObject.SetActive(true); //2nd step
    //                _steps++;
    //                StopScanning();
    //                manager.PlaceSelector(); //runs Jamie's function
    //                Reminder.SetActive(true);
    //            }
    //            else
    //            {
    //                Correct.gameObject.SetActive(false);
    //                CannotFindImage.gameObject.SetActive(false);
    //                Incorrect.gameObject.SetActive(true);
    //            }
    //        }
    //        else if (myLibrary[i].texture == myLibrary[4].texture)
    //        {
    //            if (_steps == 4)
    //            {
    //                ball.transform.position = new Vector2(-395f, -25f);
    //                anim.SetBool("moveBall", true);
    //                CannotFindImage.gameObject.SetActive(false); //1st step
    //                Incorrect.gameObject.SetActive(false); //3rd step
    //                Correct.gameObject.SetActive(true); //2nd step
    //                StopScanning();
    //                manager.TravelDuration(); //runs Mateo's function
    //                Reminder.SetActive(true);
    //            }
    //            else
    //            {
    //                Correct.gameObject.SetActive(false);
    //                CannotFindImage.gameObject.SetActive(false);
    //                Incorrect.gameObject.SetActive(true);
    //            }
    //        }
    //        else if (myLibrary[i].texture == myLibrary[0].texture)
    //        {
    //            CannotFindImage.gameObject.SetActive(false); //first step
    //            Incorrect.gameObject.SetActive(true); //2nd step
    //            _steps++;
    //        }
    //        else
    //        {
    //            Correct.gameObject.SetActive(false);
    //            CannotFindImage.gameObject.SetActive(false);
    //            Incorrect.gameObject.SetActive(true);
    //        }
    //    }

    //}

    //public void BackButton()
    //{
    //    Reminder.SetActive(false);
    //    StartScanning();
    //    for (int i = 0; i < myLibrary.count; i++)
    //    {
    //        if (myLibrary[i].texture == myLibrary[1].texture)
    //        {
    //            if (_steps == 1)
    //            {
    //                ball.transform.position = new Vector2(-395f, 132f);
    //                anim.SetBool("moveBall", true);
    //                CannotFindImage.gameObject.SetActive(false); //1st step
    //                Incorrect.gameObject.SetActive(false); //3rd step
    //                Correct.gameObject.SetActive(true); //2nd step
    //                StopScanning();
    //                manager.SafetySwitches(); //runs EJ's function
    //                Reminder.SetActive(true);
    //            }
    //            else
    //            {
    //                Correct.gameObject.SetActive(false);
    //                CannotFindImage.gameObject.SetActive(false);
    //                Incorrect.gameObject.SetActive(true);
    //            }
    //        }
    //        else if (myLibrary[i].texture == myLibrary[2].texture)
    //        {
    //            if (_steps == 2)
    //            {
    //                ball.transform.position = new Vector2(-395f, 83f);
    //                anim.SetBool("moveBall", true);
    //                CannotFindImage.gameObject.SetActive(false); //1st step
    //                Incorrect.gameObject.SetActive(false); //3rd step
    //                Correct.gameObject.SetActive(true); //2nd step
    //                _steps--;
    //                StopScanning();
    //                manager.TimePanel(); //runs Mateo's function
    //                Reminder.SetActive(true);
    //            }
    //            else
    //            {
    //                Correct.gameObject.SetActive(false);
    //                CannotFindImage.gameObject.SetActive(false);
    //                Incorrect.gameObject.SetActive(true);
    //            }
    //        }
    //        else if (myLibrary[i].texture == myLibrary[3].texture)
    //        {
    //            if (_steps == 3)
    //            {
    //                ball.transform.position = new Vector2(-395f, 29f);
    //                anim.SetBool("moveBall", true);
    //                CannotFindImage.gameObject.SetActive(false); //1st step
    //                Incorrect.gameObject.SetActive(false); //3rd step
    //                Correct.gameObject.SetActive(true); //2nd step
    //                _steps--;
    //                StopScanning();
    //                manager.PlaceSelector(); //runs Jamie's function
    //                Reminder.SetActive(true);
    //            }
    //            else
    //            {
    //                Correct.gameObject.SetActive(false);
    //                CannotFindImage.gameObject.SetActive(false);
    //                Incorrect.gameObject.SetActive(true);
    //            }
    //        }
    //        else if (myLibrary[i].texture == myLibrary[4].texture)
    //        {
    //            if (_steps == 4)
    //            {
    //                ball.transform.position = new Vector2(-395f, -25f);
    //                anim.SetBool("moveBall", true);
    //                CannotFindImage.gameObject.SetActive(false); //1st step
    //                Incorrect.gameObject.SetActive(false); //3rd step
    //                Correct.gameObject.SetActive(true); //2nd step
    //                _steps--;
    //                StopScanning();
    //                manager.TravelDuration(); //runs Mateo's function
    //                Reminder.SetActive(true);
    //            }
    //            else
    //            {
    //                Correct.gameObject.SetActive(false);
    //                CannotFindImage.gameObject.SetActive(false);
    //                Incorrect.gameObject.SetActive(true);
    //            }
    //        }
    //        else if (myLibrary[i].texture == myLibrary[0].texture)
    //        {
    //            CannotFindImage.gameObject.SetActive(false); //first step
    //            Incorrect.gameObject.SetActive(true); //2nd step
    //        }
    //        else
    //        {
    //            Correct.gameObject.SetActive(false);
    //            CannotFindImage.gameObject.SetActive(false);
    //            Incorrect.gameObject.SetActive(true);
    //        }
    //    }
    //}
}
