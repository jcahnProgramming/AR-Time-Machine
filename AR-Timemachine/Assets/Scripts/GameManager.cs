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

    public void PlaceSelector() //jamie's function
    {
        DestinationSelector.SetActive(true);
        year.text = sv.yearText;
    }

    public void SafetySwitches() //EJ's function
    {

    }

    public void TimePanel() //Mateo's Function
    {

    }

    public void TravelDuration() //Asuquo's Function
    {

    }



    //void OnEnable() => m_TrackedImageManager.trackedImagesChanged += OnChanged;
    //void OnDisable() => m_TrackedImageManager.trackedImagesChanged -= OnChanged;

    //void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    //{
    //    foreach (var newImage in eventArgs.added)
    //    {

    //    }

    //    foreach (var updatedImage in eventArgs.updated)
    //    {

    //    }

    //    foreach (var removedImage in eventArgs.removed)
    //    {

    //    }
    //}
}
