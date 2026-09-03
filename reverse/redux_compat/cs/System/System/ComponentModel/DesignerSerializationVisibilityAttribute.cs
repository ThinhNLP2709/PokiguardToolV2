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
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event)]
	public sealed class DesignerSerializationVisibilityAttribute : Attribute // TypeDefIndex: 8810
	{
		// Fields
		public static readonly DesignerSerializationVisibilityAttribute Content; // 0x00
		public static readonly DesignerSerializationVisibilityAttribute Hidden; // 0x08
		public static readonly DesignerSerializationVisibilityAttribute Visible; // 0x10
		public static readonly DesignerSerializationVisibilityAttribute Default; // 0x18
		[CompilerGenerated]
		private readonly DesignerSerializationVisibility _Visibility_k__BackingField; // 0x10
	
		// Properties
		public DesignerSerializationVisibility Visibility { [CompilerGenerated] get; } // 0x00000001802E64B0-0x00000001802E64C0 
	
		// Constructors
		public DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility visibility); // 0x0000000181380310-0x0000000181380340
		static DesignerSerializationVisibilityAttribute(); // 0x0000000181B902C0-0x0000000181B90400
	
		// Methods
		public override bool Equals(object obj); // 0x0000000181B901C0-0x0000000181B90250
		public override int GetHashCode(); // 0x0000000181B8F900-0x0000000181B8F910
		public override bool IsDefaultAttribute(); // 0x0000000181B90250-0x0000000181B902C0
	}
}
