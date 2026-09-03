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
	public struct EasingFunction : IEquatable<UnityEngine.UIElements.EasingFunction> // TypeDefIndex: 4375
	{
		// Fields
		private EasingMode m_Mode; // 0x00
	
		// Properties
		public EasingMode mode { get; set; } // 0x0000000180732D10-0x0000000180732D20 0x0000000180732D50-0x0000000180732D60
	
		// Nested types
		internal class PropertyBag : ContainerPropertyBag<EasingFunction> // TypeDefIndex: 4376
		{
			// Nested types
			private class ModeProperty : Property<EasingFunction, EasingMode> // TypeDefIndex: 4377
			{
				// Fields
				[CompilerGenerated]
				private readonly string _Name_k__BackingField; // 0x18
				[CompilerGenerated]
				private readonly bool _IsReadOnly_k__BackingField; // 0x20
	
				// Properties
				public override string Name { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
				public override bool IsReadOnly { [CompilerGenerated] get; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 
	
				// Constructors
				public ModeProperty(); // 0x0000000182536950-0x00000001825369A0
	
				// Methods
				public override EasingMode GetValue(ref EasingFunction container); // 0x0000000180E6B260-0x0000000180E6B270
				public override void SetValue(ref EasingFunction container, EasingMode value); // 0x000000018132C1A0-0x000000018132C1B0
			}
	
			// Constructors
			public PropertyBag(); // 0x0000000182537DF0-0x0000000182537EE0
		}
	
		// Constructors
		public EasingFunction(EasingMode mode); // 0x0000000180732D50-0x0000000180732D60
	
		// Methods
		public static implicit operator EasingFunction(EasingMode easingMode); // 0x0000000180815D70-0x0000000180815D80
		public static bool operator ==(EasingFunction lhs, EasingFunction rhs); // 0x0000000180A2DD00-0x0000000180A2DD10
		public bool Equals(EasingFunction other); // 0x00000001822743B0-0x00000001822743C0
		public override bool Equals(object obj); // 0x0000000182524210-0x0000000182524290
		public override string ToString(); // 0x0000000182524290-0x00000001825242F0
		public override int GetHashCode(); // 0x0000000180732D10-0x0000000180732D20
	}
}
