using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedVariables : MonoBehaviour
{

    private string buttonPressed = "no_destination";
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void USButtonPressed()
    {
        buttonPressed = "united_states";
    }

    public void AFButtonPressed()
    {
        buttonPressed = "Africa";
    }

    public void JPButtonPressed()
    {
        buttonPressed = "Japan";
    }

    public void CAButtonPressed()
    {
        buttonPressed = "Canada";
    }
}
