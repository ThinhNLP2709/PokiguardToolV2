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
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Event)]
	public class DisplayNameAttribute : Attribute // TypeDefIndex: 8811
	{
		// Fields
		public static readonly DisplayNameAttribute Default; // 0x00
		[CompilerGenerated]
		private string _DisplayNameValue_k__BackingField; // 0x10
	
		// Properties
		public virtual string DisplayName { get; } // 0x0000000180377550-0x0000000180377560 
		protected string DisplayNameValue { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
	
		// Constructors
		public DisplayNameAttribute(); // 0x0000000181B8FC20-0x0000000181B8FC60
		public DisplayNameAttribute(string displayName); // 0x00000001802E7420-0x00000001802E7460
		static DisplayNameAttribute(); // 0x0000000181B90540-0x0000000181B905E0
	
		// Methods
		public override bool Equals(object obj); // 0x0000000181B90400-0x0000000181B904D0
		public override int GetHashCode(); // 0x0000000181B8FAD0-0x0000000181B8FB10
		public override bool IsDefaultAttribute(); // 0x0000000181B904D0-0x0000000181B90540
	}
}
