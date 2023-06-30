using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tools
{
	public sealed class RaycastHitCheck : MonoBehaviour
	{		
		[SerializeField] private EventSystem m_EventSystem;
		[SerializeField] private GraphicRaycaster m_Raycaster;
		
		private  Camera mainCamera;
		private  GameObject curObj;
		private PointerEventData m_PointerEventData;
		private List<RaycastResult> uiObjs = new List<RaycastResult>();

		public  GameObject CurObj => curObj;
		public int uiObjectsCount => uiObjs.Count;

		private void Awake()
        {
			mainCamera = Camera.main;
		}
        private  void Update()
        {
			if (Input.GetKeyDown(KeyCode.Mouse0))
            {
				InterractWithItem();
				CheckGraphicsRaycastObject();
			}

		}
		private  GameObject CheckRaycastObject()
		{
			RaycastHit hit;
			var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit))
			{
				return hit.transform.gameObject;
			}
			return null;
		}
        private List<RaycastResult> CheckGraphicsRaycastObject()
        {
            //Set up the new Pointer Event
            m_PointerEventData = new PointerEventData(m_EventSystem);
			//Set the Pointer Event Position to that of the mouse position
			m_PointerEventData.position = Input.mousePosition;
            //Create a list of Raycast Results
            var results = new List<RaycastResult>();
			//Raycast using the Graphics Raycaster and mouse click position
			m_Raycaster.Raycast(m_PointerEventData, results);
			return results;
		}
		public void InterractWithItem()
        {
			var obj = CheckRaycastObject();
			var ui = CheckGraphicsRaycastObject();
			if (obj != null) 
			{			
				var interactable = obj.transform.gameObject.GetComponent<IInteractable>();
				interactable.Interract();
			}
			curObj = obj;
			uiObjs = ui;
		}
	}
}

