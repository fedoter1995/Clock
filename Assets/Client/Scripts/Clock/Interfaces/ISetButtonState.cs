using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISetButtonState : I_3D_ButtonState
{
    void ChangeState(ISetButton button, bool activity);
}
