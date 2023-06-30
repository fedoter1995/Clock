using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITimeFormatButtonState : I_3D_ButtonState
{
    bool AlarmIsSetting { get; }
    void ChangeState(ITimeFormatButton button);
}
