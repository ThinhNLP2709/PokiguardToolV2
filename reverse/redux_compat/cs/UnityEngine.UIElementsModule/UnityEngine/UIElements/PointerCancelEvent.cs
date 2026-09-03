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
	public sealed class PointerCancelEvent : PointerEventBase<UnityEngine.UIElements.PointerCancelEvent> // TypeDefIndex: 4114
	{
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 4115
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x00000001824AB4A0-0x00000001824AB510
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal PointerCancelEvent _.cctor_b__0_0(); // 0x00000001824A9E10-0x00000001824A9E90
		}
	
		// Constructors
		static PointerCancelEvent(); // 0x00000001824A4310-0x00000001824A43F0
		public PointerCancelEvent(); // 0x00000001824A43F0-0x00000001824A4440
	
		// Methods
		protected override void Init(); // 0x00000001824A3FE0-0x00000001824A4010
		private new void LocalInit(); // 0x00000001824A4010-0x00000001824A4020
		internal override IMouseEvent GetPooledCompatibilityMouseEvent(); // 0x00000001824A3F30-0x00000001824A3FE0
		protected internal override void PreDispatch(IPanel panel); // 0x00000001824A4300-0x00000001824A4310
		protected internal override void PostDispatch(IPanel panel); // 0x00000001824A4020-0x00000001824A4300
		internal override void Dispatch(BaseVisualElementPanel panel); // 0x0000000180CC2320-0x0000000180CC2360
	}
}
