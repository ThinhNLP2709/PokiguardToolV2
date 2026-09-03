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
	[EventCategory(EventCategory.PointerDown)]
	public class MouseDownEvent : MouseEventBase<UnityEngine.UIElements.MouseDownEvent> // TypeDefIndex: 4055
	{
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 4056
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x00000001824AAB70-0x00000001824AABE0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal MouseDownEvent _.cctor_b__0_0(); // 0x00000001824A95C0-0x00000001824A9640
		}
	
		// Constructors
		static MouseDownEvent(); // 0x000000018249D570-0x000000018249D650
		public MouseDownEvent(); // 0x000000018249D650-0x000000018249D6A0
	
		// Methods
		protected override void Init(); // 0x000000018249D4F0-0x000000018249D520
		private new void LocalInit(); // 0x000000018249D520-0x000000018249D530
		private static MouseDownEvent MakeFromPointerEvent(IPointerEvent pointerEvent); // 0x000000018249D530-0x000000018249D570
		internal static MouseDownEvent GetPooled(PointerDownEvent pointerEvent); // 0x000000018249D410-0x000000018249D480
		internal static MouseDownEvent GetPooled(PointerMoveEvent pointerEvent); // 0x000000018249D480-0x000000018249D4F0
	}
}
