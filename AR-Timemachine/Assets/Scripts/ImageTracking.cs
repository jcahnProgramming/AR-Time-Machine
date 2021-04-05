using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class ImageTracking : MonoBehaviour
{
    //public ARTrackedImageManager manager;
    public XRReferenceImageLibrary myLibrary;
    public XRImageTrackingSubsystem subsystem;
    public bool startScanning = false;
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
    public GameObject logoPanel;
    public GameObject Reminder;
    public GameObject ARScanImage;


    void Awake()
    {
        //TODO: FIX THIS SECTION - JC
        subsystem.imageLibrary = myLibrary;
        subsystem.Start();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ScanForLogo()
    {
        if (myLibrary[4].texture)
        {
            StopScanning();
            logoPanel.SetActive(true);
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
        ball.transform.position = new Vector2(-395f, 194f);
        StartScanning();
        ScanForLogo();
        PreviousBtn.gameObject.SetActive(true);
        NextBtn.gameObject.SetActive(true);
        Steps.SetActive(true);
        _steps++;
        startBtn.gameObject.SetActive(false);
    }

    public void NextButton()
    {
        Reminder.SetActive(false);

        StartScanning();
        for (int i = 0; i < myLibrary.count; i++)
        {
            if (myLibrary[i].texture == myLibrary[1].texture)
            {
                if (_steps == 1)
                {
                    ball.transform.position = new Vector2(-395f, 132f);
                    anim.SetBool("moveBall", true);
                    CannotFindImage.gameObject.SetActive(false); //1st step
                    Incorrect.gameObject.SetActive(false); //3rd step
                    Correct.gameObject.SetActive(true); //2nd step
                    _steps++;
                    StopScanning();
                    manager.SafetySwitches(); //runs EJ's function
                    Reminder.SetActive(true);
                }
                else
                {
                    Correct.gameObject.SetActive(false);
                    CannotFindImage.gameObject.SetActive(false);
                    Incorrect.gameObject.SetActive(true);
                }
            }
            else if (myLibrary[i].texture == myLibrary[2].texture)
            {
                if (_steps == 2)
                {
                    ball.transform.position = new Vector2(-395f, 83f);
                    anim.SetBool("moveBall", true);
                    CannotFindImage.gameObject.SetActive(false); //1st step
                    Incorrect.gameObject.SetActive(false); //3rd step
                    Correct.gameObject.SetActive(true); //2nd step
                    _steps++;
                    StopScanning();
                    manager.TimePanel(); //runs Mateo's function
                    Reminder.SetActive(true);
                }
                else
                {
                    Correct.gameObject.SetActive(false);
                    CannotFindImage.gameObject.SetActive(false);
                    Incorrect.gameObject.SetActive(true);
                }
            }
            else if (myLibrary[i].texture == myLibrary[3].texture)
            {
                if (_steps == 3)
                {
                    ball.transform.position = new Vector2(-395f, 29f);
                    anim.SetBool("moveBall", true);
                    CannotFindImage.gameObject.SetActive(false); //1st step
                    Incorrect.gameObject.SetActive(false); //3rd step
                    Correct.gameObject.SetActive(true); //2nd step
                    _steps++;
                    StopScanning();
                    manager.PlaceSelector(); //runs Jamie's function
                    Reminder.SetActive(true);
                }
                else
                {
                    Correct.gameObject.SetActive(false);
                    CannotFindImage.gameObject.SetActive(false);
                    Incorrect.gameObject.SetActive(true);
                }
            }
            else if (myLibrary[i].texture == myLibrary[4].texture)
            {
                if (_steps == 4)
                {
                    ball.transform.position = new Vector2(-395f, -25f);
                    anim.SetBool("moveBall", true);
                    CannotFindImage.gameObject.SetActive(false); //1st step
                    Incorrect.gameObject.SetActive(false); //3rd step
                    Correct.gameObject.SetActive(true); //2nd step
                    StopScanning();
                    manager.TravelDuration(); //runs Mateo's function
                    Reminder.SetActive(true);
                }
                else
                {
                    Correct.gameObject.SetActive(false);
                    CannotFindImage.gameObject.SetActive(false);
                    Incorrect.gameObject.SetActive(true);
                }
            }
            else if (myLibrary[i].texture == myLibrary[0].texture)
            {
                CannotFindImage.gameObject.SetActive(false); //first step
                Incorrect.gameObject.SetActive(true); //2nd step
                _steps++;
            }
            else
            {
                Correct.gameObject.SetActive(false);
                CannotFindImage.gameObject.SetActive(false);
                Incorrect.gameObject.SetActive(true);
            }
        }

    }

    public void BackButton()
    {
        Reminder.SetActive(false);
        StartScanning();
        for (int i = 0; i < myLibrary.count; i++)
        {
            if (myLibrary[i].texture == myLibrary[1].texture)
            {
                if (_steps == 1)
                {
                    ball.transform.position = new Vector2(-395f, 132f);
                    anim.SetBool("moveBall", true);
                    CannotFindImage.gameObject.SetActive(false); //1st step
                    Incorrect.gameObject.SetActive(false); //3rd step
                    Correct.gameObject.SetActive(true); //2nd step
                    StopScanning();
                    manager.SafetySwitches(); //runs EJ's function
                    Reminder.SetActive(true);
                }
                else
                {
                    Correct.gameObject.SetActive(false);
                    CannotFindImage.gameObject.SetActive(false);
                    Incorrect.gameObject.SetActive(true);
                }
            }
            else if (myLibrary[i].texture == myLibrary[2].texture)
            {
                if (_steps == 2)
                {
                    ball.transform.position = new Vector2(-395f, 83f);
                    anim.SetBool("moveBall", true);
                    CannotFindImage.gameObject.SetActive(false); //1st step
                    Incorrect.gameObject.SetActive(false); //3rd step
                    Correct.gameObject.SetActive(true); //2nd step
                    _steps--;
                    StopScanning();
                    manager.TimePanel(); //runs Mateo's function
                    Reminder.SetActive(true);
                }
                else
                {
                    Correct.gameObject.SetActive(false);
                    CannotFindImage.gameObject.SetActive(false);
                    Incorrect.gameObject.SetActive(true);
                }
            }
            else if (myLibrary[i].texture == myLibrary[3].texture)
            {
                if (_steps == 3)
                {
                    ball.transform.position = new Vector2(-395f, 29f);
                    anim.SetBool("moveBall", true);
                    CannotFindImage.gameObject.SetActive(false); //1st step
                    Incorrect.gameObject.SetActive(false); //3rd step
                    Correct.gameObject.SetActive(true); //2nd step
                    _steps--;
                    StopScanning();
                    manager.PlaceSelector(); //runs Jamie's function
                    Reminder.SetActive(true);
                }
                else
                {
                    Correct.gameObject.SetActive(false);
                    CannotFindImage.gameObject.SetActive(false);
                    Incorrect.gameObject.SetActive(true);
                }
            }
            else if (myLibrary[i].texture == myLibrary[4].texture)
            {
                if (_steps == 4)
                {
                    ball.transform.position = new Vector2(-395f, -25f);
                    anim.SetBool("moveBall", true);
                    CannotFindImage.gameObject.SetActive(false); //1st step
                    Incorrect.gameObject.SetActive(false); //3rd step
                    Correct.gameObject.SetActive(true); //2nd step
                    _steps--;
                    StopScanning();
                    manager.TravelDuration(); //runs Mateo's function
                    Reminder.SetActive(true);
                }
                else
                {
                    Correct.gameObject.SetActive(false);
                    CannotFindImage.gameObject.SetActive(false);
                    Incorrect.gameObject.SetActive(true);
                }
            }
            else if (myLibrary[i].texture == myLibrary[0].texture)
            {
                CannotFindImage.gameObject.SetActive(false); //first step
                Incorrect.gameObject.SetActive(true); //2nd step
            }
            else
            {
                Correct.gameObject.SetActive(false);
                CannotFindImage.gameObject.SetActive(false);
                Incorrect.gameObject.SetActive(true);
            }
        }
    }
}
