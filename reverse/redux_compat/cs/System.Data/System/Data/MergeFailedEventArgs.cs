/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data
{
	public class MergeFailedEventArgs : EventArgs // TypeDefIndex: 11294
	{
		// Fields
		[CompilerGenerated]
		private readonly DataTable _Table_k__BackingField; // 0x10
		[CompilerGenerated]
		private readonly string _Conflict_k__BackingField; // 0x18
	
		// Properties
		public string Conflict { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
		// Constructors
		public MergeFailedEventArgs(DataTable table, string conflict); // 0x0000000181898760-0x00000001818987F0
	}
}
