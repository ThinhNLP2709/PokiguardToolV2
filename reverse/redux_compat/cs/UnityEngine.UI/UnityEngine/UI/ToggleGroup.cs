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
using UnityEngine.EventSystems;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.UI
{
	[AddComponentMenu("UI (Canvas)/Toggle Group", 31)]
	[DisallowMultipleComponent]
	[UGUIHelpURL("ToggleGroup")]
	public class ToggleGroup : UIBehaviour // TypeDefIndex: 13129
	{
		// Fields
		[SerializeField]
		private bool m_AllowSwitchOff; // 0x20
		protected List<Toggle> m_Toggles; // 0x28
	
		// Properties
		public bool allowSwitchOff { get; set; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 0x00000001813C7380-0x00000001813C7390
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 13130
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Predicate<Toggle> __9__13_0; // 0x08
			public static Func<Toggle, bool> __9__14_0; // 0x10
	
			// Constructors
			static __c(); // 0x00000001825C16B0-0x00000001825C1720
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _AnyTogglesOn_b__13_0(Toggle x); // 0x00000001825C1660-0x00000001825C1680
			internal bool _ActiveToggles_b__14_0(Toggle x); // 0x00000001825C1660-0x00000001825C1680
		}
	
		// Constructors
		protected ToggleGroup(); // 0x00000001825ABAA0-0x00000001825ABB20
	
		// Methods
		protected override void Start(); // 0x00000001825AB710-0x00000001825AB730
		protected override void OnEnable(); // 0x00000001825AB710-0x00000001825AB730
		private void ValidateToggleIsInGroup(Toggle toggle); // 0x00000001825AB950-0x00000001825ABAA0
		public void NotifyToggleOn(Toggle toggle, bool sendCallback = true /* Metadata: 0x006A779C */); // 0x00000001825AB4D0-0x00000001825AB710
		public void UnregisterToggle(Toggle toggle); // 0x00000001825AB8D0-0x00000001825AB950
		public void RegisterToggle(Toggle toggle); // 0x00000001825AB730-0x00000001825AB800
		public void EnsureValidState(); // 0x00000001825AB060-0x00000001825AB460
		public bool AnyTogglesOn(); // 0x00000001825AAF30-0x00000001825AB060
		public IEnumerable<Toggle> ActiveToggles(); // 0x00000001825AAE30-0x00000001825AAF30
		public Toggle GetFirstActiveToggle(); // 0x00000001825AB460-0x00000001825AB4D0
		public void SetAllTogglesOff(bool sendCallback = true /* Metadata: 0x006A779D */); // 0x00000001825AB800-0x00000001825AB8D0
	}
}
