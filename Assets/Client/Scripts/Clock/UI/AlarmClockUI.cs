using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlarmClockUI : MonoBehaviour
{
    [SerializeField] private Text _textField;
    [SerializeField] private Button _resetButton;


    public DateTime Time { get; private set; }

    public event Action<AlarmClockUI> ResetUIAlarmClockEvent;

    private void Awake()
    {
        _resetButton.onClick.AddListener(DeleteAlarmClock);
    }

    private void DeleteAlarmClock()
    {
        ResetUIAlarmClockEvent?.Invoke(this);
    }
    private void UpdateAlarmClockUI()
    {
        _textField.text = $"{Time.Hour}:{Time.Minute}";
    }
    public void SetTime(DateTime time)
    {
        this.Time = time;
        UpdateAlarmClockUI();
    }
}
