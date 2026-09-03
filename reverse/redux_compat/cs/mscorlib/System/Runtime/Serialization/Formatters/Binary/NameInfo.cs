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

namespace System.Runtime.Serialization.Formatters.Binary
{
	internal sealed class NameInfo // TypeDefIndex: 3112
	{
		// Fields
		internal string NIFullName; // 0x10
		internal long NIobjectId; // 0x18
		internal long NIassemId; // 0x20
		internal InternalPrimitiveTypeE NIprimitiveTypeEnum; // 0x28
		internal Type NItype; // 0x30
		internal bool NIisSealed; // 0x38
		internal bool NIisArray; // 0x39
		internal bool NIisArrayItem; // 0x3A
		internal bool NItransmitTypeOnObject; // 0x3B
		internal bool NItransmitTypeOnMember; // 0x3C
		internal bool NIisParentTypeOnObject; // 0x3D
		internal InternalArrayTypeE NIarrayEnum; // 0x40
		private bool NIsealedStatusChecked; // 0x44
	
		// Properties
		public bool IsSealed { get; } // 0x0000000181511EA0-0x0000000181511EE0 
		public string NIname { get; set; } // 0x0000000181511EE0-0x0000000181511F30 0x00000001803780D0-0x00000001803780E0
	
		// Constructors
		internal NameInfo(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		internal void Init(); // 0x0000000181511E40-0x0000000181511EA0
	}
}
