/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	public class MouseUpEvent : MouseEventBase<UnityEngine.UIElements.MouseUpEvent> // TypeDefIndex: 4057
	{
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 4058
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x00000001824AB5F0-0x00000001824AB660
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal MouseUpEvent _.cctor_b__0_0(); // 0x00000001824A9C40-0x00000001824A9CC0
		}
	
		// Constructors
		static MouseUpEvent(); // 0x000000018249E630-0x000000018249E710
		public MouseUpEvent(); // 0x000000018249E710-0x000000018249E760
	
		// Methods
		protected override void Init(); // 0x000000018249D4F0-0x000000018249D520
		private new void LocalInit(); // 0x000000018249D520-0x000000018249D530
		private static MouseUpEvent MakeFromPointerEvent(IPointerEvent pointerEvent); // 0x000000018249E5F0-0x000000018249E630
		internal static MouseUpEvent GetPooled(PointerUpEvent pointerEvent); // 0x000000018249E580-0x000000018249E5F0
		internal static MouseUpEvent GetPooled(PointerMoveEvent pointerEvent); // 0x000000018249E4A0-0x000000018249E510
		internal static MouseUpEvent GetPooled(PointerCancelEvent pointerEvent); // 0x000000018249E510-0x000000018249E580
	}
}
