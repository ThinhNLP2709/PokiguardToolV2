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
using UnityEngine.Serialization;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.EventSystems
{
	[AddComponentMenu("Event/Standalone Input Module")]
	[UGUIHelpURL("StandaloneInputModule")]
	public class StandaloneInputModule : PointerInputModule // TypeDefIndex: 13202
	{
		// Fields
		private float m_PrevActionTime; // 0x68
		private Vector2 m_LastMoveVector; // 0x6C
		private int m_ConsecutiveMoveCount; // 0x74
		private Vector2 m_LastMousePosition; // 0x78
		private Vector2 m_MousePosition; // 0x80
		private GameObject m_CurrentFocusedGameObject; // 0x88
		private readonly Dictionary<int, PointerEventData> m_InputPointerEvents; // 0x90
		private const float doubleClickTime = 0.3f; // Metadata: 0x006A77DB
		[SerializeField]
		private string m_HorizontalAxis; // 0x98
		[SerializeField]
		private string m_VerticalAxis; // 0xA0
		[SerializeField]
		private string m_SubmitButton; // 0xA8
		[SerializeField]
		private string m_CancelButton; // 0xB0
		[SerializeField]
		private float m_InputActionsPerSecond; // 0xB8
		[SerializeField]
		private float m_RepeatDelay; // 0xBC
		[FormerlySerializedAs("m_AllowActivationOnMobileDevice")]
		[HideInInspector]
		[SerializeField]
		private bool m_ForceModuleActive; // 0xC0
	
		// Properties
		[Obsolete("Mode is no longer needed on input module as it handles both mouse and keyboard simultaneously.", true)]
		public InputMode inputMode { get; } // 0x00000001802E7860-0x00000001802E7870 
		[Obsolete("allowActivationOnMobileDevice has been deprecated. Use forceModuleActive instead (UnityUpgradable) -> forceModuleActive", true)]
		public bool allowActivationOnMobileDevice { get; set; } // 0x000000018183E570-0x000000018183E580 0x0000000181F64A30-0x0000000181F64A40
		[Obsolete("forceModuleActive has been deprecated. There is no need to force the module awake as StandaloneInputModule works for all platforms", true)]
		public bool forceModuleActive { get; set; } // 0x000000018183E570-0x000000018183E580 0x0000000181F64A30-0x0000000181F64A40
		public float inputActionsPerSecond { get; set; } // 0x0000000182335720-0x0000000182335730 0x0000000182335820-0x0000000182335830
		public float repeatDelay { get; set; } // 0x0000000181E6F280-0x0000000181E6F290 0x0000000182335780-0x0000000182335790
		public string horizontalAxis { get; set; } // 0x00000001806CCBC0-0x00000001806CCBD0 0x00000001806CCE20-0x00000001806CCE40
		public string verticalAxis { get; set; } // 0x00000001805B5990-0x00000001805B59A0 0x00000001806CCE40-0x00000001806CCE60
		public string submitButton { get; set; } // 0x000000018033D510-0x000000018033D520 0x000000018033EAB0-0x000000018033EAD0
		public string cancelButton { get; set; } // 0x00000001806BAE60-0x00000001806BAE70 0x00000001806C0C00-0x00000001806C0C20
	
		// Nested types
		[Obsolete("Mode is no longer needed on input module as it handles both mouse and keyboard simultaneously.", true)]
		public enum InputMode // TypeDefIndex: 13203
		{
			Mouse = 0,
			Buttons = 1
		}
	
		// Constructors
		protected StandaloneInputModule(); // 0x00000001825BFE40-0x00000001825BFF90
	
		// Methods
		private bool ShouldIgnoreEventsOnNoFocus(); // 0x00000001802E7990-0x00000001802E79A0
		public override void UpdateModule(); // 0x00000001825BFDB0-0x00000001825BFE40
		private void ReleasePointerDrags(); // 0x00000001825BED20-0x00000001825BF380
		private void ReleaseMouse(PointerEventData pointerEvent, GameObject currentOverGo); // 0x00000001825BE9B0-0x00000001825BED20
		public override bool ShouldActivateModule(); // 0x00000001825BFB20-0x00000001825BFDB0
		public override void ActivateModule(); // 0x00000001825BD4B0-0x00000001825BD610
		public override void DeactivateModule(); // 0x00000001825BD610-0x00000001825BD620
		public override void Process(); // 0x00000001825BE7C0-0x00000001825BE9B0
		private bool ProcessTouchEvents(); // 0x00000001825BDE80-0x00000001825BE090
		protected void ProcessTouchPress(PointerEventData pointerEvent, bool pressed, bool released); // 0x00000001825BE090-0x00000001825BE7C0
		protected bool SendSubmitEventToSelectedObject(); // 0x00000001825BF730-0x00000001825BF9C0
		private Vector2 GetRawMoveVector(); // 0x00000001825BD620-0x00000001825BD770
		protected bool SendMoveEventToSelectedObject(); // 0x00000001825BF380-0x00000001825BF730
		protected void ProcessMouseEvent(); // 0x00000001825BDA60-0x00000001825BDA70
		[Obsolete("This method is no longer checked, overriding it with return true does nothing!", true)]
		protected virtual bool ForceAutoSelect(); // 0x00000001802E7840-0x00000001802E7850
		protected void ProcessMouseEvent(int id); // 0x00000001825BD770-0x00000001825BDA60
		protected bool SendUpdateEventToSelectedObject(); // 0x00000001825BF9C0-0x00000001825BFB20
		protected void ProcessMousePress(MouseButtonEventData data); // 0x00000001825BDA70-0x00000001825BDE80
		protected GameObject GetCurrentFocusedGameObject(); // 0x000000018038B8A0-0x000000018038B8B0
	}
}
