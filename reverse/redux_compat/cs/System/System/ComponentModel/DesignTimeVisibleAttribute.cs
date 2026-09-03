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
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
	public sealed class DesignTimeVisibleAttribute : Attribute // TypeDefIndex: 8844
	{
		// Fields
		[CompilerGenerated]
		private readonly bool _Visible_k__BackingField; // 0x10
		public static readonly DesignTimeVisibleAttribute Yes; // 0x00
		public static readonly DesignTimeVisibleAttribute No; // 0x08
		public static readonly DesignTimeVisibleAttribute Default; // 0x10
	
		// Properties
		public bool Visible { [CompilerGenerated] get; } // 0x00000001805625D0-0x00000001805625E0 
	
		// Constructors
		public DesignTimeVisibleAttribute(bool visible); // 0x000000018150AE60-0x000000018150AE90
		static DesignTimeVisibleAttribute(); // 0x0000000181BA7360-0x0000000181BA7440
	
		// Methods
		public override bool Equals(object obj); // 0x0000000181BA7200-0x0000000181BA7280
		public override int GetHashCode(); // 0x0000000181BA7280-0x0000000181BA72F0
		public override bool IsDefaultAttribute(); // 0x0000000181BA72F0-0x0000000181BA7360
	}
}
