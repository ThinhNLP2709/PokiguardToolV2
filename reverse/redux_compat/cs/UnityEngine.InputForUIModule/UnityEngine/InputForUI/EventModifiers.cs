/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 43: UnityEngine.InputForUIModule.dll - Assembly: UnityEngine.InputForUIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15251-15301

namespace UnityEngine.InputForUI
{
	[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
	internal struct EventModifiers // TypeDefIndex: 15263
	{
		// Fields
		private uint _state; // 0x00
	
		// Properties
		public bool isShiftPressed { get; } // 0x00000001822A35C0-0x00000001822A35D0 
		public bool isCtrlPressed { get; } // 0x00000001822A3580-0x00000001822A3590 
		public bool isAltPressed { get; } // 0x00000001822A3560-0x00000001822A3570 
		public bool isMetaPressed { get; } // 0x00000001822A35A0-0x00000001822A35B0 
		public bool isCapsLockEnabled { get; } // 0x00000001822A3570-0x00000001822A3580 
		public bool isFunctionKeyPressed { get; } // 0x00000001822A3590-0x00000001822A35A0 
		public bool isNumericPressed { get; } // 0x00000001822A35B0-0x00000001822A35C0 
	
		// Nested types
		[Flags]
		public enum Modifiers : uint // TypeDefIndex: 15264
		{
			LeftShift = 1,
			RightShift = 2,
			Shift = 3,
			LeftCtrl = 4,
			RightCtrl = 8,
			Ctrl = 12,
			LeftAlt = 16,
			RightAlt = 32,
			Alt = 48,
			LeftMeta = 64,
			RightMeta = 128,
			Meta = 192,
			CapsLock = 256,
			Numlock = 512,
			FunctionKey = 1024,
			Numeric = 2048
		}
	
		// Methods
		public bool IsPressed(Modifiers mod); // 0x00000001822A2AE0-0x00000001822A2AF0
		public void SetPressed(Modifiers modifier, bool pressed); // 0x0000000181BC0E70-0x0000000181BC0E90
		public void Reset(); // 0x00000001812C86B0-0x00000001812C86C0
		private static void Append(ref string str, string value); // 0x00000001822A2F70-0x00000001822A2FE0
		public override string ToString(); // 0x00000001822A2FE0-0x00000001822A3560
	}
}
