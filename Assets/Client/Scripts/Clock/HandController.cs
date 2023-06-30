using UnityEngine;
using System.Collections;
using Tools;

public class HandController 
{	
	private HandOfClock hand;
	private Coroutine rotationRoutine;
	public float Angle { get; private set; }

	public HandController(HandOfClock hand)
    {
		this.hand = hand;
	}

	public void ClockHandControll()
	{
		rotationRoutine = Coroutines.Start(HandRotationRoutine());
	}
	private void LookAt()
	{
		var offset = 90f;
		var targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		targetPosition.Normalize();

		var rotation_z = Mathf.Atan2(targetPosition.y, targetPosition.x) * Mathf.Rad2Deg;

		var rotation = Mathf.Abs(hand.transform.rotation.z) - Mathf.Abs(rotation_z - offset);

		hand.transform.localRotation = Quaternion.Euler(0f, rotation_z - offset, 0f);		
	}
	private IEnumerator HandRotationRoutine()
    {
		while(true)
        {
			if (Input.GetKeyUp(KeyCode.Mouse0))
			{
				rotationRoutine = null;
				yield break;
			}
			LookAt();
			yield return null;
        }		
    }
}
