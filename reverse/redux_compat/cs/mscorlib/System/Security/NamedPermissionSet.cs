/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Permissions;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Security
{
	[Serializable]
	[ComVisible(true)]
	public sealed class NamedPermissionSet : PermissionSet // TypeDefIndex: 2748
	{
		// Fields
		private string name; // 0x30
		private string description; // 0x38
	
		// Properties
		public string Name { get; set; } // 0x000000018031E110-0x000000018031E120 0x000000018147C5F0-0x000000018147C6A0
	
		// Constructors
		internal NamedPermissionSet(); // 0x000000018147C370-0x000000018147C410
		public NamedPermissionSet(string name, PermissionState state); // 0x000000018147C410-0x000000018147C5F0
		public NamedPermissionSet(string name); // 0x000000018147C360-0x000000018147C370
	
		// Methods
		public override SecurityElement ToXml(); // 0x000000018147C2C0-0x000000018147C360
		[ComVisible(false)]
		public override bool Equals(object obj); // 0x000000018147C1C0-0x000000018147C240
		[ComVisible(false)]
		public override int GetHashCode(); // 0x000000018147C240-0x000000018147C2C0
	}
}
