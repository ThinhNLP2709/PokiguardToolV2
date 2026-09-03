/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 23: UnityEngine.IMGUIModule.dll - Assembly: UnityEngine.IMGUIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13910-13956

namespace UnityEngine
{
	[Serializable]
	[NativeHeader("Modules/IMGUI/GUISkin.bindings.h")]
	public sealed class GUISettings // TypeDefIndex: 13932
	{
		// Fields
		[SerializeField]
		private bool m_DoubleClickSelectsWord; // 0x10
		[SerializeField]
		private bool m_TripleClickSelectsLine; // 0x11
		[SerializeField]
		private Color m_CursorColor; // 0x14
		[SerializeField]
		private float m_CursorFlashSpeed; // 0x24
		[SerializeField]
		private Color m_SelectionColor; // 0x28
	
		// Properties
		public bool doubleClickSelectsWord { get; } // 0x00000001805625D0-0x00000001805625E0 
		public bool tripleClickSelectsLine { get; } // 0x0000000180E38E10-0x0000000180E38E20 
		public Color cursorColor { get; } // 0x00000001811027F0-0x0000000181102800 
		public float cursorFlashSpeed { get; } // 0x0000000182281270-0x00000001822812B0 
		public Color selectionColor { get; } // 0x0000000180C46B90-0x0000000180C46BA0 
	
		// Constructors
		public GUISettings(); // 0x0000000182281240-0x0000000182281270
	
		// Methods
		private static float Internal_GetCursorFlashSpeed(); // 0x0000000182281210-0x0000000182281240
	}
}
