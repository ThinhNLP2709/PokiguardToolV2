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
	public sealed class ListBindableAttribute : Attribute // TypeDefIndex: 8863
	{
		// Fields
		public static readonly ListBindableAttribute Yes; // 0x00
		public static readonly ListBindableAttribute No; // 0x08
		public static readonly ListBindableAttribute Default; // 0x10
		private bool _isDefault; // 0x10
		[CompilerGenerated]
		private readonly bool _ListBindable_k__BackingField; // 0x11
	
		// Properties
		public bool ListBindable { [CompilerGenerated] get; } // 0x0000000180E38E10-0x0000000180E38E20 
	
		// Constructors
		public ListBindableAttribute(bool listBindable); // 0x0000000181BAB950-0x0000000181BAB980
		static ListBindableAttribute(); // 0x0000000181BAB870-0x0000000181BAB950
	
		// Methods
		public override bool Equals(object obj); // 0x0000000181BAB770-0x0000000181BAB7F0
		public override int GetHashCode(); // 0x0000000181B8F900-0x0000000181B8F910
		public override bool IsDefaultAttribute(); // 0x0000000181BAB7F0-0x0000000181BAB870
	}
}
