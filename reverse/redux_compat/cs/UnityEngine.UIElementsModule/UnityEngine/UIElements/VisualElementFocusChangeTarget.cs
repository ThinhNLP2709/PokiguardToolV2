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
	internal class VisualElementFocusChangeTarget : FocusChangeDirection // TypeDefIndex: 4954
	{
		// Fields
		private static readonly ObjectPool<VisualElementFocusChangeTarget> Pool; // 0x00
		[CompilerGenerated]
		private Focusable _target_k__BackingField; // 0x18
	
		// Properties
		public Focusable target { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 4955
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x00000001823D3B40-0x00000001823D3BB0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal VisualElementFocusChangeTarget _.cctor_b__9_0(); // 0x00000001823D37E0-0x00000001823D38B0
		}
	
		// Constructors
		public VisualElementFocusChangeTarget(); // 0x00000001823E4010-0x00000001823E40B0
		static VisualElementFocusChangeTarget(); // 0x00000001823E3F00-0x00000001823E4010
	
		// Methods
		public static VisualElementFocusChangeTarget GetPooled(Focusable target); // 0x00000001823E3E60-0x00000001823E3F00
		protected override void Dispose(); // 0x00000001823E3DD0-0x00000001823E3E60
		internal override void ApplyTo(FocusController focusController, Focusable f); // 0x00000001823E3D80-0x00000001823E3DD0
	}
}
