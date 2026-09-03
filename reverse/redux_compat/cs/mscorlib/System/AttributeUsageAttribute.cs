/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	[Serializable]
	[AttributeUsage(AttributeTargets.Class, Inherited = true)]
	public sealed class AttributeUsageAttribute : Attribute // TypeDefIndex: 2218
	{
		// Fields
		private AttributeTargets _attributeTarget; // 0x10
		private bool _allowMultiple; // 0x14
		private bool _inherited; // 0x15
		internal static AttributeUsageAttribute Default; // 0x00
	
		// Properties
		public bool AllowMultiple { get; set; } // 0x0000000181102980-0x0000000181102990 0x0000000181541B70-0x0000000181541B80
		public bool Inherited { get; set; } // 0x000000018155D200-0x000000018155D210 0x000000018155D210-0x000000018155D220
	
		// Constructors
		public AttributeUsageAttribute(AttributeTargets validOn); // 0x000000018155D1D0-0x000000018155D200
		static AttributeUsageAttribute(); // 0x000000018155D150-0x000000018155D1D0
	}
}
