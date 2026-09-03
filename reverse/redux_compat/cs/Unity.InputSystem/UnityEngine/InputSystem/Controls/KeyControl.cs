/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Controls
{
	public class KeyControl : ButtonControl // TypeDefIndex: 6570
	{
		// Fields
		[CompilerGenerated]
		private Key _keyCode_k__BackingField; // 0x148
		private int m_ScanCode; // 0x14C
	
		// Properties
		public Key keyCode { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180531AE0-0x0000000180531AF0 0x0000000181C2D560-0x0000000181C2D570
		public int scanCode { get; } // 0x0000000181CF4510-0x0000000181CF4530 
	
		// Constructors
		public KeyControl(); // 0x0000000181CE5F00-0x0000000181CE5F10
	
		// Methods
		protected override void RefreshConfiguration(); // 0x0000000181CF4350-0x0000000181CF4510
	}
}
