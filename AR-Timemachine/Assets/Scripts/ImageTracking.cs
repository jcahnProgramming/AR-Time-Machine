using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageTracking : MonoBehaviour
{
    public ARTrackedImageManager manager;
    public XRReferenceImageLibrary myLibrary;
    public XRImageTrackingSubsystem subsystem;




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
}
