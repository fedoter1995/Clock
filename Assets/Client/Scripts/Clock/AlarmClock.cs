using System;
using System.Collections.Generic;
using UnityEngine;

public class AlarmClock : MonoBehaviour
{
    [SerializeField] private AlarmClockPanel _panel;
    [SerializeField] private int _alarmClockListMaxCount = 5;
    
    private List<DateTime> alarmClockList = new List<DateTime>();


    public bool PanelIsActive => _panel.gameObject.activeInHierarchy;
    public void Start()
    {
        _panel.OnTimeInputEvent += SetAlarmClock;
        _panel.UIList.DeleteAlarmClockEvent += DeleteAlarmClock;
    }

    public void SetAlarmClock(DateTime time)
    {
        if (FindAlarmClock(time.Hour, time.Minute) == default && alarmClockList.Count < _alarmClockListMaxCount)
        {
            alarmClockList.Add(time);
            _panel.UIList.AddAlarmClock(time);
            _panel.HidePanel();
        }
        else if (alarmClockList.Count >= _alarmClockListMaxCount)
            Debug.Log("Already have max alarm clock");
        else
            Debug.Log("Already have such an alarm clock");

    }
    private DateTime FindAlarmClock(int hourse, int minutes)
    {
        var value = alarmClockList.Find(alarmClock => alarmClock.Hour == hourse && alarmClock.Minute == minutes);

        return value;
    }
    private DateTime FindAlarmClock(DateTime time)
    {
        var value = alarmClockList.Find(alarmClock => alarmClock == time);

        return value;
    }
    private void DeleteAlarmClock(DateTime time)
    {
        var item = FindAlarmClock(time);
        if (item != default)
            alarmClockList.Remove(item);
    }
    private void Alarm()
    {
        Debug.Log("Alllaaaaaaarm!!!!!!");
    }
    public void InspectAlarmClockTime(int hourse, int minutes)
    {
        var time = FindAlarmClock(hourse, minutes);
        if (time != default)
            Alarm();
    }
    public void ShowPanel()
    {
        _panel.ShowPanel();
    }
    public void HidePanel()
    {
        _panel.HidePanel();
    }

}
