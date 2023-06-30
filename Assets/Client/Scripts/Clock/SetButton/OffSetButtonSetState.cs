using UnityEngine;

public class OffSetButtonSetState : ISetButtonState
{
    private const string TEXT = "Off";
    private const bool alarmIsSetting = true;
    private const bool canInterract = false;

    private Color stateColor = Color.black;
    private Color textColor = Color.black;

    public bool CanInterract => canInterract;
    public Color StateColor => stateColor;
    public Color TextColor => textColor;
    public bool AlarmIsSetting => alarmIsSetting;
    public string Text => TEXT;

    public OffSetButtonSetState(ISetButton button)
    {
        button.Renderer.material.color = StateColor;
        button.Inscription.text = Text;
        button.Inscription.color = TextColor;
    }
    public void ChangeState(ISetButton button, bool activity)
    {
        if(activity)
            button.State = new ActiveSetButtonSetState(button);
    }
}
