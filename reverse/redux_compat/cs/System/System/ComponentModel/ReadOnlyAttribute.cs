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
	public sealed class ReadOnlyAttribute : Attribute // TypeDefIndex: 8818
	{
		// Fields
		public static readonly ReadOnlyAttribute Yes; // 0x00
		public static readonly ReadOnlyAttribute No; // 0x08
		public static readonly ReadOnlyAttribute Default; // 0x10
		[CompilerGenerated]
		private readonly bool _IsReadOnly_k__BackingField; // 0x10
	
		// Properties
		public bool IsReadOnly { [CompilerGenerated] get; } // 0x00000001805625D0-0x00000001805625E0 
	
		// Constructors
		public ReadOnlyAttribute(bool isReadOnly); // 0x000000018150AE60-0x000000018150AE90
		static ReadOnlyAttribute(); // 0x0000000181B91610-0x0000000181B91700
	
		// Methods
		public override bool Equals(object value); // 0x0000000181B91500-0x0000000181B915A0
		public override int GetHashCode(); // 0x0000000181B8F900-0x0000000181B8F910
		public override bool IsDefaultAttribute(); // 0x0000000181B915A0-0x0000000181B91610
	}
}
