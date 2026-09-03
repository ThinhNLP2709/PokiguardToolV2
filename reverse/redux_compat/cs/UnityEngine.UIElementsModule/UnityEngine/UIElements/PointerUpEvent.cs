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
	public sealed class PointerUpEvent : PointerEventBase<UnityEngine.UIElements.PointerUpEvent> // TypeDefIndex: 4112
	{
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 4113
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x00000001824AAD30-0x00000001824AADA0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal PointerUpEvent _.cctor_b__0_0(); // 0x00000001824AA460-0x00000001824AA4E0
		}
	
		// Constructors
		static PointerUpEvent(); // 0x00000001824A7210-0x00000001824A72F0
		public PointerUpEvent(); // 0x00000001824A72F0-0x00000001824A7340
	
		// Methods
		protected override void Init(); // 0x00000001824A3FE0-0x00000001824A4010
		private new void LocalInit(); // 0x00000001824A4010-0x00000001824A4020
		internal override IMouseEvent GetPooledCompatibilityMouseEvent(); // 0x00000001824A6F90-0x00000001824A7040
		protected internal override void PreDispatch(IPanel panel); // 0x00000001824A4300-0x00000001824A4310
		protected internal override void PostDispatch(IPanel panel); // 0x00000001824A7040-0x00000001824A7210
		internal override void Dispatch(BaseVisualElementPanel panel); // 0x0000000180CC2320-0x0000000180CC2360
	}
}
