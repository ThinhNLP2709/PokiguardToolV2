/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Layouts;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.OnScreen
{
	[AddComponentMenu("Input/On-Screen Button")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.inputsystem@1.19/manual/OnScreen.html#on-screen-buttons")]
	public class OnScreenButton : OnScreenControl, IPointerDownHandler, IPointerUpHandler // TypeDefIndex: 6330
	{
		// Fields
		[InputControl(layout = "Button")]
		[SerializeField]
		private string m_ControlPath; // 0x38
	
		// Properties
		protected override string controlPathInternal { get; set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018033E850-0x000000018033E860
	
		// Constructors
		public OnScreenButton(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		public void OnPointerUp(PointerEventData eventData); // 0x0000000181DB5EA0-0x0000000181DB5EE0
		public void OnPointerDown(PointerEventData eventData); // 0x0000000181DB5E50-0x0000000181DB5EA0
	}
}
