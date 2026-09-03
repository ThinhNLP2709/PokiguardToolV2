/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.HID
{
	public static class HIDSupport // TypeDefIndex: 6356
	{
		// Fields
		private static HIDPageUsage[] s_SupportedHIDUsages; // 0x00
	
		// Properties
		public static ReadOnlyArray<HIDPageUsage> supportedHIDUsages { get; set; } // 0x0000000181DCA040-0x0000000181DCA0A0 0x0000000181DCA0A0-0x0000000181DCA2E0
	
		// Nested types
		public struct HIDPageUsage // TypeDefIndex: 6357
		{
			// Fields
			public HID.UsagePage page; // 0x00
			public int usage; // 0x04
	
			// Constructors
			public HIDPageUsage(HID.UsagePage page, int usage); // 0x0000000180C55C70-0x0000000180C55C80
			public HIDPageUsage(HID.GenericDesktop usage); // 0x0000000181DC8E40-0x0000000181DC8E50
		}
	
		// Methods
		internal static void Initialize(); // 0x0000000181DC9EB0-0x0000000181DCA040
	}
}
