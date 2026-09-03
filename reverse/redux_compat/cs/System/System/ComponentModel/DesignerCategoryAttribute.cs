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
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
	public sealed class DesignerCategoryAttribute : Attribute // TypeDefIndex: 8808
	{
		// Fields
		public static readonly DesignerCategoryAttribute Component; // 0x00
		public static readonly DesignerCategoryAttribute Default; // 0x08
		public static readonly DesignerCategoryAttribute Form; // 0x10
		public static readonly DesignerCategoryAttribute Generic; // 0x18
		[CompilerGenerated]
		private readonly string _Category_k__BackingField; // 0x10
	
		// Properties
		public string Category { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
		public override object TypeId { get; } // 0x0000000181B90170-0x0000000181B901C0 
	
		// Constructors
		public DesignerCategoryAttribute(); // 0x0000000181B90130-0x0000000181B90170
		public DesignerCategoryAttribute(string category); // 0x00000001802E7420-0x00000001802E7460
		static DesignerCategoryAttribute(); // 0x0000000181B8FF60-0x0000000181B90130
	
		// Methods
		public override bool Equals(object obj); // 0x0000000181B8FE60-0x0000000181B8FEE0
		public override int GetHashCode(); // 0x0000000181411DF0-0x0000000181411E20
		public override bool IsDefaultAttribute(); // 0x0000000181B8FEE0-0x0000000181B8FF60
	}
}
