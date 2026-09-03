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
	public struct ManipulatorActivationFilter : IEquatable<ManipulatorActivationFilter> // TypeDefIndex: 4226
	{
		// Fields
		[CompilerGenerated]
		private MouseButton _button_k__BackingField; // 0x00
		[CompilerGenerated]
		private EventModifiers _modifiers_k__BackingField; // 0x04
		[CompilerGenerated]
		private int _clickCount_k__BackingField; // 0x08
	
		// Properties
		public MouseButton button { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180732D10-0x0000000180732D20 0x0000000180732D50-0x0000000180732D60
		public EventModifiers modifiers { [IsReadOnly] [CompilerGenerated] get; } // 0x00000001802E7C60-0x00000001802E7DA0 
		public int clickCount { [IsReadOnly] [CompilerGenerated] get; } // 0x0000000180732D20-0x0000000180732D30 
	
		// Methods
		public override bool Equals(object obj); // 0x00000001824B3C10-0x00000001824B3CB0
		public bool Equals(ManipulatorActivationFilter other); // 0x00000001821FD540-0x00000001821FD560
		public override int GetHashCode(); // 0x00000001824B3CB0-0x00000001824B3D20
		public bool Matches(IPointerEvent e); // 0x00000001824B3EF0-0x00000001824B4090
		private bool HasModifiers(IPointerEvent e); // 0x00000001824B3D20-0x00000001824B3E60
		private bool MatchModifiers(bool alt, bool ctrl, bool shift, bool command); // 0x00000001824B3E60-0x00000001824B3EF0
	}
}
