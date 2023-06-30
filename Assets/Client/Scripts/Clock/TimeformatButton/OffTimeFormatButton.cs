using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffTimeFormatButton : ITimeFormatButtonState
{

    private const string TEXT = "Off";
    private const bool alarmIsSetting = false;
    private const bool canInterract = true;

    private Color stateColor = Color.black;
    private Color textColor = Color.white;

    public bool CanInterract => canInterract;
    public Color StateColor => stateColor;
    public Color TextColor => textColor;
    public bool AlarmIsSetting => alarmIsSetting;
    public string Text => TEXT;

    public OffTimeFormatButton(ITimeFormatButton button)
    {
        button.Renderer.material.color = StateColor;
        button.Inscription.text = Text;
        button.Inscription.color = TextColor;
    }
    public void ChangeState(ITimeFormatButton button)
    {
        button.State = new AMTimeFormatButton(button);
    }
}
