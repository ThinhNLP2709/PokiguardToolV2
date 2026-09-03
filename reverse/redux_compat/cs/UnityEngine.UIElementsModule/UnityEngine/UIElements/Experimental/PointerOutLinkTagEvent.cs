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

namespace UnityEngine.UIElements.Experimental
{
	[EventCategory(EventCategory.EnterLeave)]
	public class PointerOutLinkTagEvent : PointerEventBase<PointerOutLinkTagEvent> // TypeDefIndex: 5278
	{
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 5279
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x000000018246DD00-0x000000018246DD70
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal PointerOutLinkTagEvent _.cctor_b__0_0(); // 0x000000018246D820-0x000000018246D890
		}
	
		// Constructors
		static PointerOutLinkTagEvent(); // 0x00000001824662D0-0x00000001824663B0
		public PointerOutLinkTagEvent(); // 0x00000001824663B0-0x0000000182466400
	
		// Methods
		protected override void Init(); // 0x0000000182465F70-0x0000000182465F90
		private new void LocalInit(); // 0x0000000182465F90-0x0000000182465FA0
		public static PointerOutLinkTagEvent GetPooled(IPointerEvent evt, string linkID); // 0x0000000182466290-0x00000001824662D0
		internal override void Dispatch(BaseVisualElementPanel panel); // 0x0000000182465ED0-0x0000000182465EE0
	}
}
