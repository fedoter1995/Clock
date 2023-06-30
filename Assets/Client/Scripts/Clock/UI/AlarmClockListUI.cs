using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmClockListUI : MonoBehaviour
{
    [SerializeField] AlarmClockUI _alarmClockUIPrefab;

    private List<AlarmClockUI> uiList = new List<AlarmClockUI>();

    public event Action<DateTime> DeleteAlarmClockEvent;
    public void AddAlarmClock(DateTime time)
    {
        var uiObj = Instantiate(_alarmClockUIPrefab, transform);
        uiObj.SetTime(time);
        uiObj.ResetUIAlarmClockEvent += DeleteAlarmClockUI;
        uiList.Add(uiObj);
    }
    public void DeleteAlarmClockUI(AlarmClockUI UIitem)
    {
        DeleteAlarmClockEvent?.Invoke(UIitem.Time);
        Destroy(UIitem.gameObject);      
    }
}
