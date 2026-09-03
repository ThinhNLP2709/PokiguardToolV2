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
	public class ToolboxItemAttribute : Attribute // TypeDefIndex: 8843
	{
		// Fields
		private string _toolboxItemTypeName; // 0x10
		public static readonly ToolboxItemAttribute Default; // 0x00
		public static readonly ToolboxItemAttribute None; // 0x08
	
		// Properties
		public string ToolboxItemTypeName { get; } // 0x0000000181A98E10-0x0000000181A98E30 
	
		// Constructors
		public ToolboxItemAttribute(bool defaultType); // 0x0000000181BBFCF0-0x0000000181BBFD60
		public ToolboxItemAttribute(string toolboxItemTypeName); // 0x0000000181BBFC80-0x0000000181BBFCF0
		static ToolboxItemAttribute(); // 0x0000000181BBFB50-0x0000000181BBFC80
	
		// Methods
		public override bool IsDefaultAttribute(); // 0x0000000181BBFAE0-0x0000000181BBFB50
		public override bool Equals(object obj); // 0x0000000181BBF9D0-0x0000000181BBFAA0
		public override int GetHashCode(); // 0x0000000181BBFAA0-0x0000000181BBFAE0
	}
}
