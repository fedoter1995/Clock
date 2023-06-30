using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSetButtonSetState : ISetButtonState
{
    private const string TEXT = "Set";
    private const bool alarmIsSetting = true;
    private const bool canInterract = true;

    private Color stateColor = Color.red;
    private Color textColor = Color.white;

    public bool CanInterract => canInterract;
    public Color StateColor => stateColor;
    public Color TextColor => textColor;
    public bool AlarmIsSetting => alarmIsSetting;
    public string Text => TEXT;

    public ActiveSetButtonSetState(ISetButton button)
    {
        button.Renderer.material.color = StateColor;
        button.Inscription.text = Text;
        button.Inscription.color = TextColor;
    }
    public void ChangeState(ISetButton button, bool activity)
    {
        if(!activity)
         button.State = new OffSetButtonSetState(button);
    }
}
