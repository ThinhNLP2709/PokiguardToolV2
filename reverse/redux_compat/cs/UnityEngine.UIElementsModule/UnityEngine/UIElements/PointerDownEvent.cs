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
	public sealed class PointerDownEvent : PointerEventBase<UnityEngine.UIElements.PointerDownEvent> // TypeDefIndex: 4108
	{
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 4109
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x00000001824AB270-0x00000001824AB2E0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal PointerDownEvent _.cctor_b__0_0(); // 0x00000001824AA3E0-0x00000001824AA460
		}
	
		// Constructors
		static PointerDownEvent(); // 0x00000001824A5C90-0x00000001824A5D70
		public PointerDownEvent(); // 0x00000001824A5D70-0x00000001824A5DC0
	
		// Methods
		protected override void Init(); // 0x00000001824A3FE0-0x00000001824A4010
		private new void LocalInit(); // 0x00000001824A4010-0x00000001824A4020
		internal override IMouseEvent GetPooledCompatibilityMouseEvent(); // 0x00000001824A5A70-0x00000001824A5B20
		protected internal override void PreDispatch(IPanel panel); // 0x00000001824A5C00-0x00000001824A5C90
		protected internal override void PostDispatch(IPanel panel); // 0x00000001824A5B20-0x00000001824A5C00
		internal override void Dispatch(BaseVisualElementPanel panel); // 0x0000000180CC2320-0x0000000180CC2360
	}
}
