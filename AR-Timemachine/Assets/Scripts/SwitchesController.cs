using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchesController : MonoBehaviour
{
    [SerializeField] private Text _switchLeftText;
    [SerializeField] private Text _switchRightText;
    [SerializeField] private SavedVariables _savedVariables;

    private void Update()
    {
        _switchLeftText.text = _savedVariables.switchLeftOn ? "On" : "Off";
        _switchRightText.text = _savedVariables.switchRightOn ? "On" : "Off";
    }
}
