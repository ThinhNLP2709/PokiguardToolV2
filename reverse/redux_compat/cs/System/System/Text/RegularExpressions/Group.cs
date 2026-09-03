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

namespace System.Text.RegularExpressions
{
	[Serializable]
	public class Group : Capture // TypeDefIndex: 8693
	{
		// Fields
		internal static readonly Group s_emptyGroup; // 0x00
		internal readonly int[] _caps; // 0x20
		internal int _capcount; // 0x28
		[CompilerGenerated]
		private readonly string _Name_k__BackingField; // 0x30
	
		// Properties
		public bool Success { get; } // 0x0000000181B5F4D0-0x0000000181B5F4E0 
	
		// Constructors
		internal Group(string text, int[] caps, int capcount, string name); // 0x0000000181B5F400-0x0000000181B5F4D0
		static Group(); // 0x0000000181B5F2A0-0x0000000181B5F3D0
		internal Group(); // 0x0000000181B5F3D0-0x0000000181B5F400
	}
}
