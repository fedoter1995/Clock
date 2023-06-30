using System;
using System.Globalization;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class TimeInput : MonoBehaviour
{
    [SerializeField] private TMP_InputField _hourseInputField;
    [SerializeField] private TMP_InputField _minutesInputField;

    private string currentHourse = "00";
    private string currentMinutes = "00";
    public int Hourse => Int32.Parse(currentHourse);
    public int Minutes => Int32.Parse(currentMinutes);

    private void Start()
    {
        _hourseInputField.onValueChanged.AddListener(CheckHourse);
        _minutesInputField.onValueChanged.AddListener(CheckMinutes);
        _minutesInputField.text = "00";
        _hourseInputField.text = "00";

    }
    private void CheckHourse(string text)
    {
        if (text == null)
            text = "00";
        
        if (IsDigitFormat(text))
        {
            if (Int32.Parse(text) > 23)
            {
                _hourseInputField.text = currentHourse;
            }
            else
                currentHourse = text;
        }
        else
            _hourseInputField.text = currentHourse;

    }
    private void CheckMinutes(string text)
    {
        if (text == null)
            text = "00";

        if (IsDigitFormat(text))
        {
            if (Int32.Parse(text) > 59)
            {
                _minutesInputField.text = currentMinutes;
            }
            else
                currentMinutes = text;
        }
        else
            _minutesInputField.text = currentMinutes;

    }
    private bool IsDigitFormat(string s)
    {
        Regex r = new Regex(@"(\D+)");

        if (r.IsMatch(s))
            return false;
        return true;

    }
    public void ResetInputs()
    {
        _minutesInputField.text = "00";
        _hourseInputField.text = "00";
    }
}
