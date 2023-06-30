using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITimeFormatButton : I_3D_Button
{
    ITimeFormatButtonState State { get; set; }
    ISetButton SetButton { get; }
}
