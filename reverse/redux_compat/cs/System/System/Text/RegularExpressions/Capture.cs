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
	public class Capture // TypeDefIndex: 8691
	{
		// Fields
		[CompilerGenerated]
		private int _Index_k__BackingField; // 0x10
		[CompilerGenerated]
		private int _Length_k__BackingField; // 0x14
		[CompilerGenerated]
		private string _Text_k__BackingField; // 0x18
	
		// Properties
		public int Index { [CompilerGenerated] get; [CompilerGenerated] private protected set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
		public int Length { [CompilerGenerated] get; [CompilerGenerated] private protected set; } // 0x0000000180A5E110-0x0000000180A5E120 0x0000000180E02550-0x0000000180E02560
		internal string Text { [CompilerGenerated] get; [CompilerGenerated] private protected set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		public string Value { get; } // 0x0000000181B5CA10-0x0000000181B5CA40 
	
		// Constructors
		internal Capture(string text, int index, int length); // 0x0000000181B5CA40-0x0000000181B5CAA0
	
		// Methods
		public override string ToString(); // 0x0000000181B5CA10-0x0000000181B5CA40
		internal ReadOnlySpan<char> GetLeftSubstring(); // 0x0000000181B5C8F0-0x0000000181B5C970
		internal ReadOnlySpan<char> GetRightSubstring(); // 0x0000000181B5C970-0x0000000181B5CA10
	}
}
