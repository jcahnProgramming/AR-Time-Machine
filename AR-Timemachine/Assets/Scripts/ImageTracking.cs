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



    void Awake()
    {
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
            //when logo has been identified, then move to next step
            StopScanning();
        }
    }

    public void StartScanning()
    {
        startScanning = true;
    }

    public void StopScanning()
    {
        startScanning = false;
    }
    public void FirstTimeScan()
    {
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
        StartScanning();
        for (int i = 0; i < myLibrary.count; i++)
        {
            if (myLibrary[i].texture == myLibrary[1].texture)
            {
                if (_steps == 1)
                {
                    CannotFindImage.gameObject.SetActive(false); //1st step
                    Correct.gameObject.SetActive(true); //2nd step
                    Incorrect.gameObject.SetActive(false); //3rd step
                    _steps++;
                    StopScanning();
                    manager.SafetySwitches(); //runs EJ's function
                }
                else
                {
                    Incorrect.gameObject.SetActive(true);
                    Correct.gameObject.SetActive(false);
                    CannotFindImage.gameObject.SetActive(false);
                }
            }
            else if (myLibrary[i].texture == myLibrary[2].texture)
            {
                if (_steps == 2)
                {
                    CannotFindImage.gameObject.SetActive(false); //1st step
                    Correct.gameObject.SetActive(true); //2nd step
                    Incorrect.gameObject.SetActive(false); //3rd step
                    _steps++;
                    StopScanning();
                    manager.TimePanel(); //runs Mateo's function
                }
                else
                {
                    Incorrect.gameObject.SetActive(true);
                    Correct.gameObject.SetActive(false);
                    CannotFindImage.gameObject.SetActive(false);
                }
            }
            else if (myLibrary[i].texture == myLibrary[3].texture)
            {
                if (_steps == 3)
                {
                    CannotFindImage.gameObject.SetActive(false); //1st step
                    Correct.gameObject.SetActive(true); //2nd step
                    Incorrect.gameObject.SetActive(false); //3rd step
                    _steps++;
                    StopScanning();
                    manager.PlaceSelector(); //runs Jamie's function
                }
                else
                {
                    Incorrect.gameObject.SetActive(true);
                    Correct.gameObject.SetActive(false);
                    CannotFindImage.gameObject.SetActive(false);
                }
            }
            else if (myLibrary[i].texture == myLibrary[4].texture)
            {
                if (_steps == 4)
                {
                    CannotFindImage.gameObject.SetActive(false); //1st step
                    Correct.gameObject.SetActive(true); //2nd step
                    Incorrect.gameObject.SetActive(false); //3rd step
                    StopScanning();
                    manager.TravelDuration(); //runs Mateo's function
                }
                else
                {
                    Incorrect.gameObject.SetActive(true);
                    Correct.gameObject.SetActive(false);
                    CannotFindImage.gameObject.SetActive(false);
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
                Incorrect.gameObject.SetActive(true);
                Correct.gameObject.SetActive(false);
                CannotFindImage.gameObject.SetActive(false);
            }
        }

    }

    public void BackButton()
    {
        StartScanning();
        for (int i = 0; i < myLibrary.count; i++)
        {
            if (myLibrary[i].texture == myLibrary[1].texture)
            {
                if (_steps == 1)
                {
                    CannotFindImage.gameObject.SetActive(false); //1st step
                    Correct.gameObject.SetActive(true); //2nd step
                    Incorrect.gameObject.SetActive(false); //3rd step
                    StopScanning();
                    manager.SafetySwitches(); //runs EJ's function
                }
                else
                {
                    Incorrect.gameObject.SetActive(true);
                    Correct.gameObject.SetActive(false);
                    CannotFindImage.gameObject.SetActive(false);
                }
            }
            else if (myLibrary[i].texture == myLibrary[2].texture)
            {
                if (_steps == 2)
                {
                    CannotFindImage.gameObject.SetActive(false); //1st step
                    Correct.gameObject.SetActive(true); //2nd step
                    Incorrect.gameObject.SetActive(false); //3rd step
                    _steps--;
                    StopScanning();
                    manager.TimePanel(); //runs Mateo's function
                }
                else
                {
                    Incorrect.gameObject.SetActive(true);
                    Correct.gameObject.SetActive(false);
                    CannotFindImage.gameObject.SetActive(false);
                }
            }
            else if (myLibrary[i].texture == myLibrary[3].texture)
            {
                if (_steps == 3)
                {
                    CannotFindImage.gameObject.SetActive(false); //1st step
                    Correct.gameObject.SetActive(true); //2nd step
                    Incorrect.gameObject.SetActive(false); //3rd step
                    _steps--;
                    StopScanning();
                    manager.PlaceSelector(); //runs Jamie's function
                }
                else
                {
                    Incorrect.gameObject.SetActive(true);
                    Correct.gameObject.SetActive(false);
                    CannotFindImage.gameObject.SetActive(false);
                }
            }
            else if (myLibrary[i].texture == myLibrary[4].texture)
            {
                if (_steps == 4)
                {
                    CannotFindImage.gameObject.SetActive(false); //1st step
                    Correct.gameObject.SetActive(true); //2nd step
                    Incorrect.gameObject.SetActive(false); //3rd step
                    _steps--;
                    StopScanning();
                    manager.TravelDuration(); //runs Mateo's function
                }
                else
                {
                    Incorrect.gameObject.SetActive(true);
                    Correct.gameObject.SetActive(false);
                    CannotFindImage.gameObject.SetActive(false);
                }
            }
            else if (myLibrary[i].texture == myLibrary[0].texture)
            {
                CannotFindImage.gameObject.SetActive(false); //first step
                Incorrect.gameObject.SetActive(true); //2nd step
            }
            else
            {
                Incorrect.gameObject.SetActive(true);
                Correct.gameObject.SetActive(false);
                CannotFindImage.gameObject.SetActive(false);
            }
        }
    }
}
