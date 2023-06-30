using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandOfClock : MonoBehaviour, IInteractable
{
    private HandController handController;

    public bool CanInterract { get; set; } = false;

    private void Start()
    {
        handController = new HandController(this);
    }

    public void Interract()
    {
        if(CanInterract)
            handController.ClockHandControll();
    }
}
