/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[EventCategory(EventCategory.Geometry)]
	public class GeometryChangedEvent : EventBase<GeometryChangedEvent>, IProfilerIgnoredEvent // TypeDefIndex: 4050
	{
		// Fields
		[CompilerGenerated]
		private Rect _oldRect_k__BackingField; // 0x68
		[CompilerGenerated]
		private Rect _newRect_k__BackingField; // 0x78
		[CompilerGenerated]
		private int _layoutPass_k__BackingField; // 0x88
	
		// Properties
		public Rect oldRect { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181D97A10-0x0000000181D97A20 0x0000000181E75F50-0x0000000181E75F60
		public Rect newRect { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181C4BDC0-0x0000000181C4BDD0 0x0000000181E75F30-0x0000000181E75F40
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal int layoutPass { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D620-0x000000018033D630 0x000000018033EC00-0x000000018033EC10
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 4051
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x00000001824AB820-0x00000001824AB890
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal GeometryChangedEvent _.cctor_b__0_0(); // 0x00000001824AA710-0x00000001824AA7A0
		}
	
		// Constructors
		static GeometryChangedEvent(); // 0x0000000182499A20-0x0000000182499B00
		public GeometryChangedEvent(); // 0x0000000182499B00-0x0000000182499B70
	
		// Methods
		public static GeometryChangedEvent GetPooled(Rect oldRect, Rect newRect); // 0x0000000182499890-0x0000000182499910
		protected override void Init(); // 0x0000000182499910-0x0000000182499930
		private new void LocalInit(); // 0x0000000182499930-0x0000000182499A20
	}
}
