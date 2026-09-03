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
	public class CategoryAttribute : Attribute // TypeDefIndex: 8900
	{
		// Fields
		private static CategoryAttribute defAttr; // 0x00
		private bool localized; // 0x10
		private string categoryValue; // 0x18
	
		// Properties
		public static CategoryAttribute Default { get; } // 0x0000000181BA4090-0x0000000181BA4180 
		public string Category { get; } // 0x0000000181BA4030-0x0000000181BA4090 
	
		// Constructors
		public CategoryAttribute(); // 0x0000000181BA3F90-0x0000000181BA3FF0
		public CategoryAttribute(string category); // 0x0000000181BA3FF0-0x0000000181BA4030
	
		// Methods
		public override bool Equals(object obj); // 0x0000000181BA3820-0x0000000181BA3980
		public override int GetHashCode(); // 0x0000000181BA3980-0x0000000181BA39F0
		protected virtual string GetLocalizedString(string value); // 0x0000000181BA39F0-0x0000000181BA3E10
		public override bool IsDefaultAttribute(); // 0x0000000181BA3E10-0x0000000181BA3F90
	}
}
