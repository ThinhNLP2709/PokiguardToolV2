/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Text.RegularExpressions
{
	internal sealed class RegexTree // TypeDefIndex: 8721
	{
		// Fields
		public readonly RegexNode Root; // 0x10
		public readonly Hashtable Caps; // 0x18
		public readonly int[] CapNumList; // 0x20
		public readonly int CapTop; // 0x28
		public readonly Hashtable CapNames; // 0x30
		public readonly string[] CapsList; // 0x38
		public readonly RegexOptions Options; // 0x40
	
		// Constructors
		internal RegexTree(RegexNode root, Hashtable caps, int[] capNumList, int capTop, Hashtable capNames, string[] capsList, RegexOptions options); // 0x0000000181B83660-0x0000000181B83700
	}
}
