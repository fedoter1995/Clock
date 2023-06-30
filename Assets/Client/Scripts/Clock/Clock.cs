using System;
using CustomTimer;
using Tools;
using UnityEngine;

public class Clock : MonoBehaviour, IInteractable
{
    [SerializeField] private ClockHands _clockHands;
    [SerializeField] private TextMesh _textSpace;
    [SerializeField] private AlarmClock _alarmClock;
    [SerializeField] private RaycastHitCheck _hitCheck;

    public event Action UiUpdateEvent;
    public event Action<int,int> MinutesLeftEvent;
    public bool PanelIsActive { get; private set; } = false;

    private DateTime time;


    private int hourse;
    private int minutes;
    private int seconds;

    public int Seconds
    {
        get => seconds;
        set
        {
            seconds = value;
            if (_clockHands.State.GetType() == typeof(OffTimeFormatButton))
                _clockHands.UpdateHands(Hourse, Minutes, Seconds);
            else
                _clockHands.SecondHandRotation(seconds);

            UpdateDigitTime();

        }
    }
    public int Minutes
    {
        get => minutes;
        set
        {
            minutes = value;
            MinutesLeftEvent?.Invoke(Hourse, Minutes);
        }
    }
    public int Hourse
    {
        get => hourse;
        set
        {
            hourse = value;
            UpdateDigitTime();
        }
    }

    public bool CanInterract { get; set; } = true;

    public void Start()
    {
        Initialize();
    }
    public void Update()
    {       
            if (_hitCheck.CurObj == null && _hitCheck.uiObjectsCount <= 0)
                _alarmClock.HidePanel();
    }
    private void CourseOfTime()
    {
        Seconds++;
        var secondsStr = Seconds.ToString();
        if (Seconds >= 60)
        {
            Minutes++;
            Seconds = 0;
        }
        if (Minutes >= 60)
            Minutes = 0;
    }
    private void CheckNetworkTime()
    {
        time = TimeChecker.TimeCheck();
        Hourse = time.Hour;
        Minutes = time.Minute;
        Seconds = time.Second;

        _clockHands.UpdateHands(Hourse, Minutes, Seconds);
    }
    private void UpdateDigitTime()
    {

        var secondsStr = Seconds.ToString();
        var minutesStr = Minutes.ToString();
        var hourseStr = Hourse.ToString(); ;

        if (Seconds < 10)
            secondsStr = $"0{secondsStr}";
        if (Minutes < 10)
            minutesStr = $"0{minutesStr}";
        if (Hourse < 10)
            hourseStr = $"0{hourseStr}";

        _textSpace.text = $"{hourseStr}:{minutesStr}:{secondsStr}";
    }
    private void Initialize()
    {
        CheckNetworkTime();
        Timer.instance.OnSecondLeftEvent += CourseOfTime;
        Timer.instance.OnHourLeftEvent += CheckNetworkTime;
        MinutesLeftEvent += _alarmClock.InspectAlarmClockTime;
        _clockHands.SetAlarmClockEvent += SetAlarmClock;
    }
    private void SetAlarmClock(DateTime time)
    {
        _alarmClock.SetAlarmClock(time);
        _clockHands.UpdateHands(Hourse, Minutes, Seconds);
    }
    public void Interract()
    {
        if(CanInterract)
            _alarmClock.ShowPanel();   
    }
}
