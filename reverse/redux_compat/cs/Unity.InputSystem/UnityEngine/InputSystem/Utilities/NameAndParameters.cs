/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Utilities
{
	public struct NameAndParameters // TypeDefIndex: 6613
	{
		// Fields
		[CompilerGenerated]
		private string _name_k__BackingField; // 0x00
		[CompilerGenerated]
		private ReadOnlyArray<NamedValue> _parameters_k__BackingField; // 0x08
	
		// Properties
		public string name { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001808BADD0-0x00000001808BADE0 0x0000000180E02C90-0x0000000180E02CA0
		public ReadOnlyArray<NamedValue> parameters { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180C57230-0x0000000180C57240 0x0000000181CFA660-0x0000000181CFA680
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 6614
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<NamedValue, string> __9__8_0; // 0x08
			public static Func<NameAndParameters, string> __9__9_0; // 0x10
	
			// Constructors
			static __c(); // 0x0000000181D01A90-0x0000000181D01B00
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal string _ToString_b__8_0(NamedValue x); // 0x0000000181D01A50-0x0000000181D01A70
			internal string _ToSerializableString_b__9_0(NameAndParameters x); // 0x0000000181D01980-0x0000000181D019A0
		}
	
		// Methods
		public override string ToString(); // 0x0000000181CFA490-0x0000000181CFA660
		internal static string ToSerializableString(IEnumerable<NameAndParameters> list); // 0x0000000181CFA330-0x0000000181CFA490
		internal static NameAndParameters Create(string name, IList<NamedValue> parameters); // 0x0000000181CF99A0-0x0000000181CF9A40
		public static IEnumerable<NameAndParameters> ParseMultiple(string text); // 0x0000000181CF9A40-0x0000000181CF9C80
		internal static bool ParseMultiple(string text, ref List<NameAndParameters> list); // 0x0000000181CF9C80-0x0000000181CF9E50
		internal static string ParseName(string text); // 0x0000000181CFA210-0x0000000181CFA2A0
		public static NameAndParameters Parse(string text); // 0x0000000181CFA2A0-0x0000000181CFA330
		private static NameAndParameters ParseNameAndParameters(string text, ref int index, bool nameOnly = false /* Metadata: 0x006991B6 */); // 0x0000000181CF9E50-0x0000000181CFA210
	}
}
