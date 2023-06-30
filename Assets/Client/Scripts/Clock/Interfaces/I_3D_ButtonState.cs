using UnityEngine;

public interface I_3D_ButtonState
{
    Color StateColor { get; }
    Color TextColor { get; }
    string Text { get; }
    bool CanInterract { get; }
}
