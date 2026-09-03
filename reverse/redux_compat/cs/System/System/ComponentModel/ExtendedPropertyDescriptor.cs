/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.ComponentModel
{
	internal sealed class ExtendedPropertyDescriptor : PropertyDescriptor // TypeDefIndex: 8851
	{
		// Fields
		private readonly ReflectPropertyDescriptor _extenderInfo; // 0x88
		private readonly IExtenderProvider _provider; // 0x90
	
		// Properties
		public override Type ComponentType { get; } // 0x0000000181BAAA80-0x0000000181BAAAB0 
		public override bool IsReadOnly { get; } // 0x0000000181BAAD00-0x0000000181BAADE0 
		public override Type PropertyType { get; } // 0x0000000181BAADE0-0x0000000181BAAE10 
		public override string DisplayName { get; } // 0x0000000181BAAAB0-0x0000000181BAAD00 
	
		// Constructors
		public ExtendedPropertyDescriptor(ReflectPropertyDescriptor extenderInfo, Type receiverType, IExtenderProvider provider, Attribute[] attributes); // 0x0000000181BAA7C0-0x0000000181BAAA80
	
		// Methods
		public override bool CanResetValue(object comp); // 0x0000000181BAA6B0-0x0000000181BAA6E0
		public override object GetValue(object comp); // 0x0000000181BAA6E0-0x0000000181BAA710
		public override void ResetValue(object comp); // 0x0000000181BAA710-0x0000000181BAA750
		public override void SetValue(object component, object value); // 0x0000000181BAA750-0x0000000181BAA790
		public override bool ShouldSerializeValue(object comp); // 0x0000000181BAA790-0x0000000181BAA7C0
	}
}
