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
	[EventCategory(EventCategory.Keyboard)]
	internal class IMEEvent : EventBase<UnityEngine.UIElements.IMEEvent>, IProfilerIgnoredEvent // TypeDefIndex: 4039
	{
		// Fields
		[CompilerGenerated]
		private string _compositionString_k__BackingField; // 0x68
	
		// Properties
		public string compositionString { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000180316960-0x0000000180316970 0x0000000180316A40-0x0000000180316A50
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 4040
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x00000001824ABAC0-0x00000001824ABB30
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal IMEEvent _.cctor_b__4_0(); // 0x00000001824AA840-0x00000001824AA8F0
		}
	
		// Constructors
		static IMEEvent(); // 0x0000000182499C80-0x0000000182499D60
		public IMEEvent(); // 0x0000000182499D60-0x0000000182499DE0
	
		// Methods
		public static IMEEvent GetPooled(string compositionString); // 0x0000000182499B70-0x0000000182499C10
		protected override void Init(); // 0x0000000182499C10-0x0000000182499C50
		private new void LocalInit(); // 0x0000000182499C50-0x0000000182499C80
		internal override void Dispatch(BaseVisualElementPanel panel); // 0x0000000180C55B00-0x0000000180C55B10
	}
}
