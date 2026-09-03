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
	public sealed class DesignOnlyAttribute : Attribute // TypeDefIndex: 8807
	{
		// Fields
		[CompilerGenerated]
		private readonly bool _IsDesignOnly_k__BackingField; // 0x10
		public static readonly DesignOnlyAttribute Yes; // 0x00
		public static readonly DesignOnlyAttribute No; // 0x08
		public static readonly DesignOnlyAttribute Default; // 0x10
	
		// Properties
		public bool IsDesignOnly { [CompilerGenerated] get; } // 0x00000001805625D0-0x00000001805625E0 
	
		// Constructors
		public DesignOnlyAttribute(bool isDesignOnly); // 0x000000018150AE60-0x000000018150AE90
		static DesignOnlyAttribute(); // 0x0000000181B8FD70-0x0000000181B8FE60
	
		// Methods
		public override bool Equals(object obj); // 0x0000000181B8FC60-0x0000000181B8FD00
		public override int GetHashCode(); // 0x0000000181B8A580-0x0000000181B8A5C0
		public override bool IsDefaultAttribute(); // 0x0000000181B8FD00-0x0000000181B8FD70
	}
}
