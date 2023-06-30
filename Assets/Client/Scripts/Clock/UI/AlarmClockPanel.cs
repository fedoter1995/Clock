using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class AlarmClockPanel : MonoBehaviour
{
    public event Action<DateTime> OnTimeInputEvent;

    [SerializeField] private TimeInput _inputs;
    [SerializeField] private AlarmClockListUI _listUI;
    [SerializeField] private Button _submitButton;

    public AlarmClockListUI UIList => _listUI;
    private void Start()
    {
        _submitButton.onClick.AddListener(TimeInput);
    }
    private void TimeInput()
    {
        var time = new DateTime(1111, 1, 1, _inputs.Hourse, _inputs.Minutes,0);

        OnTimeInputEvent?.Invoke(time);
    }

    public void HidePanel()
    {
        gameObject.SetActive(false);
    }
    public void ShowPanel()
    {
        gameObject.SetActive(true);
    }
}
