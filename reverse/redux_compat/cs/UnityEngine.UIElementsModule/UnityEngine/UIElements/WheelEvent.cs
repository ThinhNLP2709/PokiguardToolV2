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
	public class WheelEvent : MouseEventBase<WheelEvent> // TypeDefIndex: 4061
	{
		// Fields
		[CompilerGenerated]
		private Vector3 _delta_k__BackingField; // 0xB8
	
		// Properties
		public Vector3 delta { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001824AC1D0-0x00000001824AC1F0 0x00000001824AC1F0-0x00000001824ACDD0
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 4062
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x00000001824AB580-0x00000001824AB5F0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal WheelEvent _.cctor_b__1_0(); // 0x00000001824AA7A0-0x00000001824AA840
		}
	
		// Constructors
		static WheelEvent(); // 0x00000001824AC080-0x00000001824AC160
		public WheelEvent(); // 0x00000001824AC160-0x00000001824AC1D0
	
		// Methods
		internal static WheelEvent GetPooled(Vector3 delta, Vector3 mousePosition, EventModifiers modifiers = EventModifiers.None /* Metadata: 0x006604F5 */); // 0x00000001824ABF40-0x00000001824ABFF0
		internal static WheelEvent GetPooled(Vector3 delta, IPointerEvent pointerEvent); // 0x00000001824ABED0-0x00000001824ABF40
		protected override void Init(); // 0x00000001824ABFF0-0x00000001824AC040
		private new void LocalInit(); // 0x00000001824AC040-0x00000001824AC080
		internal override void Dispatch(BaseVisualElementPanel panel); // 0x00000001824ABE40-0x00000001824ABED0
	}
}
