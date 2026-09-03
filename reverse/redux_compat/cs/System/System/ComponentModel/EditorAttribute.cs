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
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Parameter | AttributeTargets.Delegate | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter | AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	public sealed class EditorAttribute : Attribute // TypeDefIndex: 8846
	{
		// Fields
		private string _typeId; // 0x10
		[CompilerGenerated]
		private readonly string _EditorBaseTypeName_k__BackingField; // 0x18
		[CompilerGenerated]
		private readonly string _EditorTypeName_k__BackingField; // 0x20
	
		// Properties
		public string EditorBaseTypeName { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public string EditorTypeName { [CompilerGenerated] get; } // 0x00000001802F8630-0x00000001802F8640 
		public override object TypeId { get; } // 0x0000000181BA7710-0x0000000181BA77B0 
	
		// Constructors
		public EditorAttribute(string typeName, string baseTypeName); // 0x0000000181BA7680-0x0000000181BA7710
	
		// Methods
		public override bool Equals(object obj); // 0x0000000181BA75D0-0x0000000181BA7680
		public override int GetHashCode(); // 0x0000000181B8F900-0x0000000181B8F910
	}
}
