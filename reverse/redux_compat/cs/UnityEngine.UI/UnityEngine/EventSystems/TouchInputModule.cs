/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Serialization;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.EventSystems
{
	[AddComponentMenu("Event/Touch Input Module")]
	[Obsolete("TouchInputModule is no longer required as Touch input is now handled in StandaloneInputModule.", true)]
	[UGUIHelpURL("TouchInputModule")]
	public class TouchInputModule : PointerInputModule // TypeDefIndex: 13204
	{
		// Fields
		private Vector2 m_LastMousePosition; // 0x68
		private Vector2 m_MousePosition; // 0x70
		private PointerEventData m_InputPointerEvent; // 0x78
		[FormerlySerializedAs("m_AllowActivationOnStandalone")]
		[SerializeField]
		private bool m_ForceModuleActive; // 0x80
	
		// Properties
		[Obsolete("allowActivationOnStandalone has been deprecated. Use forceModuleActive instead (UnityUpgradable) -> forceModuleActive", true)]
		public bool allowActivationOnStandalone { get; set; } // 0x000000018170D340-0x000000018170D350 0x00000001812500E0-0x00000001812500F0
		public bool forceModuleActive { get; set; } // 0x000000018170D340-0x000000018170D350 0x00000001812500E0-0x00000001812500F0
	
		// Constructors
		protected TouchInputModule(); // 0x00000001825C1650-0x00000001825C1660
	
		// Methods
		public override void UpdateModule(); // 0x00000001825C14A0-0x00000001825C1610
		public override bool IsModuleSupported(); // 0x00000001825C00E0-0x00000001825C0130
		public override bool ShouldActivateModule(); // 0x00000001825C1100-0x00000001825C1220
		private bool UseFakeInput(); // 0x00000001825C1610-0x00000001825C1650
		public override void Process(); // 0x00000001825C0F70-0x00000001825C1100
		private void FakeTouches(); // 0x00000001825BFF90-0x00000001825C00E0
		private void ProcessTouchEvents(); // 0x00000001825C0130-0x00000001825C08A0
		protected void ProcessTouchPress(PointerEventData pointerEvent, bool pressed, bool released); // 0x00000001825C08A0-0x00000001825C0F70
		public override void DeactivateModule(); // 0x00000001825BD610-0x00000001825BD620
		public override string ToString(); // 0x00000001825C1220-0x00000001825C14A0
	}
}
