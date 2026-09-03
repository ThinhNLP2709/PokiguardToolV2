/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.EventSystems
{
	[RequireComponent(typeof(EventSystem))]
	public abstract class BaseInputModule : UIBehaviour // TypeDefIndex: 13196
	{
		// Fields
		[NonSerialized]
		protected List<RaycastResult> m_RaycastResultCache; // 0x20
		[SerializeField]
		private bool m_SendPointerHoverToParent; // 0x28
		private AxisEventData m_AxisEventData; // 0x30
		private EventSystem m_EventSystem; // 0x38
		private BaseEventData m_BaseEventData; // 0x40
		protected BaseInput m_InputOverride; // 0x48
		private BaseInput m_DefaultInput; // 0x50
	
		// Properties
		protected internal bool sendPointerHoverToParent { get; set; } // 0x0000000180327270-0x0000000180327280 0x00000001804AE490-0x00000001804AE4A0
		public BaseInput input { get; } // 0x00000001825AD6F0-0x00000001825AD880 
		public BaseInput inputOverride { get; set; } // 0x00000001803272B0-0x00000001803272C0 0x00000001803780C0-0x00000001803780D0
		protected EventSystem eventSystem { get; } // 0x00000001803272A0-0x00000001803272B0 
	
		// Constructors
		protected BaseInputModule(); // 0x00000001825AD670-0x00000001825AD6F0
	
		// Methods
		protected override void OnEnable(); // 0x00000001825AD5C0-0x00000001825AD630
		protected override void OnDisable(); // 0x00000001825AD590-0x00000001825AD5C0
		public abstract void Process();
		protected static RaycastResult FindFirstRaycast(List<RaycastResult> candidates); // 0x00000001825AC940-0x00000001825ACA90
		protected static MoveDirection DetermineMoveDirection(float x, float y); // 0x00000001825AC790-0x00000001825AC800
		protected static MoveDirection DetermineMoveDirection(float x, float y, float deadZone); // 0x00000001825AC710-0x00000001825AC790
		protected static GameObject FindCommonRoot(GameObject g1, GameObject g2); // 0x00000001825AC800-0x00000001825AC940
		protected void HandlePointerExitAndEnter(PointerEventData currentPointerData, GameObject newEnterTarget); // 0x00000001825ACC70-0x00000001825AD590
		protected virtual AxisEventData GetAxisEventData(float x, float y, float moveDeadZone); // 0x00000001825ACA90-0x00000001825ACBC0
		protected virtual BaseEventData GetBaseEventData(); // 0x00000001825ACBC0-0x00000001825ACC70
		public virtual bool IsPointerOverGameObject(int pointerId); // 0x00000001802E7840-0x00000001802E7850
		public virtual bool ShouldActivateModule(); // 0x00000001825AD630-0x00000001825AD670
		public virtual void DeactivateModule(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void ActivateModule(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void UpdateModule(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual bool IsModuleSupported(); // 0x00000001802E7990-0x00000001802E79A0
		public virtual int ConvertUIToolkitPointerId(PointerEventData sourcePointerData); // 0x00000001825AC670-0x00000001825AC710
		public virtual Vector2 ConvertPointerEventScrollDeltaToTicks(Vector2 scrollDelta); // 0x00000001825AC610-0x00000001825AC670
		public virtual NavigationDeviceType GetNavigationEventDeviceType(BaseEventData eventData); // 0x00000001802E7860-0x00000001802E7870
	}
}
