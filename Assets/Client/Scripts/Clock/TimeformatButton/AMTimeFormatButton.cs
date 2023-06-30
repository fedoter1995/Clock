using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AMTimeFormatButton : ITimeFormatButtonState
{
    private const string TEXT = "AM";
    private const bool alarmIsSetting = true;
    private const bool canInterract = true;

    private Color stateColor = Color.blue;
    private Color textColor = Color.white;

    public bool CanInterract => canInterract;
    public Color StateColor => stateColor;
    public Color TextColor => textColor;
    public bool AlarmIsSetting => alarmIsSetting;
    public string Text => TEXT;
    public AMTimeFormatButton(ITimeFormatButton button)
    {
        button.Renderer.material.color = StateColor;
        button.Inscription.text = Text;
        button.Inscription.color = TextColor;
    }
    public void ChangeState(ITimeFormatButton button)
    {
        button.State = new PMTimeFormatButton(button);
    }
}
