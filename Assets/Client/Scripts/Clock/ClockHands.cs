using System;
using UnityEngine;
using Tools;
using UnityEngine.UI;
using TMPro;

public class ClockHands : MonoBehaviour, ITimeFormatButton
{
    [SerializeField] private HandOfClock _secondHand;
    [SerializeField] private HandOfClock _minuteHand;
    [SerializeField] private HandOfClock _hourHand;
    [SerializeField] private SetButton _setButton;
    [SerializeField] private TextMeshPro _text;

    private ITimeFormatButtonState state;
    #region Events

    public event Action<DateTime> SetAlarmClockEvent;
    #endregion
    public Renderer Renderer { get; set; }
    public bool CanInterract { get; set; } = true;
    public ITimeFormatButtonState State { get => state; set => state = value; }
    public ISetButton SetButton { get => _setButton; }
    public TextMeshPro Inscription => _text;

    private void Start()
    {
        Renderer = GetComponent<Renderer>();
        state = new OffTimeFormatButton(this);
        SetButton.ButtonPressedEvent += SetAlarmClock;
    }
    public void UpdateHands(float hourse, float minutes, float seconds)
    {
        SecondHandRotation(seconds);
        MinuteHandRotation(hourse, minutes);
    }
    public void MinuteHandRotation(float hourse, float minutes)
    {
        var minutesInAngles = minutes * 6;
        var hourseInAngles = hourse * 30 + (30 / (360 / minutesInAngles));
        _minuteHand.transform.localEulerAngles = new Vector3(0f, -minutesInAngles, 0f);
        _hourHand.transform.localEulerAngles = new Vector3(0f, -hourseInAngles, 0f);
    }
    public void SecondHandRotation(float seconds)
    {
        var secondsInAngles = seconds * 6;
        _secondHand.transform.localEulerAngles = new Vector3(0f, -secondsInAngles, 0f);
    }
    public void ChangeState()
    {
        State.ChangeState(this);
        SetButton.State.ChangeState(SetButton, State.AlarmIsSetting);
        HandsChangeActivity();
    }
    private void SetAlarmClock()
    {
        var time = ConvertAnglesToTime();
        SetAlarmClockEvent?.Invoke(time);
        State = new OffTimeFormatButton(this);
        SetButton.State.ChangeState(SetButton, State.AlarmIsSetting);
        HandsChangeActivity();
    }
    private DateTime ConvertAnglesToTime()
    {
        var angles = GetHandsAngles();

        var hourseAngles = CustomMath.Round(angles[0], 30);
        var minutesAngles = CustomMath.Round(angles[1], 6);

        var minutes = Mathf.Abs(minutesAngles / 6);
        var hourse = Mathf.Abs(hourseAngles / 30);

        if (State.GetType() == typeof(PMTimeFormatButton))
            hourse += 12;

        var time = new DateTime(1111, 1, 1, (int)hourse, (int)minutes, 0);

        return time;
    }
    private float[] GetHandsAngles()
    {        
        var hourseAngles = _hourHand.transform.localEulerAngles.y;
        var minutesAngles = _minuteHand.transform.localEulerAngles.y;
       
        if (hourseAngles > 0)
            hourseAngles -= 360;
        if (minutesAngles > 0)
            minutesAngles -= 360;

        var angles = new float[]{ hourseAngles, minutesAngles };
        return angles;
    }
    private void HandsChangeActivity()
    {
        _minuteHand.CanInterract = State.AlarmIsSetting;
        _hourHand.CanInterract = State.AlarmIsSetting;
    }
    public void Interract()
    {
        if(CanInterract)
            ChangeState();
    }
}
