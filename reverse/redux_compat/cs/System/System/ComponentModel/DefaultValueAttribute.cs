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
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Parameter | AttributeTargets.Delegate | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter | AttributeTargets.All)]
	public class DefaultValueAttribute : Attribute // TypeDefIndex: 8801
	{
		// Fields
		private object _value; // 0x10
	
		// Properties
		public virtual object Value { get; } // 0x0000000180377550-0x0000000180377560 
	
		// Constructors
		public DefaultValueAttribute(int value); // 0x0000000181B8F9B0-0x0000000181B8FA00
		public DefaultValueAttribute(long value); // 0x0000000181B8F960-0x0000000181B8F9B0
		public DefaultValueAttribute(bool value); // 0x0000000181B8F910-0x0000000181B8F960
		public DefaultValueAttribute(string value); // 0x00000001802E7420-0x00000001802E7460
		public DefaultValueAttribute(object value); // 0x00000001802E7420-0x00000001802E7460
	
		// Methods
		public override bool Equals(object obj); // 0x0000000181B8F7D0-0x0000000181B8F900
		public override int GetHashCode(); // 0x0000000181B8F900-0x0000000181B8F910
	}
}
