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
	public sealed class BrowsableAttribute : Attribute // TypeDefIndex: 8804
	{
		// Fields
		public static readonly BrowsableAttribute Yes; // 0x00
		public static readonly BrowsableAttribute No; // 0x08
		public static readonly BrowsableAttribute Default; // 0x10
		[CompilerGenerated]
		private readonly bool _Browsable_k__BackingField; // 0x10
	
		// Properties
		public bool Browsable { [CompilerGenerated] get; } // 0x00000001805625D0-0x00000001805625E0 
	
		// Constructors
		public BrowsableAttribute(bool browsable); // 0x000000018150AE60-0x000000018150AE90
		static BrowsableAttribute(); // 0x0000000181B8A630-0x0000000181B8A710
	
		// Methods
		public override bool Equals(object obj); // 0x0000000181B8A4E0-0x0000000181B8A580
		public override int GetHashCode(); // 0x0000000181B8A580-0x0000000181B8A5C0
		public override bool IsDefaultAttribute(); // 0x0000000181B8A5C0-0x0000000181B8A630
	}
}
