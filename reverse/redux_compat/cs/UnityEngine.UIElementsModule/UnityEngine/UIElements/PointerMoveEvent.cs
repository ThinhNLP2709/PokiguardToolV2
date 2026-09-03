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
	[EventCategory(EventCategory.PointerMove)]
	public sealed class PointerMoveEvent : PointerEventBase<UnityEngine.UIElements.PointerMoveEvent> // TypeDefIndex: 4110
	{
		// Fields
		[CompilerGenerated]
		private bool _isHandledByDraggable_k__BackingField; // 0x120
	
		// Properties
		internal bool isHandledByDraggable { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018170B040-0x000000018170B050 0x000000018170B150-0x000000018170B160
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 4111
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x00000001824AAE80-0x00000001824AAEF0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal PointerMoveEvent _.cctor_b__0_0(); // 0x00000001824AA360-0x00000001824AA3E0
		}
	
		// Constructors
		static PointerMoveEvent(); // 0x00000001824A68E0-0x00000001824A69C0
		public PointerMoveEvent(); // 0x00000001824A69C0-0x00000001824A6A10
	
		// Methods
		protected override void Init(); // 0x00000001824A6810-0x00000001824A6840
		private new void LocalInit(); // 0x00000001824A6840-0x00000001824A6860
		internal override IMouseEvent GetPooledCompatibilityMouseEvent(); // 0x00000001824A6620-0x00000001824A6810
		protected internal override void PreDispatch(IPanel panel); // 0x00000001824A4300-0x00000001824A4310
		protected internal override void PostDispatch(IPanel panel); // 0x00000001824A6860-0x00000001824A68E0
		internal override void Dispatch(BaseVisualElementPanel panel); // 0x0000000180CC2320-0x0000000180CC2360
	}
}
