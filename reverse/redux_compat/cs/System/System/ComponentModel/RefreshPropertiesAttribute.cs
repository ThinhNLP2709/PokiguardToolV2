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
	public sealed class RefreshPropertiesAttribute : Attribute // TypeDefIndex: 8927
	{
		// Fields
		public static readonly RefreshPropertiesAttribute All; // 0x00
		public static readonly RefreshPropertiesAttribute Repaint; // 0x08
		public static readonly RefreshPropertiesAttribute Default; // 0x10
		private RefreshProperties refresh; // 0x10
	
		// Properties
		public RefreshProperties RefreshProperties { get; } // 0x00000001802E64B0-0x00000001802E64C0 
	
		// Constructors
		public RefreshPropertiesAttribute(RefreshProperties refresh); // 0x0000000181380310-0x0000000181380340
		static RefreshPropertiesAttribute(); // 0x0000000181BD4210-0x0000000181BD4320
	
		// Methods
		public override bool Equals(object value); // 0x0000000181BD4110-0x0000000181BD41A0
		public override int GetHashCode(); // 0x0000000181B8F900-0x0000000181B8F910
		public override bool IsDefaultAttribute(); // 0x0000000181BD41A0-0x0000000181BD4210
	}
}
