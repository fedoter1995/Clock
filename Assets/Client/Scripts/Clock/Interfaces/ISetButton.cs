using System;
using System.Collections.Generic;
using UnityEngine;

public interface ISetButton : I_3D_Button
{
    event Action ButtonPressedEvent;
    ISetButtonState State { get; set; }
}
