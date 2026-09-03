/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.IO.Enumeration
{
	internal static class FileSystemEnumerableFactory // TypeDefIndex: 3720
	{
		// Fields
		private static readonly char[] s_unixEscapeChars; // 0x00
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass3_0 // TypeDefIndex: 3721
		{
			// Fields
			public string expression; // 0x10
			public EnumerationOptions options; // 0x18
	
			// Constructors
			public __c__DisplayClass3_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _UserFiles_b__1(ref FileSystemEntry entry); // 0x00000001815DBB10-0x00000001815DBBD0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 3722
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static FileSystemEnumerable<string> __9__3_0; // 0x08
			public static FileSystemEnumerable<string> __9__4_0; // 0x10
			public static FileSystemEnumerable<string> __9__5_0; // 0x18
	
			// Constructors
			static __c(); // 0x00000001815DBDA0-0x00000001815DBE10
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal string _UserFiles_b__3_0(ref FileSystemEntry entry); // 0x00000001815DBB00-0x00000001815DBB10
			internal string _UserDirectories_b__4_0(ref FileSystemEntry entry); // 0x00000001815DBB00-0x00000001815DBB10
			internal string _UserEntries_b__5_0(ref FileSystemEntry entry); // 0x00000001815DBB00-0x00000001815DBB10
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass4_0 // TypeDefIndex: 3723
		{
			// Fields
			public string expression; // 0x10
			public EnumerationOptions options; // 0x18
	
			// Constructors
			public __c__DisplayClass4_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _UserDirectories_b__1(ref FileSystemEntry entry); // 0x00000001815DBBD0-0x00000001815DBC90
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass5_0 // TypeDefIndex: 3724
		{
			// Fields
			public string expression; // 0x10
			public EnumerationOptions options; // 0x18
	
			// Constructors
			public __c__DisplayClass5_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _UserEntries_b__1(ref FileSystemEntry entry); // 0x00000001815DBC90-0x00000001815DBD30
		}
	
		// Constructors
		static FileSystemEnumerableFactory(); // 0x00000001815DA9A0-0x00000001815DAA30
	
		// Methods
		internal static void NormalizeInputs(ref string directory, ref string expression, EnumerationOptions options); // 0x00000001815D9F50-0x00000001815DA3D0
		private static bool MatchesPattern(string expression, ReadOnlySpan<char> name, EnumerationOptions options); // 0x00000001815D9CB0-0x00000001815D9F50
		internal static IEnumerable<string> UserFiles(string directory, string expression, EnumerationOptions options); // 0x00000001815DA7B0-0x00000001815DA9A0
		internal static IEnumerable<string> UserDirectories(string directory, string expression, EnumerationOptions options); // 0x00000001815DA3D0-0x00000001815DA5C0
		internal static IEnumerable<string> UserEntries(string directory, string expression, EnumerationOptions options); // 0x00000001815DA5C0-0x00000001815DA7B0
	}
}
