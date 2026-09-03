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
	[EventCategory(EventCategory.PointerDown)]
	public sealed class PointerDownLinkTagEvent : PointerEventBase<PointerDownLinkTagEvent> // TypeDefIndex: 5280
	{
		// Fields
		[CompilerGenerated]
		private string _linkID_k__BackingField; // 0x120
		[CompilerGenerated]
		private string _linkText_k__BackingField; // 0x128
	
		// Properties
		private string linkID { [CompilerGenerated] set; } // 0x0000000181380050-0x0000000181380070
		private string linkText { [CompilerGenerated] set; } // 0x0000000181380070-0x0000000181380090
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 5281
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x000000018246DDE0-0x000000018246DE50
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal PointerDownLinkTagEvent _.cctor_b__0_0(); // 0x000000018246D9E0-0x000000018246DA50
		}
	
		// Constructors
		static PointerDownLinkTagEvent(); // 0x0000000182465FA0-0x0000000182466080
		public PointerDownLinkTagEvent(); // 0x0000000182466080-0x00000001824660D0
	
		// Methods
		protected override void Init(); // 0x0000000182465F70-0x0000000182465F90
		private new void LocalInit(); // 0x0000000182465F90-0x0000000182465FA0
		public static PointerDownLinkTagEvent GetPooled(IPointerEvent evt, string linkID, string linkText); // 0x0000000182465EE0-0x0000000182465F70
		internal override void Dispatch(BaseVisualElementPanel panel); // 0x0000000182465ED0-0x0000000182465EE0
	}
}
