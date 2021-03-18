using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class GameManager : MonoBehaviour
{
    public XRReferenceImageLibrary myLibrary;

    void Awake()
    {
        var manager = gameObject.AddComponent<ARTrackedImageManager>();
        manager.referenceLibrary = myLibrary;
        manager.enabled = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlaceSelector() //jamie's function
    {
        
    }
}
