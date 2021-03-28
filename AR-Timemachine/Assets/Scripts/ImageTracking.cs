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
       if (startScanning == true)
        {
            ScanForLogo();
        }
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
}
