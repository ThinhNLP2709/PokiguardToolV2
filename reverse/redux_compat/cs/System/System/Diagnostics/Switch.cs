/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Diagnostics
{
	public abstract class Switch // TypeDefIndex: 8726
	{
		// Fields
		private readonly string description; // 0x10
		private readonly string displayName; // 0x18
		private string switchValueString; // 0x20
		private string defaultValue; // 0x28
		private static List<WeakReference> switches; // 0x00
		private static int s_LastCollectionCount; // 0x08
	
		// Constructors
		protected Switch(string displayName, string description); // 0x0000000181B85740-0x0000000181B857B0
		protected Switch(string displayName, string description, string defaultSwitchValue); // 0x0000000181B857B0-0x0000000181B85A20
		static Switch(); // 0x0000000181B856B0-0x0000000181B85740
	
		// Methods
		private static void _pruneCachedSwitches(); // 0x0000000181B85A20-0x0000000181B85EA0
	}
}
