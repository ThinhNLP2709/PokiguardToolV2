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
	public sealed class TypeConverterAttribute : Attribute // TypeDefIndex: 8884
	{
		// Fields
		public static readonly TypeConverterAttribute Default; // 0x00
		[CompilerGenerated]
		private readonly string _ConverterTypeName_k__BackingField; // 0x10
	
		// Properties
		public string ConverterTypeName { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
	
		// Constructors
		public TypeConverterAttribute(); // 0x0000000181B90130-0x0000000181B90170
		public TypeConverterAttribute(Type type); // 0x0000000181BBFE60-0x0000000181BBFEC0
		public TypeConverterAttribute(string typeName); // 0x00000001802E7420-0x00000001802E7460
		static TypeConverterAttribute(); // 0x0000000181BBFDD0-0x0000000181BBFE60
	
		// Methods
		public override bool Equals(object obj); // 0x0000000181BBFD60-0x0000000181BBFDD0
		public override int GetHashCode(); // 0x0000000181411DF0-0x0000000181411E20
	}
}
